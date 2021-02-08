using MISA.ApplicationCore.Interface;
using MISA.Common.Model;
using MISA.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore
{
    public class EmployeePositionBL: BaseBL<EmployeePosition>, IEmployeePositionBL
    {
        #region DECLARE
        IEmployeePositionDL _employeePositionDL;
        #endregion

        public EmployeePositionBL(IEmployeePositionDL employeePositionDL) : base(employeePositionDL)
        {
            _employeePositionDL = employeePositionDL;
        }
    }
}
