using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Interface;
using MISA.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.Web.Controllers
{
    [Route("api/v1/employee-departments")]
    public class EmployeeDepartmentController : BaseController<EmployeeDepartment>
    {
        IEmployeeDepartmentBL _employeeDepartmentBL;

        public EmployeeDepartmentController(IEmployeeDepartmentBL employeeDepartmentBL): base(employeeDepartmentBL)
        {
            _employeeDepartmentBL = employeeDepartmentBL;
        }
    }
}
