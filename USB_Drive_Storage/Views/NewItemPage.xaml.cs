using System;
using System.Collections.Generic;
using System.ComponentModel;
using USB_Drive_Storage.Models;
using USB_Drive_Storage.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace USB_Drive_Storage.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}