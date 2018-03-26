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

			//listView.ItemTemplate = new DataTemplate(() => { return BuildListItem(); });
			//listView.ItemTemplate = new DataTemplate(() => xxxxxxx);
			listView.ItemTemplate = new DataTemplate(typeof(TodoItemCell));
			listView.RowHeight = 60;
			listView.ItemSelected += (sender, e) => {
				var todoItem = (Record)e.SelectedItem;
				
				var todoPage = new RecordPage();				
				todoPage.BindingContext = todoItem;
				Navigation.PushAsync(todoPage);
			};

			var tbiAdd = new ToolbarItem("+", "plus.png", () =>
			{
				var todoItem = new Record();
				var todoPage = new RecordPage();
				todoPage.BindingContext = todoItem;
				Navigation.PushAsync(todoPage);
			}, 0, 0);

			ToolbarItems.Add(tbiAdd);
		}
		
		public DailyPage(StackType periodType, int periodOffset) :this(periodOffset)
		{
		}

		//public static ViewCell BuildListItem()
		//{
		//	var title = new Label();
		//	title.Text = "test";
		//	//title.SetBinding(Label.TextProperty, "Name");

		//	var start_stop_btn = new Button { Text = "Start" };
		//	start_stop_btn.FontSize = 8;//Device.GetNamedSize(NamedSize.Micro, typeof(Button));
		//	start_stop_btn.WidthRequest = 50;
		//	start_stop_btn.HeightRequest = 30;
		//	//start_stop_btn.HorizontalOptions = LayoutOptions.Start;
		//	//start_stop_btn.VerticalOptions = LayoutOptions.Start;

		//	var postpone_btn = new Button { Text = "Postpone" };
		//	postpone_btn.WidthRequest = 100;
		//	postpone_btn.HeightRequest = 30;
		//	postpone_btn.FontSize = 8;// Device.GetNamedSize(NamedSize.Micro, typeof(Button));
		//							  //postpone_btn.HorizontalOptions = LayoutOptions.Center;
		//							  //postpone_btn.VerticalOptions = LayoutOptions.Center;

		//	var done_btn = new Button { Text = "Done" };
		//	done_btn.WidthRequest = 50;
		//	done_btn.HeightRequest = 32;
		//	done_btn.FontSize = 8;// Device.GetNamedSize(NamedSize.Micro, typeof(Button));
		//						  //done_btn.HorizontalOptions = LayoutOptions.End;
		//						  //done_btn.VerticalOptions = LayoutOptions.End;

		//	var stack = new StackLayout
		//	{
		//		Spacing = 0,
		//		Orientation = StackOrientation.Horizontal,
		//		BackgroundColor = Color.Yellow,
		//		HeightRequest = 36,
		//		HorizontalOptions = LayoutOptions.CenterAndExpand,
		//		VerticalOptions = LayoutOptions.CenterAndExpand,
		//	};

		//	stack.Children.Add(start_stop_btn);
		//	stack.Children.Add(postpone_btn);
		//	stack.Children.Add(done_btn);

		//	var listGrid = new Grid();
		//	listGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
		//	listGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
		//	//listGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
		//	//listGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
		//	//listGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

		//	listGrid.Children.Add(title, 0, 0);
		//	listGrid.Children.Add(stack, 0, 1);
		//	//listGrid.Children.Add(start_stop_btn, 0, 2);
		//	//listGrid.Children.Add(postpone_btn, 0, 3);
		//	//listGrid.Children.Add(done_btn, 0, 4);

		//	return new ViewCell { View = listGrid };
		//}

	}
}