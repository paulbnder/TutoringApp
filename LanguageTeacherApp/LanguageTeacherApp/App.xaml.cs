using LanguageTeacherApp.Services;
using LanguageTeacherApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LanguageTeacherApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
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
