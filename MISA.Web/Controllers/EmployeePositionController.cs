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
    [Route("api/v1/employee-positions")]
    public class EmployeePositionController : BaseController<EmployeePosition>
    {
        #region DECLARE
        IEmployeePositionBL _employeePositionBL;
        #endregion
        public EmployeePositionController(IEmployeePositionBL employeePositionBL): base(employeePositionBL)
        {
            _employeePositionBL = employeePositionBL;
        }
    }
}
