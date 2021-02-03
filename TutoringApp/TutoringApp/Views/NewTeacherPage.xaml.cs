using TutoringApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutoringApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TutoringApp.Views
{
    public partial class NewTeacherPage : ContentPage
    {
        public Teacher Teacher { get; set; }

        public NewTeacherPage()
        {
            InitializeComponent();
            BindingContext = new NewTeacherViewModel();
        }
    }
}