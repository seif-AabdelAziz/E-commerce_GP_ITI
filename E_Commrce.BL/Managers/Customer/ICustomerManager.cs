﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL
{
    public interface ICustomerManager
    {
        List<CustomerListDataDto> GetAllCustomers();
        CustomerListDataDto? GetCustomerById(Guid Id);
        void AddCustomer (CustomerAddDto customer);

        bool UpadateCustomerPassword (CustomerUpdatePassDto customer);
    }
}