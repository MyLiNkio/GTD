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
			var nameEntry = new Entry();

			nameEntry.SetBinding(Entry.TextProperty, "Name");

			var decriptionLabel = new Label(); // no Text! localized later
			var descriptionEntry = new Entry();
			descriptionEntry.SetBinding(Entry.TextProperty, "Description");

			var startDateLabel = new Label(); // no Text! localized later
			var startDatePicker = new DatePicker();
			startDatePicker.SetBinding(DatePicker.DateProperty, "StartDate");

			var dueToDateLabel = new Label(); // no Text! localized later
			var dueToDatePicker = new DatePicker();
			dueToDatePicker.SetBinding(DatePicker.DateProperty, "StartDate");

			var estimationLabel = new Label(); // no Text! localized later
			var estimationEntry = new Entry();
			estimationEntry.SetBinding(Switch.IsToggledProperty, "EstimationTime");

			var doneLabel = new Label(); // no Text! localized later
			var doneEntry = new Switch();
			doneEntry.SetBinding(Switch.IsToggledProperty, "IsFinished");

			var saveButton = new Button(); // no Text! localized later
			saveButton.Clicked += (sender, e) => {
				var todoItem = (Record)BindingContext;
				//App.Database.SaveItem(todoItem);
				this.Navigation.PopAsync();
			};

			var deleteButton = new Button(); // no Text! localized later
			deleteButton.Clicked += (sender, e) => {
				var todoItem = (Record)BindingContext;
				//App.Database.DeleteItem(todoItem.ID);
				this.Navigation.PopAsync();
			};

			var cancelButton = new Button(); // no Text! localized later
			cancelButton.Clicked += (sender, e) => {
				this.Navigation.PopAsync();
			};

			var speakButton = new Button(); // no Text! localized later
			speakButton.Clicked += (sender, e) => {
				var todoItem = (Record)BindingContext;
				//DependencyService.Get<ITextToSpeech>().Speak(todoItem.Name + " " + todoItem.Notes);
			};


			// TODO: Forms Localized text using two different methods:

			// refer to the codebehind for AppResources.resx.designer
			nameLabel.Text = "Name";// AppResources.NameLabel;
			decriptionLabel.Text = "Description";// AppResources.NotesLabel;
			startDateLabel.Text = "Start date";
			dueToDateLabel.Text = "Due to (not required)";
			estimationLabel.Text = "Estimation (minutes)";
			doneLabel.Text = "Done";// AppResources.DoneLabel;

			// using ResourceManager
			saveButton.Text = "Save";// AppResources.SaveButton;
			deleteButton.Text = "Delete";// L10n.Localize("DeleteButton", "Delete");
			cancelButton.Text = "Cancel";// L10n.Localize("CancelButton", "Cancel");
			speakButton.Text = "Speak";// L10n.Localize("SpeakButton", "Speak");
			
			var stack = new StackLayout
			{
				VerticalOptions = LayoutOptions.StartAndExpand,
				Padding = new Thickness(5),
				Spacing = 2,
				Children = {
					nameLabel, nameEntry,
					decriptionLabel, descriptionEntry,
					startDateLabel, startDatePicker,
					dueToDateLabel, dueToDatePicker,
					estimationLabel, estimationEntry,
					doneLabel, doneEntry,
					saveButton, deleteButton, cancelButton, speakButton
				}
			};

			Content = new ScrollView { Content = stack };
		}
	}
}
