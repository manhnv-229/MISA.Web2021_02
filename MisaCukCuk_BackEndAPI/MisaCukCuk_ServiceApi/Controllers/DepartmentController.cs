using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MisaCukCuk_ApplicationCore.ApplicationCore.DepartmentApplicationCore;
using MisaCukCuk_Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MisaCukCuk_ServiceApi.Controllers
{
    public class DepartmentController : BaseController<Department>
    {
        IDepartmentApplicationCore _code;
        public DepartmentController(IDepartmentApplicationCore departmentApplicationCore) : base(departmentApplicationCore)
        {
            _code = departmentApplicationCore;
        }
    }
}
