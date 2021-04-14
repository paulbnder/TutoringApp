using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TutoringApp.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        async void navigateToTeacherOverviewPage(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("TeacherOverviewPage");
        }

        async void navigateToNewTeacherPage(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("NewTeacherPage");
        }
    }
}