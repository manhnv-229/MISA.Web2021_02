using MISA.Common.Model;
using MISA.DataLayer;
using MISA.DataLayer.Interfaces;
using MISA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Service
{
    public class EmployeeService: BaseService<Employee>, IEmployeeService
    {
        public EmployeeService(IBaseData<Employee> DbContext) : base(DbContext)
        {

        }

        /// <summary>
        /// Hàm ghi đè Validate của hàm Base
        /// </summary>
        /// <param name="employee">Đối tượng cần validate</param>
        /// <param name="errorMsg">errorMsg muốn truyền về</param>
        /// <returns>true - hợp lệ; false - không hợp lệ</returns>
        /// CreatedBy: NTANH (08/02/2021)
        protected override bool ValidateData(Employee employee, ErrorMsg errorMsg)
        {
            var serviceResult = new ServiceResult();
            var dbContext = new EmployeeRepository();
            var isValid = true;

            // 1. validate bắt buộc nhập
            // - Kiểm tra bắt buộc nhập mã nhân viên
            if (employee.EmployeeCode == null || employee.EmployeeCode == string.Empty)
            {
                errorMsg.DevMsg = MISA.Common.Properties.Resources.ErrorService_EmptyEmployeeCode;
                errorMsg.UserMsg = MISA.Common.Properties.Resources.ErrorService_EmptyEmployeeCode;
                isValid = false;
            }

            // - kiểm tra bắt buộc nhập số điện thoại
            if (employee.PhoneNumber == null || employee.PhoneNumber == string.Empty)
            {
                errorMsg.DevMsg = MISA.Common.Properties.Resources.ErrorService_EmptyPhoneNumber;
                errorMsg.UserMsg = MISA.Common.Properties.Resources.ErrorService_EmptyPhoneNumber;
                isValid = false;
            }

            // - kiểm tra bắt buộc nhập Số CMT
            if (employee.PeopleID == null || employee.PeopleID == string.Empty)
            {
                errorMsg.DevMsg = MISA.Common.Properties.Resources.ErrorService_EmptyPeopleID;
                errorMsg.UserMsg = MISA.Common.Properties.Resources.ErrorService_EmptyPeopleID;
                isValid = false;
            }


            // 2. validate dữ liệu không được phép trùng: (mã nhân viên, số điện thoại, số CMT)
            // - kiểm tra trong DB đã tồn tại mã nhân viên hay chưa
            var isExist = dbContext.CheckEmployeeCodeExist(employee.EmployeeCode);

            if (isExist == true)
            {
                errorMsg.DevMsg = MISA.Common.Properties.Resources.ErrorService_DuplicateEmployeeCode;
                errorMsg.UserMsg = MISA.Common.Properties.Resources.ErrorService_DuplicateEmployeeCode;
                isValid = false;
            }

            // - kiểm tra trong DB đã tồn tại số điện thoại hay chưa
            isExist = dbContext.CheckPhoneNumberExist(employee.PhoneNumber);
            if (isExist == true)
            {
                errorMsg.DevMsg = MISA.Common.Properties.Resources.ErrorService_DuplicatePhoneNumber;
                errorMsg.UserMsg = MISA.Common.Properties.Resources.ErrorService_DuplicatePhoneNumber;
                isValid = false;
            }

            // - kiểm tra trong DB đã tồn tại số CMT hay chưa
            isExist = dbContext.CheckPeopleIDExist(employee.PeopleID);
            if (isExist == true)
            {
                errorMsg.DevMsg = MISA.Common.Properties.Resources.ErrorService_DuplicatePeopleID;
                errorMsg.UserMsg = MISA.Common.Properties.Resources.ErrorService_DuplicatePeopleID;
                isValid = false;
            }

            return isValid;
        }
    }
}
