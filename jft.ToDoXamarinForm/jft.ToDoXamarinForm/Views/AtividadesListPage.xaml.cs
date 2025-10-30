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


            AtividadesService database = await  AtividadesService.Instance;

            listView.ItemsSource = null; // Clear the source

            listView.ItemsSource = await database.GetItemsAsync();
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AtividadesItemPage
            {
                BindingContext = new Atividades()
            });
        }
        async void OnGrupoItemAdded(object sender, EventArgs e)
        {
            //  await Navigation.PushAsync(new GrupoItemListPage());
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new AtividadesItemPage
                {
                    BindingContext = e.SelectedItem as Atividades
                });
            }
        }
    }
}