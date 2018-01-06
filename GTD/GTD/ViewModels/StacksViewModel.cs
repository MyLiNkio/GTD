using GTD.Models;
using GTD.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GTD
{
	public class StacksViewModel : INotifyPropertyChanged
	{
		private readonly IRepository<Stack> _stacksRep = Global.RepositoryHolder.GetRepository<Stack>();
		private IEnumerable<Record> _records;
		private PeriodType _periodType;

		public string Title
		{
			get
			{
				if (_periodType == PeriodType.None)
					return "Inbox";
				return _periodType.ToString();
			}
		}

		public IEnumerable<Record> Records
		{
			get { return _records; }
			set { _records = value; OnPropertyChanged(); }
		}

		//public double RecordPrice { get; set; }

		//public string RecordTitle { get; set; }

		//public ICommand RefreshCommand
		//{
		//	get {
		//		return new Command(async () =>
		//		  {
		//			  Records = await _repository.GetAsync();
		//		  });
		//	}
		//}

		//public ICommand AddCommand
		//{
		//	get
		//	{
		//		return new Command(async () =>
		//		{
		//			var Record = new Record { Title = RecordTitle, Price = RecordPrice };
		//			await _repository.AddAsync(Record);
		//		});
		//	}
		//}

		public StacksViewModel(PeriodType periodType)
		{
			_periodType = periodType;
			var stacks = _stacksRep.QueryAsync(x => x.Type == _periodType).Result;
			if (stacks != null && stacks.Any(x => x != null))
			{
				var stack = stacks.First();
				_records = stack.Records;
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
