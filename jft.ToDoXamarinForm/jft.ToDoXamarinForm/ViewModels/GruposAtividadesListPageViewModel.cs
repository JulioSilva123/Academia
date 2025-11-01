using jft.ToDoXamarinForm.Models;
using jft.ToDoXamarinForm.ModelsView;
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

    
    public class GruposAtividadesListPageViewModel :
        BaseListViewModel<GruposAtividades, GruposAtividadesView>
    {


        

        public GruposAtividadesListPageViewModel()
        {
            Title = "Grupos de Atividades";
            
        }


        public void OnAppearing()
        {
            base.OnAppearing();
        }

        public async override void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(GruposAtividadesItemPage));
        }

        public async override void OnItemSelected(GruposAtividadesView item)
        {
            if (item == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(GruposAtividadesItemPage)}?{nameof(GruposAtividadesView.id_grupo_atividade)}={item.id_grupo_atividade}");

            return;
        }

 


    }
}
