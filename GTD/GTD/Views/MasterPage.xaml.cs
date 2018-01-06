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
			var stackRepo = Global.RepositoryHolder.GetRepository<Stack>();
			if (stackRepo != null)
			{
				var stacks = stackRepo.GetAsync().Result;
				Data = new List<MasterPageItem>();
				Data.Add(new MasterPageItem { Title = "Inbox", TargetType = typeof(PlanningPage), PeriodType = PeriodType.None});

				var dailyStack = stacks.FirstOrDefault(x => x.Type == PeriodType.Daily && x.StartDate == DateTime.Today);
				if (dailyStack != null)
					Data.Add(new MasterPageItem { Title = dailyStack.Type.ToString(), TargetType = typeof(DailyPage), PeriodType = PeriodType.Daily });

				var weeklyStack = stacks.FirstOrDefault(x => x.Type == PeriodType.Weekly && x.StartDate.Year == DateTime.Today.Year && CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(x.StartDate, CalendarWeekRule.FirstDay, Global.FirsDayOfWeek) == CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, Global.FirsDayOfWeek));
				if (weeklyStack != null)
					Data.Add(new MasterPageItem { Title = weeklyStack.Type.ToString(), TargetType = typeof(PlanningPage), PeriodType = PeriodType.Weekly });

				var monthlyStack = stacks.FirstOrDefault(x => x.Type == PeriodType.Monthly && x.StartDate.Month == DateTime.Today.Month && x.StartDate.Year == DateTime.Today.Year);
				if (monthlyStack != null)
					Data.Add(new MasterPageItem { Title = monthlyStack.Type.ToString(), TargetType = typeof(PlanningPage), PeriodType = PeriodType.Monthly });

				var yearlyStack = stacks.FirstOrDefault(x => x.Type == PeriodType.Yearly && x.StartDate.Year == DateTime.Today.Year);
				if (yearlyStack!= null)
					Data.Add(new MasterPageItem { Title = yearlyStack.Type.ToString(), TargetType = typeof(PlanningPage), PeriodType = PeriodType.Yearly });

				Data.Add(new MasterPageItem { Title = yearlyStack.Type.ToString(), TargetType = typeof(PlanningPage), PeriodType = PeriodType.Yearly });

				Data.Add(new MasterPageItem { Title = yearlyStack.Type.ToString(), TargetType = typeof(PlanningPage), PeriodType = PeriodType.Yearly });

				Data.Add(new MasterPageItem { Title = yearlyStack.Type.ToString(), TargetType = typeof(PlanningPage), PeriodType = PeriodType.Yearly });
			}
			BindingContext = this;
			SetBinding(Page.TitleProperty, new Binding("Title"));
			InitializeComponent ();
		}
	}
}