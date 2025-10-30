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
    public partial class TiposAtividadesListPage : ContentPage
    {
        public TiposAtividadesListPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new TiposAtividadesListPageViewModel();
        }


        TiposAtividadesListPageViewModel _viewModel;
 

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();


            TiposAtividadesService database = await TiposAtividadesService.Instance;
            listView.ItemsSource = await database.GetItemsAsync();
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TiposAtividadesItemPage
            {
                BindingContext = new TiposAtividades()
            });
        }
        

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new TiposAtividadesItemPage
                {
                    BindingContext = e.SelectedItem as TiposAtividades
                });
            }
        }
    }
}