using MISA.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataLayer.Interface
{
    public interface IEmployeeContext : IDbContext<Employee>
    {
    }
}
