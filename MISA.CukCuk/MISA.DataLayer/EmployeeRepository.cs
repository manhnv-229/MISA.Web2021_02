using Dapper;
using MISA.Common.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.DataLayer
{
    public class EmployeeRepository: DbContext<Employee>
    {
        /// <summary>
        /// Hàm lấy 10 nhân viên đầu tiên.
        /// </summary>
        /// <returns>Collection Object</returns>
        /// CreatedBy: NTANH (08/02/2021)
        public IEnumerable<Employee> GetEmployeeTop10()
        {
            return GetData("SELECT * FROM Employee LIMIT 10");
        }

        /// <summary>
        /// Kiểm tra mã nhân viên đã tồn tại hay chưa
        /// </summary>
        /// <param name="employeeCode">Mã nhân viên cần kiểm tra</param>
        /// <returns>true - đã tồn tại; false - chưa tồn tại</returns>
        /// CreatedBy: NTANH (07/02/2021)
        public bool CheckEmployeeCodeExist(string employeeCode)
        {
            var sql = $"SELECT EmployeeCode FROM Employee AS E WHERE E.EmployeeCode = '{employeeCode}'";
            var employeeCodeExist = _dbConnection.Query<string>(sql).FirstOrDefault();
            if (employeeCodeExist != null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Kiểm tra số điện thoại đã tồn tại hay chưa
        /// </summary>
        /// <param name="phoneNumber">Số điện thoại cần kiểm tra</param>
        /// <returns>true - đã tồn tại; false - chưa tồn tại</returns>
        /// CreatedBy: NTANH (07/02/2021)
        public bool CheckPhoneNumberExist(string phoneNumber)
        {
            var sql = $"SELECT PhoneNumber FROM Employee AS E WHERE E.PhoneNumber = '{phoneNumber}'";
            var phoneNumberExist = _dbConnection.Query<string>(sql).FirstOrDefault();
            if (phoneNumberExist != null)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Kiểm tra số CMT đã tồn tại hay chưa
        /// </summary>
        /// <param name="phoneNumber">Số điện thoại cần kiểm tra</param>
        /// <returns>true - đã tồn tại; false - chưa tồn tại</returns>
        /// CreatedBy: NTANH (07/02/2021)
        public bool CheckPeopleIDExist(string peopleID)
        {
            var sql = $"SELECT PeopleID FROM Employee AS E WHERE E.PeopleID = '{peopleID}'";
            var peopleIDExist = _dbConnection.Query<string>(sql).FirstOrDefault();
            if (peopleIDExist != null)
                return true;
            else
                return false;
        }
    }
}
