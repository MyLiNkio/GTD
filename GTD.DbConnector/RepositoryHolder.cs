using GTD.DbConnector.Repositories;
using GTD.Models;
using GTD.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace GTD.DbConnector
{
    public class RepositoryHolder: IRepositoryHolder
    {
		private Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

		public RepositoryHolder(string dbPath)
		{
			_repositories.Add(typeof(Product), new ProductsRepository(dbPath));
			_repositories.Add(typeof(Record), new RecordsRepository(dbPath));
			_repositories.Add(typeof(Stack), new StacksRepository(dbPath));
			_repositories.Add(typeof(Category), new CategoriesRepository(dbPath));
		}

		public IRepository<T> GetRepository<T>()
		{
			object result;
			if (_repositories.TryGetValue(typeof(T), out result))
				return result as IRepository<T>;
			return null;
		}
    }
}
