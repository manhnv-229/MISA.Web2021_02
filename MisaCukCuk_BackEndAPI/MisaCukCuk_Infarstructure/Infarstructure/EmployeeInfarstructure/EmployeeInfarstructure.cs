using MisaCukCuk_Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MisaCukCuk_Infarstructure.Infarstructure.EmployeeInfarstructure
{
    public class EmployeeInfarstructure : MisaCukCukContext<Employee>, IEmployeeInfarstructure
    {
        MisaCukCukContext<Employee> _db = new MisaCukCukContext<Employee>();
        public async Task<IEnumerable<Employee>> getAllDataOfEmployee()
        {
            return await _db.GetAllData();
        }
    }
}
