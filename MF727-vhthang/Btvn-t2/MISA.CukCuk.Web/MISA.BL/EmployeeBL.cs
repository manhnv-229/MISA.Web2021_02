using MISA.Common.Entities;
using MISA.BL.Interfaces;
using MISA.Common;
using MISA.DL;
using MISA.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using MISA.Common.Properties;

namespace MISA.BL
{
    public class EmployeeBL : BaseBL<Employee> ,IEmployeeBL
    {
        
        IEmployeeDL _employeeDL;
        IDbContext<Employee> _dbContext;
        public EmployeeBL(IDbContext<Employee> dbContext, IEmployeeDL employeeDL) : base(dbContext)
        {
            _employeeDL = employeeDL;
            _dbContext = dbContext;
        }

        /// <summary>
        /// Overrride hàm kiểm tra dữ liệu
        /// </summary>
        /// <param name="employee">Nhân viên</param>
        /// <returns>ServiceResult</returns>
        protected override ServiceResult Validate(Employee employee)
        {
            var serviceResult = new ServiceResult();
            //Kiểm tra mã nhân viên
            var employeeCode = employee.EmployeeCode;
            var props = typeof(Employee).GetProperties();
            if (string.IsNullOrEmpty(employeeCode) || string.IsNullOrEmpty(employeeCode.Trim()))
            {
                var msg = new
                {
                    devMsg = new { fieldName = "EmployeeCode", Messenger = Resources.ErroService_EmptyEmployeeCode },
                    userMsg = Resources.ErroService_EmptyEmployeeCode,
                };
                serviceResult.MISACode = MISACode.NotValid;
                serviceResult.Messenger = Resources.ErroService_EmptyEmployeeCode;
                serviceResult.Data = msg;
                return serviceResult;
            }
            //Kiểm tra cấu trúc mã nhân viên
            employeeCode = employeeCode.Trim();
            if (!Regex.IsMatch(employeeCode, @"[NV]{1}[\d]{6}"))
            {
                var msg = new
                {
                    devMsg = new { fieldName = "EmployeeCode", Messenger = Resources.ErroService_ValidEmployeeCode },
                    userMsg = Resources.ErroService_ValidEmployeeCode,
                };
                serviceResult.MISACode = MISACode.NotValid;
                serviceResult.Messenger = Resources.ErroService_ValidEmployeeCode;
                serviceResult.Data = msg;
                return serviceResult;
            }
            //Kiểm tra trùng mã
            var checkCode = _employeeDL.CheckDuplicate("EmployeeCode", employee.EmployeeCode);
            if (checkCode.Count() > 0)
            {
                var msg = new
                {
                    devMsg = new { fieldName = "EmployeeCode", Messenger = Resources.ErroService_DuplicateEmployeeCode },
                    userMsg = Resources.ErroService_DuplicateEmployeeCode,
                };
                serviceResult.MISACode = MISACode.NotValid;
                serviceResult.Messenger = Resources.ErroService_DuplicateEmployeeCode;
                serviceResult.Data = msg;
                return serviceResult;
            }
            //Kiểm tra số điện thoai
            var employeePhone = employee.EmployeePhone;
            if (string.IsNullOrEmpty(employeePhone) || string.IsNullOrEmpty(employeePhone.Trim()))
            {
                var msg = new
                {
                    devMsg = new { fieldName = "EmployeePhone", Messenger = Resources.ErroService_EmptyEmployeePhone },
                    userMsg = Resources.ErroService_EmptyEmployeePhone,
                };
                serviceResult.MISACode = MISACode.NotValid;
                serviceResult.Messenger = Resources.ErroService_EmptyEmployeePhone;
                serviceResult.Data = msg;
                return serviceResult;
            }
            employeePhone = employeePhone.Trim();
            var checkPhone = _employeeDL.CheckDuplicate("EmployeePhone", employee.EmployeePhone);
            if (checkPhone.Count() > 0)
            {
                var msg = new
                {
                    devMsg = new { fieldName = "EmployeePhone", Messenger = Resources.ErroService_DuplicatePhoneNumber },
                    userMsg = Resources.ErroService_DuplicatePhoneNumber,
                };
                serviceResult.MISACode = MISACode.NotValid;
                serviceResult.Messenger = Resources.ErroService_DuplicatePhoneNumber;
                serviceResult.Data = msg;
                return serviceResult;
            }
            //Kiểm tra tên
            var employeeName = employee.EmployeeName;
            if (string.IsNullOrEmpty(employeeName) || string.IsNullOrEmpty(employeeName.Trim()))
            {
                var msg = new
                {
                    devMsg = new { fieldName = "EmployeeName", Messenger = Resources.ErroService_EmptyEmployeeName },
                    userMsg = Resources.ErroService_EmptyEmployeeName,
                };
                serviceResult.MISACode = MISACode.NotValid;
                serviceResult.Messenger = Resources.ErroService_EmptyEmployeeName;
                serviceResult.Data = msg;
                return serviceResult;
            }
            employeeName = employeeName.Trim();
            //Kiểm tra số cmnd
            var employeeIdentifyNumber = employee.EmployeeIdentifyNumber;
            if (string.IsNullOrEmpty(employeeIdentifyNumber) || string.IsNullOrEmpty(employeeIdentifyNumber.Trim()))
            {
                var msg = new
                {
                    devMsg = new { fieldName = "EmployeeIdentifyNumber", Messenger = Resources.ErroService_EmptyEmployeeIdentifyNumber },
                    userMsg = Resources.ErroService_EmptyEmployeeIdentifyNumber,
                };
                serviceResult.MISACode = MISACode.NotValid;
                serviceResult.Messenger = Resources.ErroService_EmptyEmployeeIdentifyNumber;
                serviceResult.Data = msg;
                return serviceResult;
            }
            employeeIdentifyNumber = employeeIdentifyNumber.Trim();
            var checkIN = _employeeDL.CheckDuplicate("EmployeeIdentifyNumber", employee.EmployeeIdentifyNumber);
            if (checkIN.Count() > 0)
            {
                var msg = new
                {
                    devMsg = new { fieldName = "EmployeeIdentifyNumber", Messenger = Resources.ErroService_DuplicateEmployeeIdentifyNumber },
                    userMsg = Resources.ErroService_DuplicateEmployeeIdentifyNumber,
                };
                serviceResult.MISACode = MISACode.NotValid;
                serviceResult.Messenger = Resources.ErroService_DuplicateEmployeeIdentifyNumber;
                serviceResult.Data = msg;
                return serviceResult;
            }
            var employeeEmail = employee.EmployeeEmail;
            if (string.IsNullOrEmpty(employeeEmail) || string.IsNullOrEmpty(employeeEmail.Trim()))
            {
                var msg = new
                {
                    devMsg = new { fieldName = "EmployeeEmail", Messenger = Resources.ErroService_EmptyEmployeeEmail },
                    userMsg = Resources.ErroService_EmptyEmployeeEmail,
                    code = 106
                };
                serviceResult.MISACode = MISACode.NotValid;
                serviceResult.Messenger = Resources.ErroService_EmptyEmployeeEmail;
                serviceResult.Data = msg;
                return serviceResult;
            }
            employeeEmail = employeeEmail.Trim().ToLower();
            if (!Regex.IsMatch(employeeEmail, @"^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,})$"))
            {
                var msg = new
                {
                    devMsg = new { fieldName = "EmployeeEmail", Messenger = Resources.ErroService_ValidEmployeeEmail },
                    userMsg = Resources.ErroService_ValidEmployeeEmail,
                    code = 106
                };
                serviceResult.MISACode = MISACode.NotValid;
                serviceResult.Messenger = Resources.ErroService_ValidEmployeeEmail;
                serviceResult.Data = msg;
                return serviceResult;
            }
            var checkEmail = _employeeDL.CheckDuplicate("EmployeeEmail", employee.EmployeeEmail);
            if (checkEmail.Count() > 0)
            {
                var msg = new
                {
                    devMsg = new { fieldName = "EmployeeEmail", Messenger = Resources.ErroService_DuplicateEmployeeEmail },
                    userMsg = Resources.ErroService_DuplicateEmployeeEmail,
                    code = 106,
                };
                serviceResult.MISACode = MISACode.NotValid;
                serviceResult.Messenger = Resources.ErroService_DuplicateEmployeeEmail;
                serviceResult.Data = msg;
                return serviceResult;
            }
            
            serviceResult.MISACode = MISACode.IsValid;
            serviceResult.Messenger = Resources.SuccessService_IsVaid;
            serviceResult.Data = 1;
            return serviceResult;

        }












        
        //public ServiceResult UpdateEmployee(Employee employee)
        //{
        //    var serviceResult = new ServiceResult();
        //    var employeeCode = employee.EmployeeCode;
        //    if (string.IsNullOrEmpty(employeeCode) || string.IsNullOrEmpty(employeeCode.Trim()))
        //    {
        //        var msg = new
        //        {
        //            devMsg = new { fieldName = "EmployeeCode", Messenger = "Mã nhân viên không được phép để trống" },
        //            userMsg = "Mã nhân viên không được phép để trống",
        //            code = 101,
        //        };
        //        serviceResult.MISACode = MISACode.NotValid;
        //        serviceResult.Messenger = "Mã nhân viên không được phép để trống";
        //        serviceResult.Data = msg;
        //        return serviceResult;
        //    }
        //    //Kiểm tra trùng mã
        //    var checkCode = _employeeDL.GetEmployeeByCode(employeeCode);

