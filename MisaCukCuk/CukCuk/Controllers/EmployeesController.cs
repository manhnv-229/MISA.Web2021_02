using ApplicationCore.Interfaces;
using Common.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CukCuk.Controllers
{
    /// <summary>
    /// Controller cho đối tượng nhân viên
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : BaseController<Employee>
    {
        public EmployeesController(IBaseService<Employee> employeeService) : base(employeeService)
        {
        }
    }
}
