using GameboyAdvanced.Core.Dma;
using GameboyAdvanced.Core.Input;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace GameboyAdvanced.Core.Rom
{
    public enum RomBackupType
    {
        EEPROM,
        SRAM,
        FLASH64,
        FLASH128,
    }

    public class GamePak
    {
        public readonly byte[] _header = new byte[0xC0];
        public readonly byte[] Data = new byte[0x200_0000]; // Max 32MB ROM size
        public readonly uint RomMask;
        public readonly byte[] _sram = new byte[0x1_0000];
        public readonly FlashBackup? _flashBackup;
        public readonly EEPromBackup? _eepromBackup;

        public readonly uint RomEntryPoint;
        public readonly byte[] LogoCompressed = new byte[156];
        public readonly string GameTitle;
        public readonly string GameCode;
        public readonly string MakerCode;
        public readonly byte FixedValue;
        public readonly byte MainUnitCode;
        public readonly byte DeviceType;
        public readonly byte[] ReservedArea1 = new byte[7];
        public readonly byte SoftwareVersion;
        public readonly byte ComplementCheck;
        public readonly byte[] ReservedArea2 = new byte[2];
        public readonly RomBackupType RomBackupType;
        public readonly string RomPath;
        public bool Dirty;

        // TODO - Multiboot details

        public GamePak(byte[] data, string? romPath = null)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            if (data.Length < 0xC0) throw new ArgumentException("Rom must be >= 0xC0 in size to fit cartridge header", nameof(data));

            RomPath = romPath;
            Array.Copy(data, 0, _header, 0, _header.Length);

            RomMask = data.Length <= 0x100_0000 ? 0xFF_FFFFu : 0x1FF_FFFF;
            Data = (byte[])data.Clone();

            RomEntryPoint = Utils.ReadWord(_header, 0, 0xFFFF_FFFF);
            Array.Copy(_header, 4, LogoCompressed, 0, LogoCompressed.Length);
            GameTitle = Encoding.ASCII.GetString(_header[160..171].TakeWhile(b => b != 0).ToArray());
            GameCode = Encoding.ASCII.GetString(_header[172..175]);
            MakerCode = Encoding.ASCII.GetString(_header[176..177]);
            FixedValue = _header[178];
            MainUnitCode = _header[179];
            DeviceType = _header[180];
            Array.Copy(_header, 181, ReservedArea1, 0, ReservedArea1.Length);
            SoftwareVersion = _header[188];
            ComplementCheck = _header[189];
            Array.Copy(_header, 190, ReservedArea2, 0, ReservedArea2.Length);

            Array.Fill<byte>(_sram, 0xFF);

            RomBackupType = CalculateRomBackupType(data);

            if (RomBackupType == RomBackupType.FLASH128)
            {
                _flashBackup = new FlashBackup(0x62, 0x13); // Sanyo
            }
            else if (RomBackupType == RomBackupType.FLASH64)
            {
                _flashBackup = new FlashBackup(0xBF, 0xD4); // SST
            }
            else if (RomBackupType == RomBackupType.EEPROM)
            {
                var mask = Data.Length > 0x0100_0000 ? 0x01FF_FF00u : 0x0100_0000u;

                _eepromBackup = new EEPromBackup(mask);
            }
            LoadSave();
        }

        internal void SetDmaDataUnit(DmaDataUnit dma)
        {
            if (_eepromBackup != null)
            {
                _eepromBackup.DmaDataUnit = dma;
            }
        }

        private static RomBackupType CalculateRomBackupType(byte[] bin)
        {
            var romAsString = Encoding.ASCII.GetString(bin);

            if (Regex.IsMatch(romAsString, @"EEPROM_\d\d\d"))
            {
                return RomBackupType.EEPROM;
            }
            else if (Regex.IsMatch(romAsString, @"SRAM_\d\d\d"))
            {
                return RomBackupType.SRAM;
            }
            else if (Regex.IsMatch(romAsString, @"FLASH(512)?_(\d\d\d)?"))
            {
                return RomBackupType.FLASH64;
            }
            else if (Regex.IsMatch(romAsString, @"FLASH1M_(\d\d\d)?"))
            {
                return RomBackupType.FLASH128;
            }

            return RomBackupType.SRAM;
        }

        /// <summary>
        /// Backup storage is only available over an 8 bit bus and behaves very 
        /// differently depending on what type of storage is used on the cart.
        /// </summary>
        /// 
        /// <remarks>
        /// TODO - Potentially improve performance here if it turns out 
        /// to be hit a lot by predeciding which function will be correct
        /// using delegate* at construction
        /// </remarks>
        internal byte ReadBackupStorage(uint address) => RomBackupType switch
        {
            RomBackupType.SRAM => _sram[address & 0x0EFF_FFFF & 0x7FFF],
            RomBackupType.FLASH64 => _flashBackup!.Read(address),
            RomBackupType.FLASH128 => _flashBackup!.Read(address),
            RomBackupType.EEPROM => _eepromBackup!.Read(address),
            _ => throw new Exception($"Invalid backup storage type {RomBackupType}")
        };

        internal void WriteBackupStorage(uint address, byte value)
        {
            switch (RomBackupType)
            {
                case RomBackupType.SRAM:
                    _sram[address & 0x0EFF_FFFF & 0x7FFF] = value;
                    break;
                case RomBackupType.FLASH128:
                case RomBackupType.FLASH64:
                    _flashBackup!.Write(address, value);
                    break;
                case RomBackupType.EEPROM:
                    _sram[address & 0x0EFF_FFFF & 0x7FFF] = value;
                    break;
            }
            Dirty = true;
        }

        internal void Write(uint address, byte value)
        {
            if (RomBackupType == RomBackupType.EEPROM && _eepromBackup!.IsEEPromAddress(address))
            {
                _eepromBackup!.Write(address, value);
                Dirty = true;
            }
        }

        internal byte ReadByte(uint address)
        {
            address &= RomMask;

            if (_eepromBackup != null && _eepromBackup.IsEEPromAddress(address))
            {
                return _eepromBackup.Read(address);
            }

            return address < Data.Length ?
                Data[address] :
                (byte)(address >> 1 >> (int)((address & 1) * 8));
        }

        internal ushort ReadHalfWord(uint address)
        {
            if (_eepromBackup != null && _eepromBackup.IsEEPromAddress(address))
            {
                return _eepromBackup.Read(address);
            }

            return (address & RomMask) < Data.Length
                ? Utils.ReadHalfWord(Data, address, RomMask)
                : (ushort)(address >> 1);
        }

        internal uint ReadWord(uint address)
        {
            if (_eepromBackup != null && _eepromBackup.IsEEPromAddress(address))
            {
                return _eepromBackup.Read(address);
            }

            return (address & RomMask) < Data.Length
                ? Utils.ReadWord(Data, address, RomMask)
                : (((address & 0xFFFF_FFFC) >> 1) & 0xFFFF) | (((((address & 0xFFFF_FFFC) + 2) >> 1) & 0xFFFF) << 16);
        }
        internal byte[] GetSave() => RomBackupType switch
        {
            RomBackupType.SRAM => _sram,
            RomBackupType.FLASH64 => _flashBackup!._data,
            RomBackupType.FLASH128 => _flashBackup!._data,
            RomBackupType.EEPROM => _eepromBackup!.Data,
            _ => throw new Exception($"Invalid backup storage type {RomBackupType}")
        };

        public void DumpSave()
        {
            try
            {
                File.WriteAllBytesAsync(GetSavePath(), GetSave());
            }
            catch
            {
                Console.WriteLine("Failed to write .sav file!");
            }
            finally { Dirty = false; }
        }
        internal string GetSavePath() => RomPath.Substring(0, RomPath.LastIndexOf('.')) + ".sav";
        internal void LoadSave(byte[] save)
        {
            switch (RomBackupType)
            {
                case RomBackupType.SRAM:
                    Array.Copy(save, _sram, save.Length);
                    break;
                case RomBackupType.FLASH64:
                case RomBackupType.FLASH128:
                    Array.Copy(save, _flashBackup!._data, save.Length);
                    break;
                case RomBackupType.EEPROM:
                    Array.Copy(save, _eepromBackup!.Data, save.Length);
                    break;
            }
        }
        public void LoadSave()
        {
            try
            {
                byte[] sav = File.ReadAllBytes(GetSavePath());
                LoadSave(sav);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e}");
            }
        }
        internal static bool CheckAddressIsPageBoundary(uint address) => (address & 0x1_FFFF) == 0;

        public override string ToString()
        {
            return $"{GameTitle} - {RomBackupType} - {RomMask:X8}";
        }
    }
}