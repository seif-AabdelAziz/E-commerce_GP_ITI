using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL;

public class OrderProdctConfig : IEntityTypeConfiguration<OrderProdct>
{
    public void Configure(EntityTypeBuilder<OrderProdct> builder)
    {
        builder.HasKey(op => new { op.ProductId, op.OrderId });

        builder.HasOne(op => op.Product).WithMany().HasForeignKey(op => op.ProductId);
        builder.HasOne(op => op.Order).WithMany().HasForeignKey(op => op.OrderId);

        //builder.Property(op => op.ProductCount).IsRequired();
    }
}
