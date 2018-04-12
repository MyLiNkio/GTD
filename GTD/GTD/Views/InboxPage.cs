using GTD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GTD
{
	public class InboxPage: ContentPage
	{
		private ListView listView;

		public InboxPage()
		{
			BindingContext = new DailyRecordsViewModel(0);
			SetBinding(Page.TitleProperty, new Binding("Title"));

			listView = new ListView { RowHeight = 40 };
			listView.SetBinding(ListView.ItemsSourceProperty, "Records");
			listView.ItemTemplate = new DataTemplate(typeof(TodoItemCell));
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

			var layout = new StackLayout();
			layout.Children.Add(listView);
			layout.VerticalOptions = LayoutOptions.FillAndExpand;
			Content = layout;
		}
	}
}
