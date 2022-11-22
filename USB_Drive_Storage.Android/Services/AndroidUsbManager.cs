using Android.App;
using Android.Content;
using Android.Hardware.Usb;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using USB_Drive_Storage.Droid.Services;
using USB_Drive_Storage.Models;
using USB_Drive_Storage.Services;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidUsbManager))]
namespace USB_Drive_Storage.Droid.Services
{
    public class AndroidUsbManager : IUSBManager
    {
        public List<UsbDriveModel> GetListOfFileStorage()
        {
            List<UsbDriveModel> returnValues = new List<UsbDriveModel>();

            //if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.R)
            //{
            //    if (!Android.OS.Environment.IsExternalStorageManager)
            //    {
            //        try
            //        {
            //            Android.Net.Uri uri = Android.Net.Uri.Parse("package:" + Android.App.Application.Context.ApplicationInfo.PackageName);
            //            Intent intent = new Intent(Android.Provider.Settings.ActionManageAppAllFilesAccessPermission, uri);
            //            var activity = Xamarin.Essentials.Platform.CurrentActivity;
            //            activity.StartActivity(intent);
            //        }
            //        catch (Exception ex)
            //        {

            //        }
            //    }
            //}

            UsbManager manager = (UsbManager)Android.App.Application.Context.GetSystemService(Context.UsbService);
            var deviceList = manager.DeviceList;

            if (deviceList != null && deviceList.Count > 0)
            {
                foreach (var item in deviceList)
                {
                    if (item.Value != null && !string.IsNullOrEmpty(item.Value.DeviceName))
                    {
                        UsbDriveModel fileLocationModel = new UsbDriveModel();
                        fileLocationModel.Name = item.Value.DeviceName;
                        fileLocationModel.DeviceId = item.Value.DeviceId;
                        fileLocationModel.ConfigurationCount = item.Value.ConfigurationCount;
                        fileLocationModel.InterfaceCount = item.Value.InterfaceCount;
                        var usbInterface = item.Value.GetInterface(0);
                        fileLocationModel.EndPointCount = usbInterface.EndpointCount;
                        returnValues.Add(fileLocationModel);
                    }
                }
            }

            return returnValues;
        }
    }
}