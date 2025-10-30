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
    public partial class TiposAtividadesItemPage : ContentPage
    {
        public TiposAtividadesItemPage()
        {
            InitializeComponent();
            BindingContext = new TiposAtividadesItemPageViewModel();
        }


        async void OnSaveClicked(object sender, EventArgs e)
        {
            var todoItem = (TiposAtividades)BindingContext;
            TiposAtividadesService database = await TiposAtividadesService.Instance;
            await database.SaveItemAsync(todoItem);
            await Navigation.PopAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var todoItem = (TiposAtividades)BindingContext;
            TiposAtividadesService database = await TiposAtividadesService.Instance;
            await database.DeleteItemAsync(todoItem);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}