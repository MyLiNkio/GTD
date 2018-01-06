using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GTD.Repositories;
using GTD.Models;

namespace GTD.DbConnector.Repositories
{
	public class ProductsRepository : IRepository<Product>
	{
		private readonly DatabaseContext _dbContext;


		public ProductsRepository(string dbPath)
		{
			_dbContext = new DatabaseContext(dbPath);
		}

		public async Task<IEnumerable<Product>> GetAsync()
		{
			try
			{
				var result = await _dbContext.Products.ToListAsync();
				return result;
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public async Task<Product> GetByIdAsync(int id)
		{
			try
			{
				var result = await _dbContext.Products.FindAsync(id);
				return result;
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public async Task<bool> AddAsync(Product data)
		{
			try
			{
				var tracking = await _dbContext.AddAsync(data);
				await _dbContext.SaveChangesAsync();
				return tracking.State == EntityState.Added;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public async Task<bool> UpdateAsync(Product data)
		{
			try
			{
				var tracking = _dbContext.Update(data);
				await _dbContext.SaveChangesAsync();
				return tracking.State == EntityState.Modified;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public async Task<bool> RemoveAsync(int id)
		{
			try
			{
				var result = await _dbContext.Products.FindAsync(id);
				var tracking = _dbContext.Remove(result);
				await _dbContext.SaveChangesAsync();
				return tracking.State == EntityState.Deleted;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public async Task<IEnumerable<Product>> QueryAsync(Func<Product, bool> predicate)
		{
			try
			{
				var result = _dbContext.Products.Where(predicate);
				return result.ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}
