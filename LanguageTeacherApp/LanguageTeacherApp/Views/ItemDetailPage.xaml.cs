using LanguageTeacherApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace LanguageTeacherApp.Views
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