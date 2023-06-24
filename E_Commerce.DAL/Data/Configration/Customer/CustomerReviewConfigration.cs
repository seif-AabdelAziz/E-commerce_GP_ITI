using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL.Data.configration.Customer
{
    public class CustomerReviewConfigration : IEntityTypeConfiguration<CustomerReview>
    {
        public void Configure(EntityTypeBuilder<CustomerReview> builder)
        {
            builder.HasKey("CustomerId", "ProductId");
        }
    }
}
