using MISA.Common.Model;
using MISA.DataLayer.Interfaces;
using MISA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Service.Service
{
    public class EmployeeServiceV2:BaseService<Employee>, IEmployeeService
    {
        public EmployeeServiceV2(IBaseData<Employee> DbContext) : base(DbContext)
        {

        }

        /// <summary>
        /// Hàm validate trong base (fix cứng để con ghi đè)
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="errorMsg"></param>
        /// <returns></returns>
        /// CreatedBy: NTANH (08/02/2021)
        protected override bool ValidateData(Employee entity, ErrorMsg errorMsg = null)
        {
            return true;
        }
    }
}
