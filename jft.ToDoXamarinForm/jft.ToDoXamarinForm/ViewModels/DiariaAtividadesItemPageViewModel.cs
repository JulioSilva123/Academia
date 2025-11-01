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
    public class DiariaAtividadesItemPageViewModel : 
        BaseItemViewModel<DiariaAtividades, DiariaAtividadesView>
    {

        public DiariaAtividadesItemPageViewModel()
        {
            Title = "Diaria Item";
             
        }

        private int _id_diaria_atividade;
        public int id_diaria_atividade
        {
            get
            {

                if (this.ItemId != null)
                {
                    _id_diaria_atividade = int.Parse(this.ItemId);
                }

                return _id_diaria_atividade;
                 
            }
            set
            {
                _id_diaria_atividade = value;
                this.LoadItemId(value.ToString());
            }
        }


         

        public int id_atividade { get; set; }

        public int id_item_atividade { get; set; }

        public int id_tipo_atividade { get; set; }

        public int id_grupo_atividade { get; set; }




        public int nr_ordem { get; set; }

        public string nm_diaria_atividade { get; set; }


        public string te_descricao { get; set; }


        public DateTime dt_diaria_atividade { get; set; }


        public bool bo_concluido { get; set; }


          



        //private string _nm_atividade;
        //public string nm_atividade
        //{
        //    get => _nm_atividade;
        //    set => SetProperty(ref _nm_atividade, value);
        //}

         

        public override async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(int.Parse(itemId));

                this._id_diaria_atividade = item.id_atividade;
                this.id_item_atividade = item.id_item_atividade;
                this.id_tipo_atividade = item.id_tipo_atividade;
                this.id_grupo_atividade = item.id_grupo_atividade;
                this.nr_ordem = item.nr_ordem;
                this.nm_diaria_atividade = item.nm_diaria_atividade;
                this.te_descricao = item.te_descricao;
                this.dt_diaria_atividade = item.dt_diaria_atividade;
                this.bo_concluido = item.bo_concluido;
                 
                 
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

      
    }
}
