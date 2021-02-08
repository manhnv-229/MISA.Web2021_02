using MisaCukCuk_Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MisaCukCuk_Infarstructure.Infarstructure.EmployeeInfarstructure
{
    public interface IEmployeeInfarstructure : IMisaCukCukContext<Employee>
    {
        Task<IEnumerable<Employee>> getAllDataOfEmployee();
    }
}
