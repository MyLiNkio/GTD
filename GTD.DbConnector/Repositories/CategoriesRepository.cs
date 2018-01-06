using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GTD.Repositories;
using GTD.Models;

namespace GTD.DbConnector.Repositories
{
	public class CategoriesRepository : IRepository<Category>
	{
		private readonly DatabaseContext _dbContext;


		public CategoriesRepository(string dbPath)
		{
			_dbContext = new DatabaseContext(dbPath);
		}

		public async Task<IEnumerable<Category>> GetAsync()
		{
			try
			{
				var result = await _dbContext.Categories.ToListAsync();
				return result;
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public async Task<Category> GetByIdAsync(int id)
		{
			try
			{
				var result = await _dbContext.Categories.FindAsync(id);
				return result;
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public async Task<bool> AddAsync(Category data)
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

		public async Task<bool> UpdateAsync(Category data)
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
				var result = await _dbContext.Categories.FindAsync(id);
				var tracking = _dbContext.Remove(result);
				await _dbContext.SaveChangesAsync();
				return tracking.State == EntityState.Deleted;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public async Task<IEnumerable<Category>> QueryAsync(Func<Category, bool> predicate)
		{
			try
			{
				var result = _dbContext.Categories.Where(predicate);
				return result.ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}
