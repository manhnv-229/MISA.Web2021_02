using MISA.Common.Models;
using MISA.DataLayer;
using MISA.Common;
using System;
using System.Collections.Generic;
using System.Text;
using MISA.Service.Interface;
using MISA.DataLayer.Interface;

namespace MISA.Service
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        public EmployeeService(IDbContext<Employee> _dbContext) : base(_dbContext)
        {

        }

        #region Method
        // Validate Data
        protected override bool ValidateData(Employee employee, ErrorMsg errorMsg = null)
        {
            var employeeContext = new EmployeeContext();
            // Validate dữ liệu:
            var isValid = true;
            // Check trường bắt buộc nhập:
            var employeeCode = employee.employeeCode;
            if (string.IsNullOrEmpty(employeeCode))
            {
                if(errorMsg != null)
                    errorMsg.UserMsg.Add( MISA.Common.Properties.Resources.ErrorService_EmptyEmployeeCode.ToString());
                isValid = false;
            }
            var phoneNumber = employee.phoneNumber;
            if (string.IsNullOrEmpty(phoneNumber))
            {
                if (errorMsg != null)
                    errorMsg.UserMsg.Add(MISA.Common.Properties.Resources.ErrorService_EmptyEmployeePhoneNumber.ToString());
                isValid = false;
            }
            var email = employee.email;
            if (string.IsNullOrEmpty(email))
            {
                if (errorMsg != null)
                    errorMsg.UserMsg.Add(MISA.Common.Properties.Resources.ErrorService_EmptyEmployeeEmail.ToString());
                isValid = false;
            }
            var identifyNumber = employee.identifyNumber;
            if (string.IsNullOrEmpty(identifyNumber))
            {
                if (errorMsg != null)
                    errorMsg.UserMsg.Add(MISA.Common.Properties.Resources.ErrorService_EmptyEmployeeIdentifyNumber.ToString());
                isValid = false;
            }
            var fullName = employee.fullName;
            if (string.IsNullOrEmpty(fullName))
            {
                if (errorMsg != null)
                    errorMsg.UserMsg.Add(MISA.Common.Properties.Resources.ErrorService_EmptyEmployeeFullName.ToString());
                isValid = false;
            }

            // Check trùng mã:
            var isExis = employeeContext.CheckEmployeeCodeExis(employeeCode);

            if (isExis == true)
            {
                if (errorMsg != null)
                    errorMsg.UserMsg.Add(MISA.Common.Properties.Resources.ErrorService_DuplicateEmployeeCode.ToString());
                isValid = false;
            }
            // Check trùng số điện thoại:
            isExis = employeeContext.CheckEmployeePhoneNumberExis(phoneNumber);

            if (isExis == true)
            {
                if (errorMsg != null)
                    errorMsg.UserMsg.Add(MISA.Common.Properties.Resources.ErrorService_DuplicateEmployeePhoneNumber.ToString());
                isValid = false;
            }
            return isValid;
        }
        // Sửa thông tin nhân viên:

        // Xóa nhân viên:



        #endregion
    }
}
