using E_Commerce.BL;
using E_Commerce.DAL;
using Microsoft.AspNetCore.Authorization;
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
        private readonly UserManager<Customer> _customer;

        public CustomerController(ICustomerManager customerManger, UserManager<Customer> customer)
        {
            _customerManger = customerManger;
            _customer = customer;
        }

        [HttpGet]

        public ActionResult<List<CustomerListDataDto>> GetAllCustomer()
        {
            List<CustomerListDataDto> customers = _customerManger.GetAllCustomers();
            return customers;
        }

        [HttpGet]
        [Route("GetByOne")]
        public ActionResult<CustomerListDataDto> GetCustomerBy()
        {
            Guid id =new Guid(_customer.GetUserAsync(User).Result.Id);
            CustomerListDataDto? customer = _customerManger.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
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

        [HttpPatch("{id}")]
        public ActionResult UpdateCustomerData(Guid id,CustomerUpdateDto updateCustomer)
        {


            if (id != updateCustomer.Id) {

                return BadRequest();
            }
            var check = _customerManger.UpdateCustomerData(updateCustomer);
            if (check)
            {
                return Ok();
            }
            return BadRequest();
        }


        [HttpDelete]
        public ActionResult DeleteCustomer(CustomerDeleteDto customer)
        {
            var check = _customerManger.DeleteCustomerById(customer);
            if (check)
            {
                return StatusCode(StatusCodes.Status201Created, "Deleted Successfully");
            }
            return StatusCode(StatusCodes.Status304NotModified, "Deleted Faild");
        }




    }
}
