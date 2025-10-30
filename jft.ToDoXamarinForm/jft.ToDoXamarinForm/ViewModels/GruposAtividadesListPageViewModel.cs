using jft.ToDoXamarinForm.Models;
using jft.ToDoXamarinForm.Utils;
using jft.ToDoXamarinForm.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace jft.ToDoXamarinForm.ViewModels
{

    
    public class GruposAtividadesListPageViewModel : BaseViewModel<GruposAtividades>
    {


        

        public GruposAtividadesListPageViewModel()
        {
            Title = "Grupos de Atividades";
            //Items = new ObservableCollection<Item>();
            //LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<GruposAtividades>(OnItemSelected);

            //AddItemCommand = new Command(OnAddItem);
        }


        private int _id_grupo_atividade;
        private string nm_grupo_atividade;
        //private string description;
        public int id_grupo_atividade { get; set; }


        private GruposAtividades _selectedItem;

        //public ObservableCollection<Item> Items { get; }
        //public Command LoadItemsCommand { get; }
        //public Command AddItemCommand { get; }
        public Command<GruposAtividades> ItemTapped { get; }

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

        public GruposAtividades SelectedItem
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



        async void OnItemSelected(GruposAtividades item)
        {
            if (item == null)
                return;

            //return;

            await Shell.Current.GoToAsync($"{nameof(GruposAtividadesItemPage)}?{nameof(GruposAtividadesItemPageViewModel.id_grupo_atividade)}={item.id_grupo_atividade}");
        }



    }
}
