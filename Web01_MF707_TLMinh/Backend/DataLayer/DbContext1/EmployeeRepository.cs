using MISA.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataLayer.DbContext1
{
    public class EmployeeRepository<Employee>: DbContext<Employee>,IEmployeeRepository<Employee>
    {

    }
}
