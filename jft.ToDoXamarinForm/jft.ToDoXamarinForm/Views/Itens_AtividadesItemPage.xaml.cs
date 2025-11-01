using jft.ToDoXamarinForm.Models;
using jft.ToDoXamarinForm.ModelsView;
using jft.ToDoXamarinForm.Services;
using jft.ToDoXamarinForm.Utils;
using jft.ToDoXamarinForm.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace jft.ToDoXamarinForm.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Itens_AtividadesItemPage : ContentPage
    {
        public Itens_AtividadesItemPage()
        {
            InitializeComponent();
            BindingContext = new Itens_AtividadesItemPageViewModel();
            //datePicker.MinimumDate = DateTime.Now.AddDays(-5);
            //datePicker.MaximumDate = DateTime.Now.AddDays(5);
            //datePicker.SetValue(DatePicker.DateProperty, DateTime.Now);
            this.IsBusy = true;

        }


        public bool IsBusy { get; set; }
        public Constants.PageMode Modo { get; internal set; }

        //GruposAtividadesService dataGrupoAtividade;

        private async void id_grupo_atividade_TextChanged(object sender, TextChangedEventArgs e)
        {

            var _isNumeric = int.TryParse(e.NewTextValue, out int n);


            this.ProximoNumero();

            if (_isNumeric)
            {
                if (int.Parse(e.NewTextValue) > 0)
                {

                    GruposAtividadesService dataGrupoAtividade = await GruposAtividadesService.Instance;

                    var _item = await dataGrupoAtividade.GetItemAsync(int.Parse(e.NewTextValue));

                    this.nm_grupo_atividade.Text = _item != null ? _item.nm_grupo_atividade : "Grupo não encontrado";


                    return;

                }
            }



            this.nm_grupo_atividade.Text = "Grupo não encontrada";


        }
        private async void id_atividade_TextChanged(object sender, TextChangedEventArgs e)
        {

            var _isNumeric = int.TryParse(e.NewTextValue, out int n);

            if (_isNumeric)
            {
                if (int.Parse(e.NewTextValue) > 0)
                {

                    AtividadesService database = await AtividadesService.Instance;
                    //GruposAtividadesService dataGrupoAtividade = await GruposAtividadesService.Instance;



                    var _item = await database.GetItemAsync(int.Parse(e.NewTextValue));
                    //var _itemGrupo = await dataGrupoAtividade.GetItemAsync(_item != null ? _item.id_grupo_atividade : 0);

                    this.nm_item_atividade.Text = _item != null ? _item.nm_atividade : "Atividade não encontrada";
                    //this.id_grupo_atividade.Text = _item != null ? _item.id_grupo_atividade.ToString() : "0";

                    //if (_itemGrupo != null)
                    //{
                    //    this.nm_grupo_atividade.Text = _itemGrupo.nm_grupo_atividade;
                    //}

                   // this.nr_ordem_item_atividade.Text = _item != null ? _item.nr_ordem_atividade.ToString() : "0";
                    this.te_descricao.Text = _item != null ? _item.te_descricao : "Sem descrição";

                    return;

                }
            }


            //this.nm_grupo_atividade.Text = "Grupo não encontrado";
            this.nm_item_atividade.Text = "Atividade não encontrada";
           // this.nr_ordem_item_atividade.Text = "0";
            //this.id_grupo_atividade.Text = "0";
            this.te_descricao.Text = "";


        }






        private async void ProximoNumero()
        {

            var _isNumericGrupoAtividade = int.TryParse(this.id_grupo_atividade.Text, out int n1);
            //var _isNumericTipoAtividade = int.TryParse(this.id_tipo_atividade.Text, out int n2);

            if (_isNumericGrupoAtividade )
            {




                if (int.Parse(this.id_grupo_atividade.Text) > 0  ) 
                {


                    AtividadesService dataAtividades = await AtividadesService.Instance;

                    var _idgrupo = int.Parse(this.id_grupo_atividade.Text);

                    //var _idtipo = int.Parse(this.id_tipo_atividade.Text);

                    var _TotalItem = dataAtividades.GetItemsAsync().Result
                                .Where(ii => ii.id_grupo_atividade == _idgrupo
                                ).Count();

                    this.nr_ordem_item_atividade.Text = (_TotalItem == 0 ? 1 : _TotalItem + 1).ToString();

                    return;

                }
            }



            this.nr_ordem_item_atividade.Text = "1";


        }
























        async void OnSaveClicked(object sender, EventArgs e)
        {

            //var todoItem = (Itens_AtividadeView)BindingContext;
            //var _database = new Itens_AtividadesViewService();
            //await _database.SaveItemViewAsync(todoItem);
            //await Navigation.PopAsync();



            var pageItem = (Itens_AtividadesItemPageViewModel)BindingContext;
            var _database = new Itens_AtividadesViewService();

            Itens_AtividadeView todoItem = await _database.GetItemViewAsync(pageItem.id_item_atividade);

            todoItem.id_item_atividade = pageItem.id_item_atividade;
            todoItem.Atividades.id_atividade = pageItem.id_atividade;
            todoItem.GruposAtividades.id_grupo_atividade = pageItem.id_grupo_atividade;
            todoItem.nm_item_atividade = pageItem.nm_item_atividade;
            todoItem.nr_ordem_item_atividade = pageItem.nr_ordem_item_atividade;
            todoItem.te_descricao = pageItem.te_descricao;
            todoItem.dt_item_atividade = pageItem.dt_item_atividade;
            todoItem.bo_concluido = pageItem.bo_concluido;
             

            await _database.SaveItemViewAsync(todoItem);
            await Navigation.PopAsync();





        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            

            var todoItem = (Itens_AtividadeView)BindingContext;
            var _database = new Itens_AtividadesViewService();

            await _database.DeleteItemViewAsync(todoItem.id_item_atividade.ToString());
            await Navigation.PopAsync();

        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}