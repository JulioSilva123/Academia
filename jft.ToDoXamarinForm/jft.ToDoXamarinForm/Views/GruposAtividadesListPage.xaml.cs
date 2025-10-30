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
    public partial class GruposAtividadesListPage : ContentPage
    {
        public GruposAtividadesListPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new GruposAtividadesListPageViewModel();
        }


        GruposAtividadesListPageViewModel _viewModel;

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    _viewModel.OnAppearing();
        //}

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();


            GruposAtividadesService database = await GruposAtividadesService.Instance;
            listView.ItemsSource = await database.GetItemsAsync();
        }
         
        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GruposAtividadesItemPage
            {
                BindingContext = new GruposAtividades()
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
                await Navigation.PushAsync(new GruposAtividadesItemPage
                {
                    BindingContext = e.SelectedItem as GruposAtividades
                });
            }
        }

    }


}
