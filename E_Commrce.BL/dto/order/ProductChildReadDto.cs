using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL
{
    public class ProductChildReadDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; } 
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public double Discount { get; set; }
    }
}
