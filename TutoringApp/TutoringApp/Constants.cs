using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TutoringApp
{
    public static class Constants
    {
        public static string RestUrl = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5000/api/teacher/{0}" : "http://localhost:5000/api/teacher/{0}";
    }
}
