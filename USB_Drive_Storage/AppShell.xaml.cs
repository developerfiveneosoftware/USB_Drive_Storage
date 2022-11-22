using System;
using System.Collections.Generic;
using USB_Drive_Storage.ViewModels;
using USB_Drive_Storage.Views;
using Xamarin.Forms;

namespace USB_Drive_Storage
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
