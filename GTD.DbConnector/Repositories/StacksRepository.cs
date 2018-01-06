using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GTD.Repositories;
using GTD.Models;

namespace GTD.DbConnector.Repositories
{
	public class StacksRepository : IRepository<Stack>
	{
		private readonly DatabaseContext _dbContext;


		public StacksRepository(string dbPath)
		{
			_dbContext = new DatabaseContext(dbPath);
		}

		public async Task<IEnumerable<Stack>> GetAsync()
		{
			try
			{
				var result = await _dbContext.Stacks.Include("Records").ToListAsync();
				return result;
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public async Task<Stack> GetByIdAsync(int id)
		{
			try
			{
				var result = await _dbContext.Stacks.FindAsync(id);
				return result;
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public async Task<bool> AddAsync(Stack data)
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

		public async Task<bool> UpdateAsync(Stack data)
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
				var result = await _dbContext.Stacks.FindAsync(id);
				var tracking = _dbContext.Remove(result);
				await _dbContext.SaveChangesAsync();
				return tracking.State == EntityState.Deleted;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public async Task<IEnumerable<Stack>> QueryAsync(Func<Stack, bool> predicate)
		{
			try
			{
				var result = _dbContext.Stacks.Include("Records").Where(predicate);
				return result.ToList();
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}
