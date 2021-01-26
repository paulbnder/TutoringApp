using TutoringApp.ViewModels;
using TutoringApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace TutoringApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(TeacherDetailPage), typeof(TeacherDetailPage));
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(NewTeacherPage), typeof(NewTeacherPage));
        }

    }
}
