using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.Common.Models;
using MISA.DataLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.DataLayer
{
    public class EmployeeContext : DbContext<Employee>, IEmployeeContext
    {
        #region Method
        // Check trùng mã:
        /// <summary>
        /// Lấy nhân viên theo mã nhân viên
        /// </summary>
        /// <param name="employeeCode">Mã nhân viên</param>
        /// <returns>nhân viên đó nếu có còn ko thì trả về null</returns>
        /// CreatedBy PVTRONG (7/2/2021)
        public bool CheckEmployeeCodeExis(string employeeCode)
        {
            var res = _dbConnection.Query<Employee>($"SELECT PhoneNumber FROM Employee AS E WHERE E.EmployeeCode = '{employeeCode}'").FirstOrDefault();
            if (res != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Kiểm tra số điện thoại đã tồn tại hay chưa
        /// </summary>
        /// <param name="phoneNumber">Số điẹn thoại</param>
        /// <returns>Đã tồn tại hay chưa (true: đã tồn tại, false: chưa tồn tại)</returns>
        /// CreatedBy PVTRONG (7/2/2021)
        public bool CheckEmployeePhoneNumberExis(string phoneNumber)
        {
            var res = _dbConnection.Query<Employee>($"SELECT PhoneNumber FROM Employee AS E WHERE E.PhoneNumber = '{phoneNumber}'").FirstOrDefault();
            if(res != null)
            {
                return true;
            }
            return false;
        }

        // Sửa thông tin nhân viên: 

        // Xóa nhân viên theo khóa chính:
        #endregion
    }
}
