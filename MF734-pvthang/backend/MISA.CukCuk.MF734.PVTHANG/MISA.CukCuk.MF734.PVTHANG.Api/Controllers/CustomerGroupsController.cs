using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.MF734.PVTHANG.Common.Models;
using MISA.CukCuk.MF734.PVTHANG.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.MF734.PVTHANG.Api.Controllers
{
    public class CustomerGroupsController : BaseController<CustomerGroup>
    {
        public CustomerGroupsController(ICustomerGroupService customerGroupService) : base(customerGroupService)
        {

        }
    }
}
