﻿using Xamarin.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICT13580570EndB.Helpers;

namespace ICT13580570EndB
{
    public partial class App : Application
    {
		public static DbHelper DbHelper { get; set; }

		public App(string dbPath)
        {
            InitializeComponent();

            DbHelper = new DbHelper(dbPath);
			MainPage = new NavigationPage(new MainPage());
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
