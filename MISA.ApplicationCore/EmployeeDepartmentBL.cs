using MISA.ApplicationCore.Interface;
using MISA.Common.Model;
using MISA.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore
{
    public class EmployeeDepartmentBL: BaseBL<EmployeeDepartment>,  IEmployeeDepartmentBL
    {
        #region DECLARE
        IEmployeeDepartmentDL _employeeDepartmentDL;
        #endregion

        public EmployeeDepartmentBL(IEmployeeDepartmentDL employeeDepartmentDL) :base(employeeDepartmentDL)
        {
            _employeeDepartmentDL = employeeDepartmentDL;
        }
    }
}
