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

            Itens_AtividadesService _container = await Itens_AtividadesService.Instance;


            listView.BeginRefresh();
            if (string.IsNullOrWhiteSpace(e.NewTextValue))
                listView.ItemsSource = await _container.GetItemsAsync();
            else
                listView.ItemsSource = _container.GetItemsAsync().Result.Where(i => i.nm_item_atividade.ToLower().Contains(e.NewTextValue.ToLower()));
            listView.EndRefresh();
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


            Itens_AtividadesService database = await Itens_AtividadesService.Instance;
            listView.ItemsSource = await database.GetItemsAsync();
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Itens_AtividadesItemPage
            {
                BindingContext = new itens_atividade()
            });
        }


        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new Itens_AtividadesItemPage
                {
                    BindingContext = e.SelectedItem as itens_atividade
                });
            }
        }






    }
}