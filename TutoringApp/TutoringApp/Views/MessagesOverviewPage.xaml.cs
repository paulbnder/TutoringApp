﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TutoringApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessagesOverviewPage : ContentPage
    {
        public MessagesOverviewPage()
        {
            InitializeComponent();
            BindingContext = new ViewModels.MessagesOverviewViewModel();
        }
    }
}