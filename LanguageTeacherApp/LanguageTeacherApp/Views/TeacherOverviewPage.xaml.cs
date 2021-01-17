using TutoringApp.ViewModels;
using TutoringApp.Models;
using TutoringApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TutoringApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TeacherOverviewPage : ContentPage
    {
        readonly TeacherOverviewViewModel _viewModel;

        public TeacherOverviewPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new TeacherOverviewViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}