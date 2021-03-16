using MISA.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataLayer.DbContext2
{
    public class EmployeeRepositoryV2<Employee>: DbContextV2<Employee>,IEmployeeRepository<Employee>
    {

    }
}
