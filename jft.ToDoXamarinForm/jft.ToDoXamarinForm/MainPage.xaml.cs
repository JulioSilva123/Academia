using jft.ToDoXamarinForm.Models;
using jft.ToDoXamarinForm.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace jft.ToDoXamarinForm
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(GruposAtividadesListPage), typeof(GruposAtividadesListPage));
            Routing.RegisterRoute(nameof(AtividadesListPage), typeof(AtividadesListPage));
            Routing.RegisterRoute(nameof(TiposAtividadesListPage), typeof(TiposAtividadesListPage));
            Routing.RegisterRoute(nameof(Itens_AtividadesListPage), typeof(Itens_AtividadesListPage));

        }


        async void OnGruposAtividadesAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GruposAtividadesListPage
            {
                BindingContext = new GruposAtividades()
            });

           // await Navigation.PushAsync(new GruposAtividadesListPage());

        }


        async void OnAtividadesAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AtividadesListPage
            {
                BindingContext = new Atividades()
            });

           // await Navigation.PushAsync(new AtividadesListPage());

        }

    }
}
