using GTD.Models;
using GTD.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GTD
{
	internal class StacksCarouselViewModel: INotifyPropertyChanged
	{
		private readonly IRepository<Stack> _stacksRep = Global.RepositoryHolder.GetRepository<Stack>();
		private IEnumerable<Record> _records;
		private StackType _stackType;

		public string Title
		{
			get
			{
				if (_stackType == StackType.None)
					return "Inbox";
				return _stackType.ToString();
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

		public StacksCarouselViewModel(StackType stackType, int periodOffset)
		{
			_stackType = stackType;
			var stacks = _stacksRep.QueryAsync(x => x.Type == stackType).Result;
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
