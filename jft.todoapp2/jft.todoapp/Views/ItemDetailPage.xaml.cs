using jft.todoapp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace jft.todoapp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}