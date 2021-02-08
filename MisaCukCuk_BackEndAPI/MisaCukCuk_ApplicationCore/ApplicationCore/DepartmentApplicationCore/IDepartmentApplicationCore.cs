using MisaCukCuk_ApplicationCore.BaseApplicationCore;
using MisaCukCuk_Entity.Common;
using MisaCukCuk_Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MisaCukCuk_ApplicationCore.ApplicationCore.DepartmentApplicationCore
{
    public interface IDepartmentApplicationCore : IBaseApplicationCore<Department>
    {
        //Task<IEnumerable<Department>> GetAllDataOfDepartment();
        //Task<ServiceResult> GetData();
    }
}
