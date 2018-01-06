using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTD.Models
{
    public class Stack
    {
		private int _periods = 1;

		public int Id { get; set; }

		public PeriodType Type { get; set; }

		public int Periods {
			get { return _periods; }
			set { if (value <= 0) _periods = 1; else _periods = value;}
		}

		public DateTime StartDate { get; set; }

		public DateTime Created { get; set; }

		public DateTime Modified { get; set; }


		public ICollection<Record> Records { get; set; }
	}

	public enum PeriodType
	{
		None,
		Daily,
		Weekly,
		Monthly,
		Yearly,
	}
}
