﻿using GTD.Models;
using GTD.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace GTD
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			//MainPage = new ProductsPage();
			MainPage = new MasterPage();
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
