using MisaCukCuk_ApplicationCore.BaseApplicationCore;
using MisaCukCuk_Entity.Models;
using MisaCukCuk_Infarstructure.Infarstructure.DepartmentInfarstructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MisaCukCuk_ApplicationCore.ApplicationCore.DepartmentApplicationCore
{
    public class DepartmentApplicationCore : BaseApplicationCore<Department>,IDepartmentApplicationCore
    {
        IDepartmentInfarstructure _departmentInfarstructure;
        public DepartmentApplicationCore(IDepartmentInfarstructure departmentInfarstructure) : base(departmentInfarstructure)
        {
            _departmentInfarstructure = departmentInfarstructure;
        }
    }
}
