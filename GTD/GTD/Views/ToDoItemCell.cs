using Xamarin.Forms;

namespace GTD
{
	public class TodoItemCell : ViewCell
	{
		public TodoItemCell()
		{
			var label = new Label
			{
				VerticalTextAlignment = TextAlignment.Center
			};
			label.SetBinding(Label.TextProperty, "Name");

			var dt = new DataTrigger(typeof(Label));
			dt.Binding = new Binding("IsFinished");
			dt.Value = true;

			var setter = new Setter();
			setter.Property = Label.TextColorProperty;
			setter.Value = Color.Red;
			;
			dt.Setters.Add(setter);
			label.Triggers.Add(dt);
			
			var tick = new Image
			{
				Source = ImageSource.FromFile("check.png"),
			};
			tick.SetBinding(Image.IsVisibleProperty, "IsFinished");
			
			var layout = new StackLayout
			{
				Padding = new Thickness(20, 5, 5, 5),
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Children = { tick, label }
			};
			View = layout;
		}
	}
}
