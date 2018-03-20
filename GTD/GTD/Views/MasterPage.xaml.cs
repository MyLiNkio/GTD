using GTD.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GTD
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterPage : ContentPage
	{
		public ListView ListView { get { return listView; } }

		public List<MasterPageItem> Data { get; set; }

		public string Title = "Custom title";

		public MasterPage ()
		{
			Data = new List<MasterPageItem>();
			Data.Add(new MasterPageItem { Title = "Inbox", TargetType = typeof(PlanningPage), PeriodType = StackType.None});
			Data.Add(new MasterPageItem { Title = "Daily stack", TargetType = typeof(StacksCarousel), PeriodType = StackType.Day });
			Data.Add(new MasterPageItem { Title = "Weekly stack", TargetType = typeof(PlanningPage), PeriodType = StackType.Week });
			Data.Add(new MasterPageItem { Title = "Monthly stack", TargetType = typeof(PlanningPage), PeriodType = StackType.Month });
			Data.Add(new MasterPageItem { Title = "Planning", TargetType = typeof(PlanningPage), PeriodType = StackType.Month });

			//var dailyStack = stacks.FirstOrDefault(x => x.Type == PeriodType.Daily && x.StartDate == DateTime.Today);
			//var weeklyStack = stacks.FirstOrDefault(x => x.Type == PeriodType.Weekly && x.StartDate.Year == DateTime.Today.Year && CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(x.StartDate, CalendarWeekRule.FirstDay, Global.FirsDayOfWeek) == CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, Global.FirsDayOfWeek));
			//var monthlyStack = stacks.FirstOrDefault(x => x.Type == PeriodType.Monthly && x.StartDate.Month == DateTime.Today.Month && x.StartDate.Year == DateTime.Today.Year);

			BindingContext = this;
			SetBinding(Page.TitleProperty, new Binding("Title"));
			InitializeComponent ();

			//<Image Source="{Binding IconSource}" WidthRequest="20" HeightRequest="20" VerticalOptions="Center" />
			//<Label Text="{Binding Title}" FontSize="Small" VerticalOptions="Center" TextColor="Black"/>
			//<Label Text="{Binding Test.Test}" FontSize="Small" VerticalOptions="Center" TextColor="Black"/>

			//listView.ItemTemplate = new DataTemplate(()=> 
			//{ 
			//	var image = new Image();
			//	image.SetBinding(Image.SourceProperty, "IconSource");

			//	var labelTitle = new Label();
			//	labelTitle.SetBinding(Label.TextProperty, "Title");

			//	var labelTest = new Label();
			//	labelTest.SetBinding(Label.TextProperty, "Test.Test");

			//	var viewCellStack = new StackLayout
			//	{
			//		Padding = new Thickness(10, 10, 0, 10),
			//		Spacing = 5,
			//		Orientation = StackOrientation.Horizontal,
			//		VerticalOptions = LayoutOptions.FillAndExpand,
			//	};

			//	viewCellStack.Children.Add(image);
			//	viewCellStack.Children.Add(labelTitle);
			//	viewCellStack.Children.Add(labelTest);

			//	return new ViewCell{View = viewCellStack};
			//});
		}
	}
}