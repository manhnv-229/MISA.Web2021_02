using MISA.Common.Entities;
using MISA.BL.Interfaces;
using MISA.Common;
using MISA.DL;
using MISA.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MISA.BL
{
    public class EmployeeBL : IEmployeeBL
    {
        //xuwr lys du lieu
        IEmployeeDL _employeeDL;
        public EmployeeBL(IEmployeeDL employeeDL)
        {
            _employeeDL = employeeDL;
        }
        public IEnumerable<Employee> GetEmployees()
        {
            var employees = _employeeDL.GetEmployees();
            return employees;
        }
        public IEnumerable<Employee> GetEmployeeByNumAndType(int num,int type)
        {
            var employees = _employeeDL.GetEmployeeByNumAndType(num,type);
            return employees;
        }
        public IEnumerable<Employee> GetEmployeeByCode(string code)
        {
            var employee = _employeeDL.GetEmployeeByCode(code);
            return employee;
        }
        //Lấy code max và cộng thêm 1
        public string GetEmployeeCodeMax()
        {
            var codeMax = _employeeDL.GetEmployeeCodeMax();
            var a = codeMax[0];
            string b = a.Substring(a.Length - 5, 5);
            int i = int.Parse(b);
            i = i + 1;
            var stringg = "";
            if (i < 10) { stringg = "NV00000" + i.ToString(); }
            else if (i < 100) { stringg = "NV0000" + i.ToString(); }
            else if (i < 1000) { stringg = "NV000" + i.ToString(); }
            else if (i < 10000) { stringg = "NV00" + i.ToString(); }
            else if (i < 100000) { stringg = "NV0" + i.ToString(); }
            else { stringg = "NV" + i.ToString(); }

            return stringg;
        }
        //validate du lieu
        public ServiceResult InsertEmployee(Employee employee)
        {
            var serviceResult = new ServiceResult();
            var employeeCode = employee.EmployeeCode;
            if (string.IsNullOrEmpty(employeeCode))
            {
                var msg = new
                {
                    devMsg = new { fieldName = "EmployeeCode", Messenger = "Mã nhân viên không được phép để trống" },
                    userMsg = "Mã nhân viên không được phép để trống",
                    code = 101,
                };
                serviceResult.MISACode = MISACode.NotValid;
                serviceResult.Messenger = "Mã nhân viên không được phép để trống";
                serviceResult.Data = msg;
                return serviceResult;
            }
            //Kiểm tra trùng mã
            var checkCode = _employeeDL.GetEmployeeByCode(employeeCode);
            if (checkCode.Count() > 0)
            {
                var msg = new
                {
                    devMsg = new { fieldName = "EmployeeCode", Messenger = "Mã nhân viên đã tồn tại" },
                    userMsg = "Mã nhân viên đã tồn tại",
                    code = 102,
                };
                serviceResult.MISACode = MISACode.NotValid;
                serviceResult.Messenger = "Mã nhân viên đã tồn tại";
                serviceResult.Data = msg;
                return serviceResult;
            }
            //Kiểm tra số điện thoai
            var employeePhone = employee.EmployeePhone;
            if (string.IsNullOrEmpty(employeePhone))
            {
                var msg = new
                {
                    devMsg = new { fieldName = "EmployeePhone", Messenger = "Số điện thoại không được phép để trống" },
                    userMsg = "Số điện thoại không được phép để trống",
                    code = 103,
                };
                serviceResult.MISACode = MISACode.NotValid;
                serviceResult.Messenger = "Số điện thoại không được phép để trống";
                serviceResult.Data = msg;
                return serviceResult;
            }
            //kiểm tra tên
            var employeeName = employee.EmployeeName;
            if (string.IsNullOrEmpty(employeeName))
            {
                var msg = new
                {
                    devMsg = new { fieldName = "EmployeeName", Messenger = "Họ và tên không được phép để trống" },
                    userMsg = "Họ và tên không được phép để trống",
                    code = 104
                };
                serviceResult.MISACode = MISACode.NotValid;
                serviceResult.Messenger = "Họ và tên không được phép để trống";
                serviceResult.Data = msg;
                return serviceResult;
            }
            //kiểm tra scmnd
            var employeeIdentifyNumber = employee.EmployeeIdentifyNumber;
            if (string.IsNullOrEmpty(employeeIdentifyNumber))
            {
                var msg = new
                {
                    devMsg = new { fieldName = "EmployeeIdentifyNumber", Messenger = "Số chứng minh nhân dân không được phép để trống" },
                    userMsg = "Số chứng minh nhân dân không được phép để trống",
                    code = 105
                };
                serviceResult.MISACode = MISACode.NotValid;
                serviceResult.Messenger = "Số chứng minh nhân dân không được phép để trống";
                serviceResult.Data = msg;
                return serviceResult;
            }
            var employeeEmail = employee.EmployeeEmail;
            if (string.IsNullOrEmpty(employeeEmail))
            {
                var msg = new
                {
                    devMsg = new { fieldName = "EmployeeEmail", Messenger = "Email không được phép để trống" },
                    userMsg = "Email không được phép để trống",
                    code = 106
                };
                serviceResult.MISACode = MISACode.NotValid;
                serviceResult.Messenger = "Email không được phép để trống";
                serviceResult.Data = msg;
                return serviceResult;
            }
            var rowAffects = _employeeDL.InsertEmployee(employee);
            serviceResult.MISACode = MISACode.IsValid;
            serviceResult.Messenger = "Thêm thành công";
            serviceResult.Data = rowAffects;
            return serviceResult;

        }
        public ServiceResult UpdateEmployee(Employee employee)
        {
            var serviceResult = new ServiceResult();
            var employeeCode = employee.EmployeeCode;
            if (string.IsNullOrEmpty(employeeCode))
            {
                var msg = new
                {
                    devMsg = new { fieldName = "EmployeeCode", Messenger = "Mã nhân viên không được phép để trống" },
                    userMsg = "Mã nhân viên không được phép để trống",
                    code = 101,
                };
                serviceResult.MISACode = MISACode.NotValid;
                serviceResult.Messenger = "Mã nhân viên không được phép để trống";
                serviceResult.Data = msg;
                return serviceResult;
            }
            //Kiểm tra trùng mã
            var checkCode = _employeeDL.GetEmployeeByCode1(employeeCode);

            if (checkCode != null && checkCode.EmployeeId != employee.EmployeeId)
            {
                var msg = new
                {
                    devMsg = new { fieldName = "EmployeeCode", Messenger = "Mã nhân viên đã tồn tại" },
                    userMsg = "Mã nhân viên đã tồn tại",
                    code = 102,
                };
                serviceResult.MISACode = MISACode.NotValid;
                serviceResult.Messenger = "Mã nhân viên đã tồn tại";
                serviceResult.Data = msg;
                return serviceResult;
            }
            //Kiểm tra số điện thoai
            var employeePhone = employee.EmployeePhone;
            if (string.IsNullOrEmpty(employeePhone))
            {
                var msg = new
                {
                    devMsg = new { fieldName = "EmployeePhone", Messenger = "Số điện thoại không được phép để trống" },
                    userMsg = "Số điện thoại không được phép để trống",
                    code = 103,
                };
                serviceResult.MISACode = MISACode.NotValid;
                serviceResult.Messenger = "Số điện thoại không được phép để trống";
                serviceResult.Data = msg;
                return serviceResult;
            }
            //kiểm tra tên
            var employeeName = employee.EmployeeName;
            if (string.IsNullOrEmpty(employeeName))
            {
                var msg = new
                {
                    devMsg = new { fieldName = "EmployeeName", Messenger = "Họ và tên không được phép để trống" },
                    userMsg = "Họ và tên không được phép để trống",
                    code = 104
                };
                serviceResult.MISACode = MISACode.NotValid;
                serviceResult.Messenger = "Họ và tên không được phép để trống";
                serviceResult.Data = msg;
                return serviceResult;
            }
            //kiểm tra scmnd
            var employeeIdentifyNumber = employee.EmployeeIdentifyNumber;
            if (string.IsNullOrEmpty(employeeIdentifyNumber))
            {
                var msg = new
                {
                    devMsg = new { fieldName = "EmployeeIdentifyNumber", Messenger = "Số chứng minh nhân dân không được phép để trống" },
                    userMsg = "Số chứng minh nhân dân không được phép để trống",
                    code = 105
                };
                serviceResult.MISACode = MISACode.NotValid;
                serviceResult.Messenger = "Số chứng minh nhân dân không được phép để trống";
                serviceResult.Data = msg;
                return serviceResult;
            }
            var employeeEmail = employee.EmployeeEmail;
            if (string.IsNullOrEmpty(employeeEmail))
            {
                var msg = new
                {
                    devMsg = new { fieldName = "EmployeeEmail", Messenger = "Email không được phép để trống" },
                    userMsg = "Email không được phép để trống",
                    code = 106
                };
                serviceResult.MISACode = MISACode.NotValid;
                serviceResult.Messenger = "Email không được phép để trống";
                serviceResult.Data = msg;
                return serviceResult;
            }
            //Xử lý thay đổi dữ liệu
            //Chuyển đổi dữ liệu giới tính
            if (employee.EmployeeGender != 1 && employee.EmployeeGender != 0)
            {
                employee.EmployeeGender = 2;
            }
            var rowAffects = _employeeDL.UpdateEmployee(employee);
            serviceResult.MISACode = MISACode.IsValid;
            serviceResult.Messenger = "Thay đổi thành công";
            serviceResult.Data = rowAffects;
            return serviceResult;
        }
        //Xóa nhân viên
        public ServiceResult DeleteEmployee(string id)
        {
            var serviceResult = new ServiceResult();
            var rowAffects = _employeeDL.DeleteEmployee(id);
            serviceResult.MISACode = MISACode.Success;
            serviceResult.Messenger = "Xóa thành công";
            serviceResult.Data = rowAffects;
            return serviceResult;
        }
    }
}
