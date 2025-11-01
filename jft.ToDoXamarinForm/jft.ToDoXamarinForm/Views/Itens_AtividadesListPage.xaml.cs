using jft.ToDoXamarinForm.Models;
using jft.ToDoXamarinForm.ModelsView;
using jft.ToDoXamarinForm.Services;
using jft.ToDoXamarinForm.Utils;
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
    public partial class Itens_AtividadesListPage : ContentPage
    {
        public Itens_AtividadesListPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new Itens_AtividadesListPageViewModel();
        }


        Itens_AtividadesListPageViewModel _viewModel;



        private async void Handle_SearchButtonPressed(object sender, TextChangedEventArgs e)
        {
            //var _container = BindingContext as ListViewModel;


          
            var _container = await Itens_AtividadesViewService.InstanceView;
           

            //listView.BeginRefresh();
            //if (string.IsNullOrWhiteSpace(e.NewTextValue))
            //    listView.ItemsSource = await _container.GetItemsViewAsync();
            //else
            //    listView.ItemsSource = _container.GetItemsViewAsync().Result.Where(i => i.nm_item_atividade.ToLower().Contains(e.NewTextValue.ToLower()));
            //listView.EndRefresh();


            ItemsListView.BatchBegin();
            if (string.IsNullOrWhiteSpace(e.NewTextValue))
                ItemsListView.ItemsSource = await _container.GetItemsViewAsync();
            else
                ItemsListView.ItemsSource = _container.GetItemsViewAsync().Result.Where(i => i.nm_item_atividade.ToLower().Contains(e.NewTextValue.ToLower()));

            ItemsListView.BatchCommit();



        }
        

        

        private void Handle_Clicked(object sender, EventArgs e)
        {
            //var _container = BindingContext as ListViewModel;
            DisplayAlert("Parabéns", "Voce acabou de se inscrever", "OK", "Cancel");
        }

        


        protected override async void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();


            var _database = await Itens_AtividadesViewService.InstanceView;
            //listView.ItemsSource = await _database.GetItemsViewAsync();
            //var _database = await AtividadesViewService.InstanceView;
            //listView.ItemsSource = await _database.GetItemsViewAsync();

            ItemsListView.ItemsSource = await _database.GetItemsViewAsync(); // _viewModel.Items;


        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Itens_AtividadesItemPage
            {
                BindingContext = new Itens_AtividadeView()
            });
        }


        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new Itens_AtividadesItemPage
                {
                    BindingContext = e.SelectedItem as Itens_AtividadeView,
                    Modo = Constants.PageMode.Update
                });
            }
        }






    }
}