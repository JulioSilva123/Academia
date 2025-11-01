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
    public class TiposAtividadesListPageViewModel : BaseListViewModel<TiposAtividades, TiposAtividadesView>
    {


        public TiposAtividadesListPageViewModel()
        {
            Title = "Tipos de Atividades";

         

        }


        public void OnAppearing()
        {
            base.OnAppearing();
        }

        public async override void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(TiposAtividadesItemPage));
        }

        public async override void OnItemSelected(TiposAtividadesView item)
        {
            if (item == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(TiposAtividadesItemPage)}?{nameof(TiposAtividadesView.id_tipo_atividade)}={item.id_tipo_atividade}");

            return;
        } 


    }
}
