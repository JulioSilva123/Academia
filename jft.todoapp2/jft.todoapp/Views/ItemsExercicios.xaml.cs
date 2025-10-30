using jft.todoapp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace jft.todoapp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsExercicios : ContentPage
    {

        ItemsViewModelExercicios _viewModel;


        public ItemsExercicios()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModelExercicios();

        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

    }
}