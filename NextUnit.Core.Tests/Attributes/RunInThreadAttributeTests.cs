using Microsoft.Management.Infrastructure;
using NextUnit.Core.Asserts;
using NextUnit.Core.TestAttributes;
using NextUnit.HardwareContext.SystemInformation;

namespace NextUnit.Core.Tests.Attributes
{
    public class RunInThreadAttributeTests
    {
        [Test]
        [RunInThread(ApartmentState.STA, false, "de-DE")]
        [Group(nameof(SysInfo))]
        public void GetUSBDevicesTest()
        {
            List<CimInstance> usbDevices = SysInfo.GetUSBDevices();
            Assert.IsNotNull(usbDevices);
            Assert.IsNotEmpty(usbDevices);
        }

        [Test]
        [RunInThread(ApartmentState.STA, false, "de-DE")]
        [Group(nameof(SysInfo))]
        public void GetUserAccountsTest()
        {
            List<CimInstance> userAccounts = SysInfo.GetUserAccounts();
            Assert.IsNotNull(userAccounts);
            Assert.IsNotEmpty(userAccounts);
        }
    }
}
