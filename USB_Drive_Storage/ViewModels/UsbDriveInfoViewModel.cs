using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using USB_Drive_Storage.Models;
using USB_Drive_Storage.Services;
using Xamarin.Forms;

namespace USB_Drive_Storage.ViewModels
{
    public class UsbDriveInfoViewModel : BaseViewModel
    {
        public IUSBManager usbManager = DependencyService.Get<IUSBManager>();

        public ObservableCollection<UsbDriveModel> DriveInfo { get; set; }

        public UsbDriveInfoViewModel()
        {
            DriveInfo = new ObservableCollection<UsbDriveModel>();
            List < UsbDriveModel > driveInfo = usbManager.GetListOfFileStorage();
            if(driveInfo != null && driveInfo.Count > 0)
            {
                foreach(var item in driveInfo)
                {
                    DriveInfo.Add(item);
                }
            }
        }
    }
}
