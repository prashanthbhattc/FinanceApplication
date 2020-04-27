using Fis.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Fis.Repository.Context
{/// <summary>
/// 
/// </summary>
    public class FisDataContext:DbContext
    {
        public FisDataContext(DbContextOptions<FisDataContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());//this method will configure all the classes impliments IEntityTypeConfiguration 
        }
        public DbSet<Campaign> Campaigns { set; get; }
    }
}
