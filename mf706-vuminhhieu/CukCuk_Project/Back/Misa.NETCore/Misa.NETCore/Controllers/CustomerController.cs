using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Misa.Common.Entities;
using Misa.Bussiness.Version1;
using System.Threading.Tasks;

namespace Misa.NETCore.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private CustomerBussiness customerBussiness;
        public CustomerController()
        {
            customerBussiness = new CustomerBussiness();
        }

        [HttpGet("")]
        public async Task<IEnumerable<Customer>> Get()
        {      
            return await customerBussiness.GetAllData();
        }

        //private DateTime? DateTime(string v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
