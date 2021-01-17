using TutoringApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace TutoringApp.Views
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