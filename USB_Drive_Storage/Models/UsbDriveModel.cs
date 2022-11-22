using System;
using System.Collections.Generic;
using System.Text;

namespace USB_Drive_Storage.Models
{
    public class UsbDriveModel
    {
        public string Name { get; set; }
        public int DeviceId { get; set; }
        public int ConfigurationId { get; set; }
        public int ConfigurationCount { get; set; }
        public int InterfaceCount { get; set; }
        public int EndPointCount { get; set; }
    }
}
