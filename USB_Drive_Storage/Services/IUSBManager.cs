using System;
using System.Collections.Generic;
using System.Text;
using USB_Drive_Storage.Models;

namespace USB_Drive_Storage.Services
{
    public interface IUSBManager
    {
        List<UsbDriveModel> GetListOfFileStorage();
    }
}
