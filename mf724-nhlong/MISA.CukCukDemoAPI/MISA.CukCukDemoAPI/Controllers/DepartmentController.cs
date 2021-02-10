using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using MISA.Service;
using MISA.Service.Entities;
using MISA.Service.Interfaces;

namespace DemoApi.Controllers
{
    public class DepartmentController : BaseController<Department>
    {
        public DepartmentController(IBaseService<Department>  employeeService):base(employeeService)
        {

        }
    }
}