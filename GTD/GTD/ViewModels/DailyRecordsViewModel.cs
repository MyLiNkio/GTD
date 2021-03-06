﻿using GTD.Models;
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
	public class DailyRecordsViewModel : INotifyPropertyChanged
	{
		private readonly IRepository<Record> _recordsRep = Global.RepositoryHolder.GetRepository<Record>();
		private readonly IRepository<Stack> _stacksRep = Global.RepositoryHolder.GetRepository<Stack>();
		private IEnumerable<Record> _records;
		private DateTime _date = DateTime.Today;
		private int _periodsOffset = 0;

		public int PeriodsOffset {
			get { return _periodsOffset; }
		}

		public string Title
		{
			get
			{
				if (_date == DateTime.Today)
					return "Today";
				return $"{_date.ToString("dd MMM yyyy")}";
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

		public DailyRecordsViewModel(int periodsOffset)
		{
			_periodsOffset = periodsOffset;
			_date  = _date.AddDays(periodsOffset);

			var stacks = _stacksRep.QueryAsync(x => x.Type == StackType.Day && x.StartDate == _date).Result;
			if (stacks != null && stacks.Any(x=>x != null))
			{
				var stack = stacks.First();
				_records = stack.Records;// _recordsRep.QueryAsync(x => x.StackId == stack.Id).Result;
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
