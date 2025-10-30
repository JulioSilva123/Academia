using jft.ToDoXamarinForm.Models;
using jft.ToDoXamarinForm.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace jft.ToDoXamarinForm.ViewModels
{
    public class DiariaAtividadesListPageViewModel : BaseViewModel<DiariaAtividades>
    {
        public DiariaAtividadesListPageViewModel()
        {
            Title = "Diária";
            //Items = new ObservableCollection<Item>();
            //LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            //ItemTapped = new Command<Item>(OnItemSelected);

            //AddItemCommand = new Command(OnAddItem);
        }

        private DiariaAtividades _selectedItem;

        //public ObservableCollection<Item> Items { get; }
        //public Command LoadItemsCommand { get; }
        //public Command AddItemCommand { get; }
        //public Command<Item> ItemTapped { get; }

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

        public DiariaAtividades SelectedItem
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



        async void OnItemSelected(DiariaAtividades item)
        {
            if (item == null)
                return;

            return;

            //// This will push the ItemDetailPage onto the navigation stack
            //  await Shell.Current.GoToAsync($"{nameof(GruposAtividadesItemPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }



    }
}
