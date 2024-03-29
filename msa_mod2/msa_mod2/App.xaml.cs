﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace msa_mod2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new TabbedPage {
                Children =
                {
                    new SpellCheckPage(),
                    new HistoryPage()       
                }
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
