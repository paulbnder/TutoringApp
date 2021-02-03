using TutoringApp.Services;
using TutoringApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TutoringApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<TeacherDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
