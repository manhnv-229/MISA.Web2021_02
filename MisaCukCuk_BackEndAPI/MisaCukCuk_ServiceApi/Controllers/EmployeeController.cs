using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MisaCukCuk_ApplicationCore.ApplicationCore.EmployeeApplicationCore;
using MisaCukCuk_Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MisaCukCuk_ServiceApi.Controllers
{
    public class EmployeeController : BaseController<Employee>
    {
        IEmployeeApplicationCore _emp;
        public EmployeeController(IEmployeeApplicationCore employeeApplicationCore) : base(employeeApplicationCore)
        {
            _emp = employeeApplicationCore;
        }
    }
}
