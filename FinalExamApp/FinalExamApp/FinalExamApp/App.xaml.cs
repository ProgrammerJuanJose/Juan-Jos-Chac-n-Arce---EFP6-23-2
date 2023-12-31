﻿using FinalExamApp.Services;
using FinalExamApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FinalExamApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new BienvenidaPage());
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
