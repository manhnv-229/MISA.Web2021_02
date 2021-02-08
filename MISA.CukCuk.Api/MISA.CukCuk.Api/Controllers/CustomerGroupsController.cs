using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MISA.Common.Models;
using MISA.Common.Interfaces;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.CukCuk.Api.Controllers
{
    public class CustomerGroupsController : BaseController<CustomerGroup>
    {
        public CustomerGroupsController(IBaseService<CustomerGroup> baseService) : base(baseService)
        {

        }
    }
}
