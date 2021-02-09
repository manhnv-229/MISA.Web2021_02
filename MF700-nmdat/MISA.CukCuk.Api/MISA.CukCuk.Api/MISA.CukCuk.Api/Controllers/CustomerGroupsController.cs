using Microsoft.AspNetCore.Mvc;
using MISA.Common.Model;
using MISA.Service;
using MISA.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Api.Controllers
{
   
    public class CustomerGroupsController : BasesController<CustomerGroup>
    {
       public CustomerGroupsController(ICustomerGroupService _customerGroupService) : base(_customerGroupService)
        {

        }
    }
}
