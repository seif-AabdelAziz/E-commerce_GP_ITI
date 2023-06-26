using E_Commerce.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerManager _customerManger;
        
        public CustomerController(ICustomerManager customerManger)
        {
            _customerManger = customerManger;
        }

        [HttpGet]
        public ActionResult<List<CustomerListDataDto>> GetAllCustomer()
        {
            List<CustomerListDataDto> customers = _customerManger.GetAllCustomers();
            return customers;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<CustomerListDataDto> GetCustomerBy(Guid Id)
        {
            CustomerListDataDto? customer = _customerManger.GetCustomerById(Id);
            return customer;
        }

        [HttpPost]
        public ActionResult AddCustomer(CustomerAddDto newCustomer)
        {
            _customerManger.AddCustomer(newCustomer);
            return StatusCode(StatusCodes.Status201Created,"Added Successfully") ;
        }


        [HttpPatch]
        [Route("RestPassword")]
        public ActionResult UpdateCustomerPassword(CustomerUpdatePassDto newCustomer)
        {
            var check = _customerManger.UpadateCustomerPassword(newCustomer);
            if (check)
            {
                return StatusCode(StatusCodes.Status201Created, "Edit Successfully");
            }
            return StatusCode(StatusCodes.Status304NotModified, "Reset Faild");
        }




    }
}
