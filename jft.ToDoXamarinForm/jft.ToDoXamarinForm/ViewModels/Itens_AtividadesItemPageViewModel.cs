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
    public class Itens_AtividadesItemPageViewModel : BaseItemViewModel<itens_atividade, Itens_AtividadeView>
    {

        public Itens_AtividadesItemPageViewModel()
        {
            Title = "Diário - Items";
            this.Modo = Constants.PageMode.Insert;
        }


        
        private int _id_item_atividade;
        public int id_item_atividade
        {
            get
            {
                if (this.ItemId != null)
                {
                    _id_item_atividade = int.Parse(this.ItemId);
                }

                return _id_item_atividade;

                 
            }
            set
            {
                _id_item_atividade = value;

                if (this.ItemId == null)
                {
                    this.ItemId = _id_item_atividade.ToString();
                }
                
            }
        }




        private int _id_atividade;
        public int id_atividade
        {
            get => _id_atividade;
            set => SetProperty(ref _id_atividade, value);
        }

        private string _nm_item_atividade;
        public string nm_item_atividade
        {
            get => _nm_item_atividade;
            set => SetProperty(ref _nm_item_atividade, value);
        }

        private int _id_grupo_atividade;
        public int id_grupo_atividade
        {
            get => _id_grupo_atividade;
            set => SetProperty(ref _id_grupo_atividade, value);
        }

        private int _nr_ordem_item_atividade;
        public int nr_ordem_item_atividade
        {
            get => _nr_ordem_item_atividade;
            set => SetProperty(ref _nr_ordem_item_atividade, value);
        }

        private string _te_descricao;
        public string te_descricao
        {
            get => _te_descricao;
            set => SetProperty(ref _te_descricao, value);
        }

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


        private bool _bo_concluido;
        public bool bo_concluido
        {
            get => _bo_concluido;
            set => SetProperty(ref _bo_concluido, value);
        }







        public override async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(int.Parse( itemId));


                this._id_item_atividade = item.id_item_atividade;
                this.id_atividade = item.id_atividade;
                this.id_grupo_atividade = item.id_grupo_atividade;


                this.nm_item_atividade = item.nm_item_atividade;
                 
                this.nr_ordem_item_atividade = item.nr_ordem_item_atividade;

                this.te_descricao = item.te_descricao;

                this.dt_item_atividade = item.dt_item_atividade;

                this.bo_concluido = item.bo_concluido;


                this.Modo = Constants.PageMode.Update;



            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
