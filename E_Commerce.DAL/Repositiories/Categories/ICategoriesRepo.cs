﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL;

public interface ICategoriesRepo:IGenericRepo<Category>
{


    List<Product> GetProductsForCategory (int id);





}
