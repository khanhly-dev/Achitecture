using Achitecture.Domain.Entities;
using Achitecture.Infrastructure.Persistence.EntityFrameworkCore.Configuration;
using Achitecture.Infrastructure.Persistence.EntityFrameworkCore.Interceptors;
using Achitecture.Repository.Common.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Achitecture.Infrastructure.Persistence.EntityFrameworkCore
{
    public class ApplicationDbContext : DbContext
    {
        private readonly AuditableEntitySaveChangesInterceptor _auditableEntitySaveChangesInterceptor;
        public ApplicationDbContext(DbContextOptions<
            ApplicationDbContext> options,
            AuditableEntitySaveChangesInterceptor auditableEntitySaveChangesInterceptor) : base(options) 
        {
            _auditableEntitySaveChangesInterceptor = auditableEntitySaveChangesInterceptor;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // add configuration file in "EntityConfiguration" folder
            // class must be implement interface "IEntityTypeConfiguration<TEntity>"
            // register class config in extension method ConfigEntity
            modelBuilder.ConfigEntity();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_auditableEntitySaveChangesInterceptor);
        }

        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<Product> Product { get; set; }
    }
}
