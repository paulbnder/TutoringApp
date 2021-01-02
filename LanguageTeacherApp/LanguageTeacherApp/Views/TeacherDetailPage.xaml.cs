using LanguageTeacherApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LanguageTeacherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TeacherDetailPage : ContentPage
    {
        public TeacherDetailPage()
        {
            InitializeComponent();
            BindingContext = new TeacherDetailViewModel();
        }
    }
}