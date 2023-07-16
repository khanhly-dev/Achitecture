using Achitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Achitecture.Infrastructure.Persistence.EntityFrameworkCore.Configuration.EntityConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(e => e.CategoryId).IsRequired();
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Code).IsRequired();
            builder.Property(e => e.Publish).IsRequired();
        }
    }
}
