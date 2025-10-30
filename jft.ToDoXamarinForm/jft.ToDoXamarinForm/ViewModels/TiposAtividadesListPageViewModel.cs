using jft.ToDoXamarinForm.Models;
using jft.ToDoXamarinForm.Utils;
using jft.ToDoXamarinForm.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace jft.ToDoXamarinForm.ViewModels
{
    public class TiposAtividadesListPageViewModel : BaseViewModel<TiposAtividades>
    {


        public TiposAtividadesListPageViewModel()
        {
            Title = "Tipos de Atividades";

            ItemTapped = new Command<TiposAtividades>(OnItemSelected);

        }

        


        private int _id_tipo_atividade;
        private string nm_tipo_atividade;

        public int id_grupo_atividade { get; set; }


        private TiposAtividades _selectedItem;



        public Command<TiposAtividades> ItemTapped { get; }

        //async Task ExecuteLoadItemsCommand()
        //{
        //    IsBusy = true;

        //    try
        //    {
        //        Items.Clear();
        //        var items = await DataStore.GetItemsAsync(true);
        //        foreach (var item in items)
        //        {
        //            Items.Add(item);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex);
        //    }
        //    finally
        //    {
        //        IsBusy = false;
        //    }
        //}

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public TiposAtividades SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        //private async void OnAddItem(object obj)
        //{
        //    await Shell.Current.GoToAsync(nameof(NewItemPage));
        //}



        async void OnItemSelected(TiposAtividades item)
        {
            if (item == null)
                return;

            //return;

            await Shell.Current.GoToAsync($"{nameof(TiposAtividadesItemPage)}?{nameof(TiposAtividadesItemPageViewModel.id_tipo_atividade)}={item.id_tipo_atividade}");
        }


    }
}
