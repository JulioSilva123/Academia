using jft.ToDoXamarinForm.Models;
using jft.ToDoXamarinForm.Utils;
using jft.ToDoXamarinForm.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace jft.ToDoXamarinForm.ViewModels
{
    public class AtividadesListPageViewModel :
        BaseListViewModel<Atividades, AtividadesView>
    {
         

        public AtividadesListPageViewModel()
        {
            Title = "Atividades";
             
        }
         

        public void OnAppearing()
        {
            base.OnAppearing();
        }

        public async override void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(AtividadesItemPage));
        }
         
        public async override void OnItemSelected(AtividadesView item)
        {
            if (item == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(AtividadesItemPage)}?{nameof(AtividadesItemPageViewModel.ItemId)}={item.id_atividade}");

            return;
        }


         



    }
}
