using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTD.Models
{
	public class Category
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get;set; }

		public Status Status { get; set; }

		public DateTime Created { get; set; }

		public DateTime Updated { get; set; }


		public ICollection<Record> Records { get; set; }
    }
}
