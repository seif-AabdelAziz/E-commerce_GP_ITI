using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL.Data.Configration.Customer
{
    public class CustomerPhonesConfiguration : IEntityTypeConfiguration<CustomerPhones>
    {
        public void Configure(EntityTypeBuilder<CustomerPhones> builder)
        {
            builder.HasKey("CustomerId", "PhoneNumber");
        }
    }
}
