using System.Collections;
using OptimeGBA;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.IO.Ports;

public class Algorithm
{
    // A Test behaves as an ordinary method
    [Test]
    public void AlgorithmSimplePasses()
    {
        Debug.Log(Bits.GetByteIn(0xfff9ceb6,0));
        Debug.Log(Bits.GetByteIn(0xfff9ceb6,1));
        Debug.Log(Bits.GetByteIn(0xfff9ceb6,2));
        Debug.Log(Bits.GetByteIn(0xfff9ceb6,3));

        Assert.AreEqual(Bits.GetByteIn(0xfff9ceb6,0), 0xff);
        Assert.AreEqual(Bits.GetByteIn(0xfff9ceb6,1), 0xf9);
        Assert.AreEqual(Bits.GetByteIn(0xfff9ceb6,2), 0xce);
        Assert.AreEqual(Bits.GetByteIn(0xfff9ceb6,3), 0xb6);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator AlgorithmWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
