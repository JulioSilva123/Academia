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
    public class DiariaAtividadesListPageViewModel : BaseListViewModel<DiariaAtividades, DiariaAtividadesView>
    {
        public DiariaAtividadesListPageViewModel()
        {
            Title = "Diária";
          
        }

        

        public void OnAppearing()
        {
            base.OnAppearing();
        }


        public async override void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(DiariaAtividadesItemPage));
        }

        public async override void OnItemSelected(DiariaAtividadesView item)
        {
            if (item == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(DiariaAtividadesItemPage)}?{nameof(DiariaAtividadesView.id_diaria_atividade)}={item.id_diaria_atividade}");

            return;
        }



    }
}
