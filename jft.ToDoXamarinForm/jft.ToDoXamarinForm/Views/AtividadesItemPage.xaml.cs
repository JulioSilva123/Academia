using jft.ToDoXamarinForm.Models;
using jft.ToDoXamarinForm.ModelsView;
using jft.ToDoXamarinForm.Services;
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
    public partial class AtividadesItemPage : ContentPage
    {




        public AtividadesItemPage()
        {
            InitializeComponent();
            BindingContext = new AtividadesItemPageViewModel();

            this.Carregar();
             

        }



        GruposAtividadesService dataGrupoAtividade;
        TiposAtividadesService dataTipoAtividade;


        protected async void Carregar()
        {


            //this.nr_ordem_atividade.Text = "1";
            //this.id_grupo_atividade.Text = "0";

            //base.OnAppearing();
            //GruposAtividadesService dataGrupoAtividade = await GruposAtividadesService.Instance;
            //id_grupo_atividade.ItemsSource = await dataGrupoAtividade.GetItemsAsync();

        }



        //listView.ItemsSource = await database.GetItemsAsync();
        //GruposAtividadesListPageViewModel _viewModel;
        //private async void id_grupo_atividade_TextChanged(object sender, TextChangedEventArgs e)
        //{

        //    var _isNumeric = int.TryParse(e.NewTextValue, out int n);


        //    this.ProximoNumero();

        //    if (_isNumeric)
        //    {
        //        if (int.Parse(e.NewTextValue) > 0)
        //        {

        //            GruposAtividadesService dataGrupoAtividade = await GruposAtividadesService.Instance;

        //            var _item = await dataGrupoAtividade.GetItemAsync(int.Parse(e.NewTextValue));

        //            this.nm_grupo_atividade.Text = _item != null ? _item.nm_grupo_atividade : "Grupo não encontrado";
                    

        //            return;

        //        }
        //    }

            

        //    this.nm_grupo_atividade.Text = "Grupo não encontrada";
            

        //}

        private async void id_tipo_atividade_TextChanged(object sender, TextChangedEventArgs e)
        {

            var _isNumeric = int.TryParse(e.NewTextValue, out int n);


            //this.ProximoNumero();

            if (_isNumeric)
            {
                if (int.Parse(e.NewTextValue) > 0)
                {

                    TiposAtividadesService dataTipoAtividade = await TiposAtividadesService.Instance;

                    var _item = await dataTipoAtividade.GetItemAsync(int.Parse(e.NewTextValue));

                    this.nm_tipo_atividade.Text = _item != null ? _item.nm_tipo_atividade : "Tipo de Atividade não encontrado";


                    return;

                }
            }


            
            this.nm_tipo_atividade.Text = "Tipo de Atividade não encontrada";


        }


        //private async void ProximoNumero()
        //{

        //    var _isNumericGrupoAtividade = int.TryParse(this.id_grupo_atividade.Text, out int n1);
        //    var _isNumericTipoAtividade = int.TryParse(this.id_tipo_atividade.Text, out int n2);

        //    if (_isNumericGrupoAtividade && _isNumericTipoAtividade)
        //    {




        //        if (int.Parse(this.id_grupo_atividade.Text) > 0 && int.Parse(this.id_tipo_atividade.Text) > 0)
        //        {


        //            AtividadesService dataAtividades = await AtividadesService.Instance;

        //            var _idgrupo = int.Parse(this.id_grupo_atividade.Text);

        //            var _idtipo = int.Parse(this.id_tipo_atividade.Text);

        //            var _TotalItem = dataAtividades.GetItemsAsync().Result
        //                        .Where(ii => ii.id_grupo_atividade == _idgrupo
        //                                && ii.id_tipo_atividade == _idtipo
        //                        ).Count();

        //            this.nr_ordem_atividade.Text = (_TotalItem == 0 ? 1 : _TotalItem + 1).ToString();

        //            return;

        //        }
        //    }



        //    this.nr_ordem_atividade.Text = "1";


        //}





        async void OnSaveClicked(object sender, EventArgs e)
        { 
            var pageItem = (AtividadesItemPageViewModel)BindingContext;

            


            var _database = new AtividadesViewService();

             
            AtividadesView todoItem = await _database.GetItemViewAsync(pageItem.id_atividade);

            todoItem.nr_ordem_atividade = pageItem.nr_ordem_atividade;
            todoItem.GruposAtividades.id_grupo_atividade = pageItem.id_grupo_atividade;
            todoItem.TiposAtividades.id_tipo_atividade = pageItem.id_tipo_atividade;
            todoItem.id_atividade = pageItem.id_atividade;
            todoItem.nm_atividade = pageItem.nm_atividade;
            todoItem.te_descricao = pageItem.te_descricao;

            await _database.SaveItemViewAsync(todoItem);
            await Navigation.PopAsync();
              
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
           

            var todoItem = (AtividadesItemPageViewModel)BindingContext;
            var _database = new AtividadesViewService();
             
            await _database.DeleteItemViewAsync(todoItem.id_atividade.ToString());
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}