using System;
using Windows.Security.ExchangeActiveSyncProvisioning;
using Xamarin.Forms;

[assembly: Dependency(typeof(XCross.UWP.PlatformInfo))]
namespace XCross.UWP
{
    class PlatformInfo : IPlatformInfo
    {
        EasClientDeviceInformation devInfo = new EasClientDeviceInformation();

        public string GetModel()
        {
            return $"{devInfo.SystemManufacturer} {devInfo.SystemProductName}";
        }
        public string GetVersion()
        {
            return devInfo.OperatingSystem;
        }
    }
}
