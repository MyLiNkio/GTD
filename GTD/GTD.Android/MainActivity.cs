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
			InitDb(dbPath);

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
				new Stack { Type = StackType.Day, StartDate = DateTime.Today },
				new Stack { Type = StackType.None, StartDate = DateTime.Today },
				new Stack { Type = StackType.Week, StartDate = DateTime.Today },
				new Stack { Type = StackType.Month, StartDate = DateTime.Today },
			};

			foreach (var record in stacks)
			{
				stackRepo.AddAsync(record);
			}

			var rRepo = new RecordsRepository(dbPath);
			var records = new List<Record>()
			{
				new Record{ IsFinished = true, Name = "Meeting at Akadem", Description = "Meeting starts at 10:00 on the building", StackId = stacks[0].Id},
				new Record{ Name = "Buy bread at the shop", Description="Go to the Silpo after work and buy some bread", StackId = stacks[0].Id},
				new Record{ Name = "Visit a doctor", Description="Some description here", Status=Status.Active, StackId = stacks[0].Id},
				new Record{ Name = "Bring my laptop to the work", Description="Some description here", Status=Status.Deleted, StackId = stacks[0].Id},
				new Record{ Name = "Create a report", Description="Some description here", Status=Status.Modified, StackId = stacks[0].Id},
				new Record{ Name = "Fix all bugs", Description="Some description here", Status=Status.Active, StackId = stacks[0].Id},
				new Record{ Name = "Meeting at Akadem", Description = "Meeting starts at 10:00 on the building", StackId = stacks[0].Id},
				new Record{ Name = "Buy bread at the shop", Description="Go to the Silpo after work and buy some bread", StackId = stacks[0].Id},
				new Record{ Name = "Visit a doctor", Description="Some description here", Status=Status.Active, StackId = stacks[0].Id},
				new Record{ Name = "Bring my laptop to the work", Description="Some description here", Status=Status.Deleted, StackId = stacks[0].Id},
				new Record{ Name = "Create a report", Description="Some description here", Status=Status.Modified, StackId = stacks[0].Id},
				new Record{ Name = "Fix all bugs", Description="Some description here", Status=Status.Active, StackId = stacks[0].Id},
			};
			foreach (var record in records)
			{
				rRepo.AddAsync(record);
			}
		}
	}
}

