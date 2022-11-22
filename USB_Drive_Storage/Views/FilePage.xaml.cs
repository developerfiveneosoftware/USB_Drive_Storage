using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using USB_Drive_Storage.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace USB_Drive_Storage.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilePage : ContentPage
    {
        public ICopyFileToUsb copyFiletoUsb = DependencyService.Get<ICopyFileToUsb>();

        public FilePage()
        {
            InitializeComponent();
        }

        private async void File_Selected_Clicked(object sender, EventArgs e)
        {
            //open file
            var file = await MediaPicker.PickVideoAsync();

            if (file == null)
            {
                return;
            }

            var openReadAsync = await file.OpenReadAsync();

            try
            {
                // get file as a byte stream.
                byte[] fileAsBytes = CoverttoByteArray(openReadAsync);

                copyFiletoUsb.SaveFileToUSBDevice(fileAsBytes);
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("ERROR:", $"Can't save file ERROR: {ex.Message}", "OK");
            }

        }

        private static byte[] CoverttoByteArray(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}