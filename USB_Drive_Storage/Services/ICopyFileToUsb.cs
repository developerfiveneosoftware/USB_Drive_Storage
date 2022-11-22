using System;
using System.Collections.Generic;
using System.Text;

namespace USB_Drive_Storage.Services
{
    public interface ICopyFileToUsb
    {
        void SaveFileToUSBDevice(byte[] file);
    }
}
