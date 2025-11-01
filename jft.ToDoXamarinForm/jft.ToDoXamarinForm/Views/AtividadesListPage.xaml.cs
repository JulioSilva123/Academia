using jft.ToDoXamarinForm.Models;
using jft.ToDoXamarinForm.ModelsView;
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
    public partial class AtividadesListPage : ContentPage
    {
        public AtividadesListPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new AtividadesListPageViewModel();
        }

        AtividadesListPageViewModel _viewModel;


        protected override async void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();

            var _database = await AtividadesViewService.InstanceView;
            //listView.ItemsSource = await _database.GetItemsViewAsync();

            ItemsListView.ItemsSource = await _database.GetItemsViewAsync(); // _viewModel.Items;

        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AtividadesItemPage
            {
                BindingContext = new AtividadesView()
            });
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new AtividadesItemPage
                {
                    BindingContext = e.SelectedItem as AtividadesView
                });
            }
        }
    
    
    
    }
}