using GTD.Interfaces;
using GTD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GTD
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DailyPage : ContentPage, IStackPage
	{
		private int _periodsOffset;
		public int PeriodsOffset
		{
			get { return _periodsOffset; }
			set { _periodsOffset = value; }
		}

		public DailyPage():this(0)
		{
		}

		public DailyPage (int periodsOffset)
		{
			_periodsOffset = periodsOffset;
			BindingContext = new DailyRecordsViewModel(_periodsOffset);
			SetBinding(Page.TitleProperty, new Binding("Title"));

			InitializeComponent();

			listView.ItemTemplate = new DataTemplate(() => { return BuildListItem(); });
			//listView.ItemTemplate = new DataTemplate(() =>
			//);

		}
		public static ViewCell BuildListItem()
		{
			var title = new Label();
			title.Text = "test";
			//title.SetBinding(Label.TextProperty, "Name");

			var start_stop_btn = new Button { Text = "Done" };
			start_stop_btn.FontSize = 8;// Device.GetNamedSize(NamedSize.Small, typeof(Button));
			start_stop_btn.WidthRequest = 50;
			start_stop_btn.HeightRequest = 30;
			start_stop_btn.HorizontalOptions = LayoutOptions.End;
			//start_stop_btn.VerticalOptions = LayoutOptions.Start;

			var postpone_btn = new Button { Text = "Done" };
			postpone_btn.WidthRequest = 50;
			postpone_btn.HeightRequest = 30;
			postpone_btn.FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Button));
			postpone_btn.HorizontalOptions = LayoutOptions.End;
			//postpone_btn.VerticalOptions = LayoutOptions.Center;

			var done_btn = new Button { Text = "Done" };
			done_btn.WidthRequest = 50;
			done_btn.HeightRequest = 30;
			done_btn.FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Button));
			//done_btn.HorizontalOptions = LayoutOptions.End;
			//done_btn.VerticalOptions = LayoutOptions.End;

			var stack = new StackLayout
			{
				//Padding = new Thickness(10, 10, 0, 10),
				Spacing = 5,
				Orientation = StackOrientation.Vertical,
				BackgroundColor = Color.Yellow,
				//HorizontalOptions = LayoutOptions.FillAndExpand,
				//VerticalOptions = LayoutOptions.FillAndExpand,
			};

			stack.Children.Add(start_stop_btn);
			stack.Children.Add(postpone_btn);
			stack.Children.Add(done_btn);

			var listGrid = new Grid();
			listGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
			listGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
			listGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
			listGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
			listGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

			listGrid.Children.Add(title, 0, 0);
			//listGrid.Children.Add(stack, 0, 1);
			listGrid.Children.Add(start_stop_btn, 0, 2);
			listGrid.Children.Add(postpone_btn, 0, 3);
			listGrid.Children.Add(done_btn, 0, 4);

			return new ViewCell { View = listGrid };
		}


		public DailyPage(StackType periodType, int periodOffset) :this(periodOffset)
		{
		}

		private void Btn_Clicked(object sender, EventArgs e)
		{
			var btn = sender as Button;
			if (btn.Image.File.Contains("unchecked"))
				btn.Image.File = "checkbox_checked.png";
			else
				btn.Image.File = "checkbox_unchecked.png";
		}

		private void Btn2_Clicked(object sender, EventArgs e)
		{
			var btn = sender as Button;
			btn.ContentLayout = new Button.ButtonContentLayout(Button.ButtonContentLayout.ImagePosition.Left, 0);
		}
	}
}