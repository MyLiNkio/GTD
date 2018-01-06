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
	public partial class DailyPage : ContentPage
	{
		public DailyPage ()
		{
			BindingContext = new DailyRecordsViewModel();
			//SetBinding(Page.TitleProperty, new Binding("Title"));
			InitializeComponent();
		}

		public DailyPage(PeriodType periodType):this()
		{
		}
	}
}