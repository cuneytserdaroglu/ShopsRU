using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ShopsRUs.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUs.Repository.Repositories.EntityFramework.Configurations
{
    internal class CustomerTypeConfiguration : IEntityTypeConfiguration<CustomerType>
    {
        public void Configure(EntityTypeBuilder<CustomerType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.ToTable("CustomerTypes");
            //builder.Property(x => x.Stock).IsRequired();

            //builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)");


            //builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);
        }
    }
}
