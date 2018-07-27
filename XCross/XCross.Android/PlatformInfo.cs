using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using XCross.Interfaces;

[assembly: Dependency(typeof(XCross.Droid.PlatformInfo))]
namespace XCross.Droid
{
    class PlatformInfo : IPlatformInfo
    {
        public string GetModel()
        {
            return $"{Build.Manufacturer} {Build.Model}";
        }
        public string GetVersion()
        {
            return Build.VERSION.Release.ToString();
        }
    }
}