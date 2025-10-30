using jft.todoappxamarin02.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace jft.todoappxamarin02.Views
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