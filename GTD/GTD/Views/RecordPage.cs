using GTD.Models;
using System;
using Xamarin.Forms;

namespace GTD
{
	public class RecordPage : ContentPage
	{
		public RecordPage()
		{
			this.SetBinding(ContentPage.TitleProperty, "Name");

			NavigationPage.SetHasNavigationBar(this, true);
			var nameLabel = new Label(); // no Text! localized later
			nameLabel.VerticalOptions = LayoutOptions.End;
			var nameEntry = new Entry();
			nameEntry.Margin = 0;
			nameEntry.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Entry));
			nameEntry.SetBinding(Entry.TextProperty, "Name");

			var decriptionLabel = new Label(); // no Text! localized later
			decriptionLabel.VerticalOptions = LayoutOptions.End;
			var descriptionEntry = new Editor();
			descriptionEntry.SetBinding(Editor.TextProperty, new Binding("Description", BindingMode.TwoWay));
			descriptionEntry.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Entry));
			//descriptionEntry.SetBinding(Entry.TextProperty, "Description");

			var startDateLabel = new Label(); // no Text! localized later
			startDateLabel.VerticalOptions = LayoutOptions.End;
			var startDatePicker = new DatePicker();
			startDatePicker.SetBinding(DatePicker.DateProperty, "StartDate");

			var dueToDateLabel = new Label(); // no Text! localized later
			dueToDateLabel.VerticalOptions = LayoutOptions.End;
			var dueToDatePicker = new DatePicker();
			dueToDatePicker.HeightRequest = Device.GetNamedSize(NamedSize.Small, typeof(Entry));
			dueToDatePicker.SetBinding(DatePicker.DateProperty, "StartDate");

			var estimationLabel = new Label(); // no Text! localized later
			estimationLabel.VerticalOptions = LayoutOptions.End;
			var estimationEntry = new Entry();
			estimationEntry.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Entry));
			estimationEntry.SetBinding(Switch.IsToggledProperty, "EstimationTime");

			var doneLabel = new Label(); // no Text! localized later
			doneLabel.VerticalOptions = LayoutOptions.End;
			var doneSwitch = new Switch();
			doneSwitch.SetBinding(Switch.IsToggledProperty, "IsFinished");

			var saveButton = new Button(); // no Text! localized later
			saveButton.Clicked += (sender, e) => {
				var todoItem = (Record)BindingContext;
				//App.Database.SaveItem(todoItem);
				this.Navigation.PopAsync();
			};

			var tp = new TimePicker();

			var deleteButton = new Button(); // no Text! localized later
			deleteButton.Clicked += (sender, e) => {
				dueToDatePicker.Focus();
				tp.Focus();
				//var todoItem = (Record)BindingContext;
				//App.Database.DeleteItem(todoItem.ID);
				//this.Navigation.PopAsync();
			};

			var cancelButton = new Button(); // no Text! localized later
			cancelButton.Clicked += (sender, e) => {
				this.Navigation.PopAsync();
			};

			//var speakButton = new Button(); // no Text! localized later
			//speakButton.Clicked += (sender, e) => {
			//	var todoItem = (Record)BindingContext;
			//	//DependencyService.Get<ITextToSpeech>().Speak(todoItem.Name + " " + todoItem.Notes);
			//};


			// TODO: Forms Localized text using two different methods:

			// refer to the codebehind for AppResources.resx.designer
			nameLabel.Text = "Name";// AppResources.NameLabel;
			decriptionLabel.Text = "Description";// AppResources.NotesLabel;
			startDateLabel.Text = "Start date";
			dueToDateLabel.Text = "Due to";
			estimationLabel.Text = "Estimation (minutes)";
			doneLabel.Text = "Done";// AppResources.DoneLabel;

			// using ResourceManager
			saveButton.Text = "Save";// AppResources.SaveButton;
			deleteButton.Text = "Delete";// L10n.Localize("DeleteButton", "Delete");
			cancelButton.Text = "Cancel";// L10n.Localize("CancelButton", "Cancel");
			//speakButton.Text = "Speak";// L10n.Localize("SpeakButton", "Speak");

			//var stack = new StackLayout
			//{
			//	VerticalOptions = LayoutOptions.StartAndExpand,
			//	Padding = new Thickness(5),
			//	Spacing = 0,
			//	Children = {
			//		nameLabel, nameEntry,
			//		decriptionLabel, descriptionEntry,
			//		startDateLabel, startDatePicker,
			//		dueToDateLabel, dueToDatePicker,
			//		estimationLabel, estimationEntry,
			//		doneLabel, doneSwitch,
			//		saveButton, deleteButton, cancelButton, speakButton
			//	}
			//};

			//Content = new ScrollView { Content = stack };

			var grid = new Grid();
			grid.ColumnSpacing = 0;
			grid.RowSpacing = 0;
			grid.Padding = new Thickness(5, 0);
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
			grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
			grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(20, GridUnitType.Absolute) });//0
			grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(40, GridUnitType.Absolute) });//1
			grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(20, GridUnitType.Absolute) });//2
			grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(100, GridUnitType.Absolute) });//3
			grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(40, GridUnitType.Absolute) });//4
			grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(40, GridUnitType.Absolute) });//5
			grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(40, GridUnitType.Absolute) });//6
			grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(25, GridUnitType.Absolute) });//7
			grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50, GridUnitType.Absolute) });//8

			nameEntry.BackgroundColor = Color.LightCoral;
			descriptionEntry.BackgroundColor = Color.LightCoral;
			grid.Children.Add(nameLabel, 0, 0);
			grid.Children.Add(nameEntry, 0, 1);
			grid.Children.Add(decriptionLabel, 0, 2);
			grid.Children.Add(descriptionEntry, 0, 3);

			Grid.SetColumnSpan(nameLabel, 3);
			Grid.SetColumnSpan(nameEntry, 3);
			Grid.SetColumnSpan(decriptionLabel, 3);
			Grid.SetColumnSpan(descriptionEntry, 3);

			grid.Children.Add(startDateLabel, 0, 4);
			grid.Children.Add(startDatePicker, 2, 4);

			grid.Children.Add(dueToDateLabel, 0, 5);
			grid.Children.Add(dueToDatePicker, 2, 5);

			grid.Children.Add(estimationLabel, 0, 6);
			grid.Children.Add(estimationEntry, 2, 6);

			grid.Children.Add(doneLabel, 0, 7);
			grid.Children.Add(doneSwitch, 2, 7);

			Grid.SetColumnSpan(startDateLabel, 2);
			Grid.SetColumnSpan(dueToDateLabel, 2);
			Grid.SetColumnSpan(estimationLabel, 2);
			Grid.SetColumnSpan(doneLabel, 2);

			grid.Children.Add(saveButton, 0, 8);
			grid.Children.Add(deleteButton, 1, 8);
			grid.Children.Add(cancelButton, 2, 8);

			grid.Children.Add(tp, 2, 9);

			Content = new ScrollView { Content = grid };
		}
	}
}
