using MisaCukCuk_Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MisaCukCuk_Infarstructure.Infarstructure.DepartmentInfarstructure
{
    public class DepartmentInfarstructure : MisaCukCukContext<Department>, IDepartmentInfarstructure
    {
        MisaCukCukContext<Department> _db = new MisaCukCukContext<Department>();
        public async Task<IEnumerable<Department>> getAllDataOfDepartment()
        {
            return await _db.GetAllData();
        }
    }
}
