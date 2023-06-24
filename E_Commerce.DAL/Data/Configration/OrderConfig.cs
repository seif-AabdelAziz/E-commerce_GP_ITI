using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL;

public class OrderConfig : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {

        builder.HasKey(o => o.Id);
        builder.Property(o => o.Id).UseIdentityColumn();

        builder.Property(o => o.OrderData).IsRequired();

        //builder.Property(o => o.PaymentStatus).IsRequired();
        //builder.Property(o => o.Address).IsRequired();
        //builder.Property(o => o.PaymentMethod).IsRequired();
        //builder.Property(o => o.OrderStatus).IsRequired();
        //builder.Property(o => o.Discount).IsRequired();
        //builder.Property(o=>o.ArrivalDate).IsRequired();

        builder.HasOne(o => o.Customer).WithMany().HasForeignKey(o => o.CustomerId);




    }
}
