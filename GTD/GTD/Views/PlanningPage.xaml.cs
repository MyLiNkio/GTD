using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTD.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GTD
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PlanningPage : ContentPage
	{
		public PlanningPage (PeriodType stackType)
		{
			BindingContext = new StacksViewModel(stackType); 
			//SetBinding(Page.TitleProperty, new Binding("Title"));
			InitializeComponent();
		}
	}
}