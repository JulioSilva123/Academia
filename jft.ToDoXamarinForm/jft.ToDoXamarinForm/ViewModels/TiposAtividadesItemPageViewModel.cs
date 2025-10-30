using jft.ToDoXamarinForm.Models;
using jft.ToDoXamarinForm.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace jft.ToDoXamarinForm.ViewModels
{


    [QueryProperty(nameof(id_tipo_atividade), nameof(id_tipo_atividade))]
    public class TiposAtividadesItemPageViewModel : BaseViewModel<TiposAtividades>
    {

        public TiposAtividadesItemPageViewModel()
        {
            Title = "Tipo de Atividade";
            
        }
         
        private int _id_tipo_atividade;
        public int id_tipo_atividade
        {
            get
            {
                return _id_tipo_atividade;
            }
            set
            {
                _id_tipo_atividade = value;
                this.LoadItemId(value);
            }
        }


        private string _nm_tipo_atividade;
        public string nm_tipo_atividade
        {
            get => _nm_tipo_atividade;
            set => SetProperty(ref _nm_tipo_atividade, value);
        }
         


        public async void LoadItemId(int itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                this._id_tipo_atividade = item.id_tipo_atividade;
                this._nm_tipo_atividade = item.nm_tipo_atividade;

            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

    }
}
