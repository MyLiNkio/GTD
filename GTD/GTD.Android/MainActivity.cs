using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using GTD.DbConnector;
using GTD.DbConnector.Repositories;
using System.IO;
using System.Collections.Generic;
using GTD.Models;

namespace GTD.Droid
{
	[Activity(Label = "GTD", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			var dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "productsDb.db");
			//InitDb(dbPath);

			Global.RepositoryHolder = new RepositoryHolder(dbPath);

			global::Xamarin.Forms.Forms.Init(this, bundle);
			LoadApplication(new App());
		}

		private static void InitDb(string dbPath)
		{
			bool exists = File.Exists(dbPath);
			if (exists)
			{
				File.Delete(dbPath);
			}

			var stackRepo = new StacksRepository(dbPath);
			var stacks = new List<Stack>
			{
				new Stack { Type = PeriodType.None, StartDate = DateTime.Today },
				new Stack { Type = PeriodType.Daily, StartDate = DateTime.Today },
				new Stack { Type = PeriodType.Weekly, StartDate = DateTime.Today },
				new Stack { Type = PeriodType.Monthly, StartDate = DateTime.Today },
				new Stack { Type = PeriodType.Yearly, StartDate = DateTime.Today },
			};

			foreach (var record in stacks)
			{
				stackRepo.AddAsync(record);
			}
			var resStacks = stackRepo.GetAsync().Result;


			var rRepo = new RecordsRepository(dbPath);
			var records = new List<Record>()
			{
				new Record{Name = "Name 1", Description="Some description here", Status=Status.Active, StackId = stacks[0].Id},
				new Record{Name = "Name 2", Description="Some description here", Status=Status.Deleted, StackId = stacks[1].Id},
				new Record{Name = "Name 3", Description="Some description here", Status=Status.Modified, StackId = stacks[0].Id},
				new Record{Name = "Name 4", Description="Some description here", Status=Status.Active, StackId = stacks[0].Id},
			};
			foreach (var record in records)
			{
				rRepo.AddAsync(record);
			}

			var res = rRepo.GetAsync().Result;
		}
	}
}

