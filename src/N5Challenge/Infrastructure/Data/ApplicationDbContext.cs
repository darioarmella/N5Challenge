﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions options) : base(options) { }

		public DbSet<Permission> Permissions { get; set; }
	}
}
