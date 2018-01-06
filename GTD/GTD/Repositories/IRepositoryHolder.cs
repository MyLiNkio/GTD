using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTD.Repositories
{
    public interface IRepositoryHolder
    {
		IRepository<T> GetRepository<T>();
	}
}
