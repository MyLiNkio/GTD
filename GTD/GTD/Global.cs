using GTD.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTD
{
    public static class Global
    {
		public static IRepositoryHolder RepositoryHolder;

		public static DayOfWeek FirsDayOfWeek = DayOfWeek.Monday;
	}
}
