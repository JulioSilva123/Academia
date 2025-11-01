using jft.ToDoXamarinForm.Models;
using jft.ToDoXamarinForm.ModelsView;
using jft.ToDoXamarinForm.Utils;
using jft.ToDoXamarinForm.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace jft.ToDoXamarinForm.ViewModels
{
    public class Itens_AtividadesListPageViewModel : BaseListViewModel<itens_atividade, Itens_AtividadeView>
    {


        public Itens_AtividadesListPageViewModel()
        {
            Title = "Itens Atividades";
           
        }


        public void OnAppearing()
        {
            base.OnAppearing();
        }

        public async override void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(Itens_AtividadesItemPage));
        }

        public async override void OnItemSelected(Itens_AtividadeView item)
        {
            if (item == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(Itens_AtividadesItemPage)}?{nameof(Itens_AtividadesItemPageViewModel.ItemId)}={item.id_item_atividade}");

            return;
        }

 
  


    }
}
