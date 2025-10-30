using jft.ToDoXamarinForm.Models;
using jft.ToDoXamarinForm.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace jft.ToDoXamarinForm.ViewModels
{


    [QueryProperty(nameof(id_grupo_atividade), nameof(id_grupo_atividade))]
    public class GruposAtividadesItemPageViewModel : BaseViewModel<GruposAtividades>
    {

        public GruposAtividadesItemPageViewModel()
        {
            Title = "Grupo de Atividade";
            //Items = new ObservableCollection<Item>();
            //LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            //ItemTapped = new Command<Item>(OnItemSelected);

            //AddItemCommand = new Command(OnAddItem);
        }




        //private string description;


        private int _id_grupo_atividade;
        public int id_grupo_atividade
        {
            get
            {
                return _id_grupo_atividade;
            }
            set
            {
                _id_grupo_atividade = value;
                this.LoadItemId(value);
            }
        }


        private string _nm_grupo_atividade;
        public string nm_grupo_atividade
        {
            get => _nm_grupo_atividade;
            set => SetProperty(ref _nm_grupo_atividade, value);
        }

        //public string Description
        //{
        //    get => description;
        //    set => SetProperty(ref description, value);
        //}



        public async void LoadItemId(int itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                this._id_grupo_atividade = item.id_grupo_atividade;
                this._nm_grupo_atividade = item.nm_grupo_atividade;
                //Description = item.Description;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }




    }
}
