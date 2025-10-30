using jft.todoapp.Services;
using jft.todoapp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace jft.todoapp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<ExercicioDataStore>();
            MainPage = new AppShell();
        }

        public void SetMainPage(Page rootPage)
        {
            MainPage = rootPage;
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
    }
}
