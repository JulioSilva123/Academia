using jft.ToDoXamarinForm.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
//using Xamarin.Forms.Xaml;

namespace jft.ToDoXamarinForm
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(GruposAtividadesListPage), typeof(GruposAtividadesListPage));
            Routing.RegisterRoute(nameof(AtividadesListPage), typeof(AtividadesListPage));
            Routing.RegisterRoute(nameof(TiposAtividadesListPage), typeof(TiposAtividadesListPage));
            Routing.RegisterRoute(nameof(Itens_AtividadesListPage), typeof(Itens_AtividadesListPage));

        }
    }
}