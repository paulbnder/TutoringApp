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

        async void Button_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new TeacherOverviewPage{});

            //var teacherOverviewPage = new NavigationPage(new TeacherOverviewPage());
            //await App.Current.MainPage.Navigation.PushAsync(teacherOverviewPage);

            await Shell.Current.GoToAsync("/TeacherOverviewPage");
        }
    }
}