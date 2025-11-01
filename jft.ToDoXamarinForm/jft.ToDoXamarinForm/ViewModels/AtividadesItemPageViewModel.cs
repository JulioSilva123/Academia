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
    public class AtividadesItemPageViewModel : BaseItemViewModel<Atividades, AtividadesView>
    {

        public AtividadesItemPageViewModel()
        {
            Title = "Atividade";

            this.nr_ordem_atividade = 1;
            this.id_grupo_atividade = 0;
             
        }







        private int _id_atividade;
        public int id_atividade {
            get
            {

                if (this.ItemId != null)
                {
                    _id_atividade = int.Parse(this.ItemId);
                }

                return _id_atividade;

            }
            set
            {
                _id_atividade = value;

                if (this.ItemId == null)
                {
                    this.ItemId = _id_atividade.ToString();
                }


               // this.LoadItemId(value.ToString());
            }
        }

        private int _id_tipo_atividade;
        public int id_tipo_atividade
        {
            get => _id_tipo_atividade;
            set => SetProperty(ref _id_tipo_atividade, value);
        }



        public int id_grupo_atividade { get; set; }

        public int nr_ordem_atividade { get; set; }

        private string _nm_atividade;
        public string nm_atividade
        {
            get => _nm_atividade;
            set => SetProperty(ref _nm_atividade, value);
        }



        private string _te_descricao;

        public string te_descricao
        {
            get => _te_descricao;
            set => SetProperty(ref _te_descricao, value);
        }








        public  async override void LoadItemId(string _id)
        {
            try
            {
                var item = await DataStore.GetItemAsync(int.Parse(_id));

                this._id_atividade = item.id_atividade;
                this.id_tipo_atividade = item.id_tipo_atividade;
                this.id_grupo_atividade = item.id_grupo_atividade;
                this.nm_atividade = item.nm_atividade;
                this.te_descricao  = item.te_descricao;
                this.nr_ordem_atividade = item.nr_ordem_atividade;

                //Description = item.Description;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

       
    }
}
