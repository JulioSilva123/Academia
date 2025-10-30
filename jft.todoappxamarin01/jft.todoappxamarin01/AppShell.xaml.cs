using jft.todoappxamarin01.ViewModels;
using jft.todoappxamarin01.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace jft.todoappxamarin01
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
