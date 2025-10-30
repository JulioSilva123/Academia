using jft.ToDoXamarinForm.Models;
using jft.ToDoXamarinForm.Services;
using jft.ToDoXamarinForm.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace jft.ToDoXamarinForm.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GruposAtividadesItemPage : ContentPage
    {
        public GruposAtividadesItemPage()
        {
            InitializeComponent();
            BindingContext = new GruposAtividadesItemPageViewModel();
        }


        async void OnSaveClicked(object sender, EventArgs e)
        {
            var todoItem = (GruposAtividades)BindingContext;
            GruposAtividadesService database = await GruposAtividadesService.Instance;
            await database.SaveItemAsync(todoItem);
            await Navigation.PopAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var todoItem = (GruposAtividades)BindingContext;
            GruposAtividadesService database = await GruposAtividadesService.Instance;
            await database.DeleteItemAsync(todoItem);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }


    }
}