        //    if (checkCode.Count() > 0 && checkCode.ElementAt(0).EmployeeId != employee.EmployeeId)
        //    {
        //        var msg = new
        //        {
        //            devMsg = new { fieldName = "EmployeeCode", Messenger = "Mã nhân viên đã tồn tại" },
        //            userMsg = "Mã nhân viên đã tồn tại",
        //            code = 102,
        //        };
        //        serviceResult.MISACode = MISACode.NotValid;
        //        serviceResult.Messenger = "Mã nhân viên đã tồn tại";
        //        serviceResult.Data = msg;
        //        return serviceResult;
        //    }
        //    //Kiểm tra số điện thoai
        //    var employeePhone = employee.EmployeePhone;
        //    if (string.IsNullOrEmpty(employeePhone) || string.IsNullOrEmpty(employeePhone.Trim()))
        //    {
        //        var msg = new
        //        {
        //            devMsg = new { fieldName = "EmployeePhone", Messenger = "Số điện thoại không được phép để trống" },
        //            userMsg = "Số điện thoại không được phép để trống",
        //            code = 103,
        //        };
        //        serviceResult.MISACode = MISACode.NotValid;
        //        serviceResult.Messenger = "Số điện thoại không được phép để trống";
        //        serviceResult.Data = msg;
        //        return serviceResult;
        //    }
        //    //Kiểm tra tên
        //    var employeeName = employee.EmployeeName;
        //    if (string.IsNullOrEmpty(employeeName) || string.IsNullOrEmpty(employeeName.Trim()))
        //    {
        //        var msg = new
        //        {
        //            devMsg = new { fieldName = "EmployeeName", Messenger = "Họ và tên không được phép để trống" },
        //            userMsg = "Họ và tên không được phép để trống",
        //            code = 104
        //        };
        //        serviceResult.MISACode = MISACode.NotValid;
        //        serviceResult.Messenger = "Họ và tên không được phép để trống";
        //        serviceResult.Data = msg;
        //        return serviceResult;
        //    }
        //    //Kiểm tra số cmnd
        //    var employeeIdentifyNumber = employee.EmployeeIdentifyNumber;
        //    if (string.IsNullOrEmpty(employeeIdentifyNumber) || string.IsNullOrEmpty(employeeIdentifyNumber.Trim()))
        //    {
        //        var msg = new
        //        {
        //            devMsg = new { fieldName = "EmployeeIdentifyNumber", Messenger = "Số chứng minh nhân dân không được phép để trống" },
        //            userMsg = "Số chứng minh nhân dân không được phép để trống",
        //            code = 105
        //        };
        //        serviceResult.MISACode = MISACode.NotValid;
        //        serviceResult.Messenger = "Số chứng minh nhân dân không được phép để trống";
        //        serviceResult.Data = msg;
        //        return serviceResult;
        //    }
        //    employeeIdentifyNumber = employeeIdentifyNumber.Trim();
        //    var checkIN = _employeeDL.GetEmployeeByIdentifyNumber(employeeIdentifyNumber);
        //    if (checkIN.Count() > 0 && checkIN.ElementAt(0).EmployeeId != employee.EmployeeId)
        //    {
        //        var msg = new
        //        {
        //            devMsg = new { fieldName = "EmployeeIdentifyNumber", Messenger = "Số chứng minh nhân dân đã tồn tại" },
        //            userMsg = "Số chứng minh nhân dân đã tồn tại",
        //            code = 105,
        //        };
        //        serviceResult.MISACode = MISACode.NotValid;
        //        serviceResult.Messenger = "Số chứng minh nhân dân đã tồn tại";
        //        serviceResult.Data = msg;
        //        return serviceResult;
        //    }
        //    var employeeEmail = employee.EmployeeEmail;
        //    if (string.IsNullOrEmpty(employeeEmail) || string.IsNullOrEmpty(employeeEmail.Trim()))
        //    {
        //        var msg = new
        //        {
        //            devMsg = new { fieldName = "EmployeeEmail", Messenger = "Email không được phép để trống" },
        //            userMsg = "Email không được phép để trống",
        //            code = 106
        //        };
        //        serviceResult.MISACode = MISACode.NotValid;
        //        serviceResult.Messenger = "Email không được phép để trống";
        //        serviceResult.Data = msg;
        //        return serviceResult;
        //    }
        //    employeeEmail = employeeEmail.Trim().ToLower();
        //    if (!Regex.IsMatch(employeeEmail, @"^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,})$"))
        //    {
        //        var msg = new
        //        {
        //            devMsg = new { fieldName = "EmployeeEmail", Messenger = "Email không hợp lệ" },
        //            userMsg = "Email không hợp lệ",
        //            code = 106
        //        };
        //        serviceResult.MISACode = MISACode.NotValid;
        //        serviceResult.Messenger = "Email không hợp lệ";
        //        serviceResult.Data = msg;
        //        return serviceResult;
        //    }
        //    var checkEmail = _employeeDL.GetEmployeeByEmail(employeeEmail);
        //    if (checkEmail.Count() > 0 && checkEmail.ElementAt(0).EmployeeId != employee.EmployeeId)
        //    {
        //        var msg = new
        //        {
        //            devMsg = new { fieldName = "EmployeeEmail", Messenger = "Email đã tồn tại" },
        //            userMsg = "Email đã tồn tại",
        //            code = 106,
        //        };
        //        serviceResult.MISACode = MISACode.NotValid;
        //        serviceResult.Messenger = "Email đã tồn tại";
        //        serviceResult.Data = msg;
        //        return serviceResult;
        //    }
        //    employee.EmployeeEmail = employeeEmail;
        //    //Chuyển đổi dữ liệu giới tính
        //    if (employee.EmployeeGender != 1 && employee.EmployeeGender != 0)
        //    {
        //        employee.EmployeeGender = 2;
        //    }
        //    var rowAffects = _employeeDL.UpdateEmployee(employee);
        //    serviceResult.MISACode = MISACode.IsValid;
        //    serviceResult.Messenger = "Thay đổi thành công";
        //    serviceResult.Data = rowAffects;
        //    return serviceResult;
        //}
        ////Xóa nhân viên
        //public ServiceResult DeleteEmployee(string id)
        //{
        //    var serviceResult = new ServiceResult();
        //    var rowAffects = _employeeDL.DeleteEmployee(id);
        //    serviceResult.MISACode = MISACode.Success;
        //    serviceResult.Messenger = "Xóa thành công";
        //    serviceResult.Data = rowAffects;
        //    return serviceResult;
        //}
    }
}
