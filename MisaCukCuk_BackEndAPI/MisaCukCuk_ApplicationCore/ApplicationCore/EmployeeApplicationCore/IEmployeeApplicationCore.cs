using MisaCukCuk_ApplicationCore.BaseApplicationCore;
using MisaCukCuk_Entity.Common;
using MisaCukCuk_Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MisaCukCuk_ApplicationCore.ApplicationCore.EmployeeApplicationCore
{
    public interface IEmployeeApplicationCore : IBaseApplicationCore<Employee>
    {
        //Task<IEnumerable<Employee>> getAllDataOfEmployee();
        //Task<ServiceResult> GetData();
    }
}
