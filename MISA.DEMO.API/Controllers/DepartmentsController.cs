using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.DEMO.API.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MISA.Service;
using System.Threading.Tasks;
using MISA.Common.Models;
using MISA.Service.Interface;

namespace MISA.DEMO.API.Controllers
{
    [Route("api/departments")]
    [ApiController]
    public class DepartmentsController : BaseController<Department>
    {
        public DepartmentsController(IBaseService<Department> departmentService) : base(departmentService)
        {

        }
    }
}
