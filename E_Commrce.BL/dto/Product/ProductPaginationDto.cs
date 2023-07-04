using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL;

public class ProductPaginationDto
{

    public List<ProductDetailsReadDto> items { get; set; }= new List<ProductDetailsReadDto>();
    public int totalCount { get; set; }
}
