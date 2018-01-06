using GTD;
using GTD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace GTD.DbConnector
{
    public class DatabaseContext : DbContext
    {
		public DbSet<Product> Products { get; set; }
		public DbSet<Record> Records { get; set; }
		public DbSet<Stack> Stacks { get; set; }
		public DbSet<Category> Categories { get; set; }

		private readonly string _databasePath;

		public DatabaseContext(string dbPath)
		{
			_databasePath = dbPath;
			Database.EnsureCreated();
		}
		
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite($"Filename={_databasePath}");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Stack>()
				.HasMany(c => c.Records)
				.WithOne(e => e.Stack);
		}
	}
}
