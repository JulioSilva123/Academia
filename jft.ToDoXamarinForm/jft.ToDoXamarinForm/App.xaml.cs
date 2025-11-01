using jft.ToDoXamarinForm.Services;
using jft.ToDoXamarinForm.Views;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace jft.ToDoXamarinForm
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            SetAppTheme();



            DependencyService.Register<AtividadesService>();
            DependencyService.Register<AtividadesViewService>();

            DependencyService.Register<DiariaAtividadesService>();
            DependencyService.Register<DiariaAtividadesViewService>();

            DependencyService.Register<GruposAtividadesService>();
            DependencyService.Register<GruposAtividadesViewService>();

            DependencyService.Register<Itens_AtividadesService>();
            DependencyService.Register<Itens_AtividadesViewService>();


            DependencyService.Register<TiposAtividadesService>();
            DependencyService.Register<TiposAtividadesViewService>();


            //DependencyService.Register<AtividadesService>();
            //DependencyService.Register<AtividadesService>();


            MainPage = new AppShell();
            //MainPage = new MainPage();

            //MainPage = new NavigationPage(new GruposAtividadesListPage());

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }


        private void SetAppTheme()
        {
            var theme = Preferences.Get("theme", string.Empty);
            if (string.IsNullOrEmpty(theme) || theme == "light")
            {
                Application.Current.UserAppTheme = OSAppTheme.Light;
            }
            else
            {
                Application.Current.UserAppTheme = OSAppTheme.Dark;
            }
        }


    }
}
