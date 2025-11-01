using jft.ToDoXamarinForm.Models;
using jft.ToDoXamarinForm.ModelsView;
using jft.ToDoXamarinForm.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace jft.ToDoXamarinForm.ViewModels
{


    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class TiposAtividadesItemPageViewModel : BaseItemViewModel<TiposAtividades, TiposAtividadesView>
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

                if (this.ItemId != null)
                {
                    _id_tipo_atividade = int.Parse(this.ItemId);
                }

                return _id_tipo_atividade;
 
            }
            set
            {
                _id_tipo_atividade = value;
                this.LoadItemId(value.ToString());
            }
        }


        private string _nm_tipo_atividade;
        public string nm_tipo_atividade
        {
            get => _nm_tipo_atividade;
            set => SetProperty(ref _nm_tipo_atividade, value);
        }
         


        public override async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(int.Parse(itemId));
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
