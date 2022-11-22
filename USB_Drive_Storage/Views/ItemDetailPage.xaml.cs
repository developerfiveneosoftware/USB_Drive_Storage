using System.ComponentModel;
using USB_Drive_Storage.ViewModels;
using Xamarin.Forms;

namespace USB_Drive_Storage.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}