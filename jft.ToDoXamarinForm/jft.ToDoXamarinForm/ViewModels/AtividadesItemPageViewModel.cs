using jft.ToDoXamarinForm.Models;
using jft.ToDoXamarinForm.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace jft.ToDoXamarinForm.ViewModels
{
    public class AtividadesItemPageViewModel : BaseViewModel<Atividades>
    {

        public AtividadesItemPageViewModel()
        {
            Title = "Atividade";

            this.nr_ordem_atividade = 1;
            this.id_grupo_atividade = 0;


            //Items = new ObservableCollection<Item>();
            //LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            //ItemTapped = new Command<Item>(OnItemSelected);

            //AddItemCommand = new Command(OnAddItem);
        }







        private int _id_atividade;
        public int id_atividade {
            get
            {
                return _id_atividade;
            }
            set
            {
                _id_atividade = value;
                this.LoadItemId(value);
            }
        }

        public int id_tipo_atividade { get; set; }

        public int id_grupo_atividade { get; set; }

        public int nr_ordem_atividade { get; set; }

        private string _nm_atividade;
        public string nm_atividade
        {
            get => _nm_atividade;
            set => SetProperty(ref _nm_atividade, value);
        }

        public string te_descricao { get; set; }










        public async void LoadItemId(int itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);

                this._id_atividade = item.id_atividade;
                this.id_tipo_atividade = item.id_tipo_atividade;
                this.id_grupo_atividade = item.id_grupo_atividade;
                this._nm_atividade = item.nm_atividade;
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
