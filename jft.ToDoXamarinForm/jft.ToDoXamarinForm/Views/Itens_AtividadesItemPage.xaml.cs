using jft.ToDoXamarinForm.Models;
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
    public partial class Itens_AtividadesItemPage : ContentPage
    {
        public Itens_AtividadesItemPage()
        {
            InitializeComponent();
            BindingContext = new Itens_AtividadesItemPageViewModel();
            datePicker.MinimumDate = DateTime.Now.AddDays(-5);
            datePicker.MaximumDate = DateTime.Now.AddDays(5);
        }


        //GruposAtividadesService dataGrupoAtividade;

        private async void id_grupo_atividade_TextChanged(object sender, TextChangedEventArgs e)
        {

            var _isNumeric = int.TryParse(e.NewTextValue, out int n);


            //this.ProximoNumero();

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
                    GruposAtividadesService dataGrupoAtividade = await GruposAtividadesService.Instance;



                    var _item = await database.GetItemAsync(int.Parse(e.NewTextValue));
                    var _itemGrupo = await dataGrupoAtividade.GetItemAsync(_item != null ? _item.id_grupo_atividade : 0);

                    this.nm_item_atividade.Text = _item != null ? _item.nm_atividade : "Atividade não encontrada";
                    this.id_grupo_atividade.Text = _item != null ? _item.id_grupo_atividade.ToString() : "0";

                    if (_itemGrupo != null)
                    {
                        this.nm_grupo_atividade.Text = _itemGrupo.nm_grupo_atividade;
                    }

                    this.nr_ordem_item_atividade.Text = _item != null ? _item.nr_ordem_atividade.ToString() : "0";
                    this.te_descricao.Text = _item != null ? _item.te_descricao : "Sem descrição";

                    return;

                }
            }


            this.nm_grupo_atividade.Text = "Grupo não encontrado";
            this.nm_item_atividade.Text = "Atividade não encontrada";
            this.nr_ordem_item_atividade.Text = "0";
            this.id_grupo_atividade.Text = "0";
            this.te_descricao.Text = "";


        }


        async void OnSaveClicked(object sender, EventArgs e)
        {
            var todoItem = (itens_atividade)BindingContext;
            Itens_AtividadesService database = await Itens_AtividadesService.Instance;
            await database.SaveItemAsync(todoItem);
            await Navigation.PopAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var todoItem = (itens_atividade)BindingContext;
            Itens_AtividadesService database = await Itens_AtividadesService.Instance;
            await database.DeleteItemAsync(todoItem);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}