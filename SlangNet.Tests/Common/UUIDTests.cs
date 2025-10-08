using SlangNet.Bindings.Generated;
using Xunit;

namespace SlangNet.Tests.Common;

public class UUIDTests
{
    [Fact]
    public void Roundtrip()
    {
        //0x87ede0e1, 0x4852, 0x44b0, { 0x8b, 0xf2, 0xcb, 0x31, 0x87, 0x4d, 0xe2, 0x39
        //87ede0e1-4852-44b0-8bf2cb31874de239

        var guid = new Guid(0x87ede0e1, 0x4852, 0x44b0, 0x8b, 0xf2, 0xcb, 0x31, 0x87, 0x4d, 0xe2, 0x39);

        var uuid = SlangUUID.FromGuid(guid);
        
        Assert.Equal("87ede0e1-4852-44b0-8bf2-cb31874de239", uuid.ToGuid().ToString());
        
        Assert.Multiple(() =>
        {
            Assert.Equal(0x87ede0e1, uuid.data1);
            Assert.Equal(0x4852, uuid.data2);
            Assert.Equal(0x44b0, uuid.data3);
            
            Assert.Equal(uuid.ToGuid(), guid);
        });
    }
}
