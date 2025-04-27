using NUnit.Framework;
using SlangNet.Bindings.Generated;

namespace SlangNet.Tests;

public class UUIDTests
{
    [Test]
    public unsafe void Roundtrip()
    {
        //0x87ede0e1, 0x4852, 0x44b0, { 0x8b, 0xf2, 0xcb, 0x31, 0x87, 0x4d, 0xe2, 0x39
        //87ede0e1-4852-44b0-8bf2cb31874de239

        var guid = new Guid(0x87ede0e1, 0x4852, 0x44b0, 0x8b, 0xf2, 0xcb, 0x31, 0x87, 0x4d, 0xe2, 0x39);

        var uuid = SlangUUID.FromGuid(guid);
        Assert.That(uuid.ToGuid().ToString(), Is.EqualTo("87ede0e1-4852-44b0-8bf2-cb31874de239"));
        
        Assert.Multiple(() =>
        {
            Assert.That(uuid.data1, Is.EqualTo(0x87ede0e1));
            Assert.That(uuid.data2, Is.EqualTo(0x4852));
            Assert.That(uuid.data3, Is.EqualTo(0x44b0));
            
            Assert.That(uuid.ToGuid(), Is.EqualTo(guid));
        });
    }
}
