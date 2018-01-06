using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTD.Repositories
{
    public interface IRepository<T>
    {
		Task<IEnumerable<T>> GetAsync();

		Task<T> GetByIdAsync(int id);

		Task<bool> AddAsync(T entity);

		Task<bool> UpdateAsync(T entity);

		Task<bool> RemoveAsync(int id);

		Task<IEnumerable<T>> QueryAsync(Func<T, bool> predicate);
	}
}
