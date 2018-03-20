using GTD.Interfaces;
using GTD.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GTD
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StacksCarousel : CarouselPage
	{
		public StacksCarousel(StackType stackType)
		{
			InitializeComponent();

			var visiblePage = new DailyPage();

			Children.Add(new DailyPage(-1));
			Children.Add(visiblePage);
			Children.Add(new DailyPage(1));

			CurrentPage = visiblePage;

			Title = CurrentPage.Title;
		}

		protected override void OnCurrentPageChanged()
		{
			var index = GetIndex(CurrentPage);
			Title = CurrentPage.Title;
			var page = CurrentPage as IStackPage;
			if (page != null)
			{
				var periodsOffset = page.PeriodsOffset;
			}
		}
	}
}