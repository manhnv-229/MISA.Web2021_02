using MisaCukCuk_Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MisaCukCuk_Infarstructure.Infarstructure.DepartmentInfarstructure
{
    public interface IDepartmentInfarstructure : IMisaCukCukContext<Department>
    {
        Task<IEnumerable<Department>> getAllDataOfDepartment();
    }
}
