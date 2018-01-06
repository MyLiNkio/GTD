using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GTD.Models
{
	public class Record
	{
		public int Id { get; set; }

		public Status Status { get; set; }

		public int StackId { get; set; }

		public Stack Stack { get; set; }

		public Category Category { get; set; }


		public string Name { get; set; }

		public string Description { get; set; }

		public Progress Progress { get; set; }

		public Priority Priority { get; set; }

		public DateTime DueTo { get; set; }

		public int EstimationTime { get; set; }

		public int SpentTime { get; set; }

		public DateTime StartDate { get; set;}

		public DateTime StopDate { get; set; }

		public DateTime Created { get; set; }

		public DateTime Updated { get; set; }


		public override string ToString()
		{
			return $"({Id}) {Name}, {Status}";
		}
	}

	public enum Progress
	{
		None,
		InProgress,
		Stopped,
		Finished
	}

	public enum Priority
	{
		Low,
		Medium,
		High,
		Urgent,
	}

	public enum Status
	{
		Active,
		Modified,
		Deleted,
	}
}
