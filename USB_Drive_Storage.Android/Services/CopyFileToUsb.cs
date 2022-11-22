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
using System.Text;
using USB_Drive_Storage.Droid.Services;
using USB_Drive_Storage.Services;

[assembly: Xamarin.Forms.Dependency(typeof(CopyFileToUsb))]
namespace USB_Drive_Storage.Droid.Services
{
    public class CopyFileToUsb : ICopyFileToUsb
    {
        public void SaveFileToUSBDevice(byte[] file)
        {
            if (file != null && file.Length > 0)
            {
                UsbManager manager = (UsbManager)Android.App.Application.Context.GetSystemService(Context.UsbService);

                string ACTION_USB_PERMISSION = "com.android.example.USB_PERMISSION";
                var mPermissionIntent = PendingIntent.GetBroadcast(Android.App.Application.Context, 0, new Intent(ACTION_USB_PERMISSION), PendingIntentFlags.Immutable);

                if (manager != null)
                {
                    if (manager.DeviceList != null && manager.DeviceList.Count > 0)
                    {
                        var usbDevice = manager.DeviceList.FirstOrDefault().Value;
                        if (usbDevice != null)
                        {
                            Toast.MakeText(Android.App.Application.Context, $"usb device found", ToastLength.Long).Show();

                            manager.RequestPermission(usbDevice, mPermissionIntent);
                            //List<UsbInterface> usbInterfaces = new List<UsbInterface>();
                            //List<UsbEndpoint> usbConfigurations = new List<UsbEndpoint>();

                            //for (int i = 0; i < usbDevice.InterfaceCount; i++)
                            //{
                            //    usbInterfaces.Add(usbDevice.GetInterface(i));
                            //}

                            //if (usbInterfaces != null && usbInterfaces.Count > 0)
                            //{
                            //    for (int i = 0; i < usbInterfaces.Count; i++)
                            //    {
                            //        for (int j = 0; j < usbInterfaces[i].EndpointCount; j++)
                            //        {
                            //            usbConfigurations.Add(usbInterfaces[i].GetEndpoint(i));
                            //        }
                            //    }


                            //    if (usbConfigurations != null && usbConfigurations.Count > 0)
                            //    {

                            //    }

                            UsbInterface usbInterface = usbDevice.GetInterface(0);
                            if (usbInterface != null)
                            {
                                Toast.MakeText(Android.App.Application.Context, $"usb interface found {usbInterface.Id}", ToastLength.Long).Show();
                                UsbEndpoint usbEndpoint = usbInterface.GetEndpoint(1);

                                if (usbEndpoint != null)
                                {
                                    Toast.MakeText(Android.App.Application.Context, $"usb endpoint found {usbEndpoint.EndpointNumber}", ToastLength.Long).Show();
                                    try
                                    {
                                        var deviceConnection = manager.OpenDevice(usbDevice);

                                        if (deviceConnection != null)
                                        {
                                            deviceConnection.ClaimInterface(usbInterface, false);

                                            Toast.MakeText(Android.App.Application.Context, $"File length = {file.Length}", ToastLength.Long).Show();

                                            int transferResult = deviceConnection.BulkTransfer(usbEndpoint, file, file.Length, 0);

                                            Toast.MakeText(Android.App.Application.Context, $"Transfer result = {transferResult}", ToastLength.Long).Show();

                                            deviceConnection.ReleaseInterface(usbInterface);

                                            deviceConnection.Close();
                                        }
                                        else
                                        {
                                            Toast.MakeText(Android.App.Application.Context, $"device connection is null", ToastLength.Long).Show();
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        Toast.MakeText(Android.App.Application.Context, $"USB ERROR: {ex.Message}", ToastLength.Long).Show();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}