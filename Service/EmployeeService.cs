using Common;
using MISA.DataLayer;
using MISA.DataLayer.Interfaces;
using MISA.Service;
using MISA.Service.Interfaces;
using System;
using System.Collections.Generic;

namespace Service
{ 
    public class EmployeeService : BaseService<Employee>,IEmployeeService
    {
        #region CONTRUCTOR
        public EmployeeService(IEmployeeRepository<Employee> employeeRepository):base(employeeRepository)
        {

        }
        #endregion

        #region METHODS
        /// <summary>
        /// Lấy toàn bộ dữ liệu 
        /// </summary>
        /// <returns>toàn bộ dữ liệu</returns>
        /// CreatedBy: TLMinh (03/02/2021)
        public override ServiceResult Get()
        {
            var serviceResult = new ServiceResult();
            serviceResult.Data = _dbContext.GetAll("Select * from Employee Order By EmployeeCode Desc");
            return serviceResult;
        }

        /// <summary>
        /// Validate dữ liệu nhân viên
        /// </summary>
        /// <param name="employee">Thực thể nhân viên cần validate dữ liệu</param>
        /// <param name="errorMessenger">Tập hợp các thông báo lỗi</param>
        /// <param name="entityCode">Mã nhân viên tương ứng</param>
        /// <returns>True: dữ liệu hợp lệ; False: dữ liệu không hợp lệ</returns>
        /// CreatedBy : TLMinh (06/02/2021)
        public override bool Validate(Employee employee, ErrorMessenger errorMessenger, string entityCode = null)
        {
            var isValid = true;

            //Validate dữ liệu
            //1.Nếu là update thông tin thì kiểm tra xem mã thực thể có thay đổi không 
            //Nếu thay đổi thì phải check trùng mã
            //Nếu không thì không cần check
            if (entityCode == null || entityCode != employee.EmployeeCode)
            {
                //Kiểm tra trùng mã nhân viên
                List<Employee> employeeCodeExist = (List<Employee>)_dbContext.GetAll($"SELECT * FROM Employee Where EmployeeCode = '{employee.EmployeeCode}'");
                Console.WriteLine(employeeCodeExist);
                if (employeeCodeExist.Count != 0)
                {
                    errorMessenger.UserMsg.Add(MISA.Common.Properties.Resources.ErrorService_DuplicateEmployeeCode);
                    isValid = false;
                }
            }  
           
            //Bắt buộc nhập những thông tin(Mã Nhân Viên, Email, Họ Và Tên, Số Điện Thoại, Chứng Minh Thư Nhân Dân)
            if ((employee.EmployeeCode == string.Empty || employee.FullName == string.Empty
                || employee.CMTND == string.Empty || employee.Email == string.Empty
                || employee.PhoneNumber == string.Empty)
                || (employee.EmployeeCode == null || employee.FullName == null
                || employee.CMTND == null || employee.Email == null
                || employee.PhoneNumber == null))
            {
                errorMessenger.UserMsg.Add(MISA.Common.Properties.Resources.ErrorService_EmptyDataInput);
                isValid = false;
            }

            return isValid;
        }

        #endregion 
    }
}
