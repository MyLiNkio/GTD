using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GTD
{
	public partial class MainPage : MasterDetailPage
	{
		public MainPage()
		{
			InitializeComponent();
			//IsGestureEnabled = false;

			//if (Device.RuntimePlatform != Device.iOS)
			//{
			//	TapGestureRecognizer tap = new TapGestureRecognizer();
			//	//tap.Tapped += (sender, args) => {
			//	//	if (!IsGestureEnabled)
			//	//		IsPresented = true;
			//	//	if (IsGestureEnabled)
			//	//		IsPresented = true;
			//	//};
			//	tap.Tapped += OnItemSelected;
				
			//	masterPage.Content.BackgroundColor = Color.Transparent;
			//	masterPage.Content.GestureRecognizers.Add(tap);
			//}

			masterPage.ListView.ItemSelected += OnItemSelected;

			if (Device.RuntimePlatform == Device.UWP)
			{
				MasterBehavior = MasterBehavior.Popover;
			}
		}

		void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var item = e.SelectedItem as MasterPageItem;
			if (item != null)
			{
				//var content = new StacksCarousel(Models.StackType.Day, 1);
				var content = (Page)Activator.CreateInstance(item.TargetType, item.PeriodType);
				Detail = new NavigationPage(content);

				masterPage.ListView.SelectedItem = null;
				IsPresented = false;
			}
		}		
	}
}
