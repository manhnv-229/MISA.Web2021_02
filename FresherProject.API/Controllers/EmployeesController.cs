using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FresherProject.Service;
using FresherProject.Common;
using FresherProject.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FresherProject.Service.Interfaces;

namespace FresherProject.API.Controllers
{
    public class EmployeesController : BaseEntitiesController<Employee>
    {
        public EmployeesController(IEmployeeService _employeeService) : base(_employeeService)
        {
        }
    }
}
