using jft.ToDoXamarinForm.Models;
using jft.ToDoXamarinForm.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace jft.ToDoXamarinForm.ViewModels
{
    public class Itens_AtividadesItemPageViewModel : BaseViewModel<itens_atividade>
    {

        public Itens_AtividadesItemPageViewModel()
        {
            Title = "Diário - Items";

        }


        
        private int _id_item_atividade;
        public int id_item_atividade
        {
            get
            {
                return _id_item_atividade;
            }
            set
            {
                _id_item_atividade = value;
                this.LoadItemId(value);
            }
        }
         



        public int id_atividade { get; set; }


        private string _nm_item_atividade;
        public string nm_item_atividade
        {
            get => _nm_item_atividade;
            set => SetProperty(ref _nm_item_atividade, value);
        }
        
            public int id_grupo_atividade { get; set; }
        public int nr_ordem_item_atividade { get; set; }

        public string te_descricao { get; set; }

        private DateTime _dt_item_atividade { get; set; }
        public DateTime dt_item_atividade
        {
            get => _dt_item_atividade;
            set
            {
                _dt_item_atividade = value;
                OnPropertyChanged(nameof(_dt_item_atividade));
            }
        }


        public bool bo_concluido { get; set; }



         
        



        public async void LoadItemId(int itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);


                this._id_item_atividade = item.id_item_atividade;
                this.id_atividade = item.id_atividade;
                this.id_grupo_atividade = item.id_grupo_atividade;


                this._nm_item_atividade = item.nm_item_atividade;
                 
                this.nr_ordem_item_atividade = item.nr_ordem_item_atividade;

                this.te_descricao = item.te_descricao;

                this.dt_item_atividade = item.dt_item_atividade;

                this.bo_concluido = item.bo_concluido;






            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
