using jft.ToDoXamarinForm.Models;
using jft.ToDoXamarinForm.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace jft.ToDoXamarinForm.ViewModels
{
    public class Itens_AtividadesListPageViewModel : BaseViewModel<itens_atividade>
    {


        public Itens_AtividadesListPageViewModel()
        {
            Title = "Itens Atividades";
           
        }

        private itens_atividade _selectedItem;

        

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public itens_atividade SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }
 
        async void OnItemSelected(itens_atividade item)
        {
            if (item == null)
                return;

            return;

            //// This will push the ItemDetailPage onto the navigation stack
            //  await Shell.Current.GoToAsync($"{nameof(GruposAtividadesItemPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
        }


    }
}
