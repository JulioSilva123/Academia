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
    public class GruposAtividadesItemPageViewModel : BaseItemViewModel<GruposAtividades, GruposAtividadesView>
    {

        public GruposAtividadesItemPageViewModel()
        {
            Title = "Grupo de Atividade";
           
        }

 

        private int _id_grupo_atividade;
        public int id_grupo_atividade
        {
            get
            {
                if (this.ItemId != null)
                {
                    _id_grupo_atividade = int.Parse(this.ItemId);
                }

                return _id_grupo_atividade;

            }
            set
            {
                _id_grupo_atividade = value;
                this.LoadItemId(value.ToString());
            }
        }


        private string _nm_grupo_atividade;
        public string nm_grupo_atividade
        {
            get => _nm_grupo_atividade;
            set => SetProperty(ref _nm_grupo_atividade, value);
        }

        


        public override async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(int.Parse(itemId));
                this._id_grupo_atividade = item.id_grupo_atividade;
                this.nm_grupo_atividade = item.nm_grupo_atividade;
           
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

      
    }
}
