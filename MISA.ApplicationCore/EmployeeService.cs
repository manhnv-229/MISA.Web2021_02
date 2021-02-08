using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.interfaces;
using MISA.ApplicationCore.Messages;
using MISA.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using MySql.Data.MySqlClient;
using Dapper;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MISA.ApplicationCore
{
    public class EmployeeService : BaseService, IEmployeeService
    {
        IEmployeeRepository _employeeRepository;
        IDbContext _dbContext;
        #region Constructor
        public EmployeeService(IEmployeeRepository employeeRepository, IDbContext dbContext)
        {
            _employeeRepository = employeeRepository;
            _dbContext = dbContext;
        }
        #endregion

        #region Method
        /// <summary>
        /// Thêm mới nhân viên
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>Số bản ghi thêm thành công</returns>
        /// CreatedBy: BDHIEU (01/02/2021)
        public ServiceResult AddEmployee(Employee employee)
        {
            var errorMsg = new ErrorMsg();
            var serviceResult = new ServiceResult();
            var isValid = true;
            //validate
            isValid = ValidateData(employee, errorMsg);
            if(isValid == false)
            {
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
                return serviceResult;
            }
            else
            {
                errorMsg.devMsg.Add(MISA.ApplicationCore.Properties.Resources.ErrorMsg_AddEmployeeSuccess_dev);
                errorMsg.userMsg.Add(MISA.ApplicationCore.Properties.Resources.ErrorMsg_AddEmployeeSuccess_user);
                serviceResult.Success = true;
                serviceResult.Data = _employeeRepository.AddEmployee(employee);
                return serviceResult;
            }
            //thêm
            
        }
        
        public bool ValidateData(Employee employee, ErrorMsg errorMsg = null)
        {
            IDbConnection db = new MySqlConnection("Host=103.124.92.43; User Id=nvmanh; password=12345678; Database=MS4_08_BDHieu_CukCuk; Character Set=utf8");
            var isValid = true;
            if (employee.EmployeeCode == "")
            {
                errorMsg.devMsg.Add(MISA.ApplicationCore.Properties.Resources.ErrorMsg_NullEmployeeCode_dev);
                errorMsg.userMsg.Add(MISA.ApplicationCore.Properties.Resources.ErrorMsg_NullEmployeeCode_user);
                isValid = false;
            }
            var sqlQueryEmployeeCode = $"SELECT e.EmployeeCode FROM Employee e WHERE e.EmployeeCode = '{employee.EmployeeCode}'";
            string employeeCode = db.Query<string>(sqlQueryEmployeeCode).FirstOrDefault();
            if (employeeCode != null)
            {
                errorMsg.devMsg.Add(MISA.ApplicationCore.Properties.Resources.ErrorMsg_DuplicateEmployeeCode_dev);
                errorMsg.userMsg.Add(MISA.ApplicationCore.Properties.Resources.ErrorMsg_DuplicateEmployeeCode_user);
                isValid = false;
            }
            if (employee.FullName == "")
            {
                errorMsg.devMsg.Add(MISA.ApplicationCore.Properties.Resources.ErrorMsg_NullEmployeeFullName_dev);
                errorMsg.userMsg.Add(MISA.ApplicationCore.Properties.Resources.ErrorMsg_NullEmployeeFullName_user);
                isValid = false;
            }
            if (employee.PhoneNumber == "")
            {
                errorMsg.devMsg.Add(MISA.ApplicationCore.Properties.Resources.ErrorMsg_NullEmployeePhoneNumber_dev);
                errorMsg.userMsg.Add(MISA.ApplicationCore.Properties.Resources.ErrorMsg_NullEmployeePhoneNumber_user);
                isValid = false;
            }
            var sqlQueryPhoneNumber = $"SELECT e.PhoneNumber FROM Employee e WHERE e.PhoneNumber = '{employee.PhoneNumber}'";
            string phoneNumber = db.Query<string>(sqlQueryPhoneNumber).FirstOrDefault();
            if (phoneNumber != null)
            {
                errorMsg.devMsg.Add(MISA.ApplicationCore.Properties.Resources.ErrorMsg_DuplicateEmployeePhoneNumber_dev);
                errorMsg.userMsg.Add(MISA.ApplicationCore.Properties.Resources.ErrorMsg_DuplicateEmployeePhoneNumber_user);
                isValid = false;
            }
            if (employee.Email == "")
            {
                errorMsg.devMsg.Add(MISA.ApplicationCore.Properties.Resources.ErrorMsg_DuplicateEmployeeEmail_dev);
                errorMsg.userMsg.Add(MISA.ApplicationCore.Properties.Resources.ErrorMsg_DuplicateEmployeeEmail_user);
                isValid = false;
            }
            var sqlQueryEmail = $"SELECT e.Email FROM Employee e WHERE e.Email = '{employee.Email}'";
            string email = db.Query<string>(sqlQueryEmail).FirstOrDefault();
            if (email != null)
            {
                errorMsg.devMsg.Add(MISA.ApplicationCore.Properties.Resources.ErrorMsg_DuplicateEmployeeEmail_dev);
                errorMsg.userMsg.Add(MISA.ApplicationCore.Properties.Resources.ErrorMsg_DuplicateEmployeeEmail_user);
                isValid = false;
            }
            if (employee.IdentifyNumber == "")
            {
                errorMsg.devMsg.Add(MISA.ApplicationCore.Properties.Resources.ErrorMsg_NullEmployeeIDNumber_dev);
                errorMsg.userMsg.Add(MISA.ApplicationCore.Properties.Resources.ErrorMsg_NullEmployeeIDNumber_user);
                isValid = false;
            }
            var sqlQueryIDNumber = $"SELECT e.IdentifyNumber FROM Employee e WHERE e.IdentifyNumber = '{employee.IdentifyNumber}'";
            string identifyNumber = db.Query<string>(sqlQueryIDNumber).FirstOrDefault();
            if (identifyNumber != null)
            {
                errorMsg.devMsg.Add(MISA.ApplicationCore.Properties.Resources.ErrorMsg_DuplicateEmployeeIDNumber_dev);
                errorMsg.userMsg.Add(MISA.ApplicationCore.Properties.Resources.ErrorMsg_DuplicateEmployeeIDNumber_user);
                isValid = false;
            }
            return isValid;
        }
        /// <summary>
        /// Cập nhật thông tin nhân viên
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>Số bản ghi cập nhật thành công</returns>
        /// CreatedBy: BDHIEU (01/02/2021)
        public int UpdateEmployee(Employee employee)
        {
            int rowAffect = _employeeRepository.UpdateEmployee(employee);
            return rowAffect;
        }
        /// <summary>
        /// Xóa nhân viên
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>Số bản ghi xóa thành công</returns>
        /// CreatedBy: BDHIEU (01/02/2021)
        public int DeleteEmployee(Guid employeeId)
        {
            int res = _employeeRepository.DeleteEmployee(employeeId);
            return res;
        }
        /// <summary>
        /// Lấy nhân viên theo id
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns>Thông tin nhân viên theo id</returns>
        /// CreatedBy: BDHIEU (01/02/2021)
        public Employee GetEmployeeById(Guid employeeId)
        {
            var employee = _employeeRepository.GetEmployeeById(employeeId);
            return employee;
        }
        /// <summary>
        /// Lấy mã nhân viên lớn nhất
        /// </summary>
        /// <returns>Mã nhân viên lớn nhất</returns>
        /// CreatedBy: BDHIEU (01/02/2021)
        public string GetMaxEmployeeCode()
        {
            var maxEmployeeCode = _employeeRepository.GetMaxEmployeeCode();
            return maxEmployeeCode;
        }
        /// <summary>
        /// Lấy số lượng nhân viên
        /// </summary>
        /// <returns>Số lượng nhân viên</returns>
        /// CreatedBy: BDHIEU (01/02/2021)
        public int GetNumberOfEmployee()
        {
            return _employeeRepository.GetNumberOfEmployee();
        }

        /// <summary>
        /// Lấy danh sách nhân viên theo vị trí
        /// </summary>
        /// <param name="positionId"></param>
        /// <returns>Danh sách nhân viên theo vị trí</returns>
        /// CreatedBy: BDHIEU (01/02/2021)
        public IEnumerable<EmployeeInfo> GetEmployeeByPosition(int positionId)
        {
            return _employeeRepository.GetEmployeeByPosition(positionId);
        }
        /// <summary>
        /// Lấy danh sách nhân viên theo phòng ban
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns>Danh sách nhân viên theo phòng ban</returns>
        /// CreatedBy: BDHIEU (01/02/2021)
        public IEnumerable<EmployeeInfo> GetEmployeeByDepartment(int departmentId)
        {
            return _employeeRepository.GetEmployeeByDepartment(departmentId);
        }
        /// <summary>
        /// Lấy danh sách nhân viên theo từ khóa tìm kiếm
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns>Danh sách nhân viên theo từ khóa tìm kiếm</returns>
        /// CreatedBy: BDHIEU (03/02/2021)
        public IEnumerable<EmployeeInfo> GetEmployeeBySearchText(string searchText)
        {
            return _employeeRepository.GetEmployeeBySearchText(searchText);
        }

        /// <summary>
        /// Lấy danh sách nhân viên theo vị trí và số lượng nhân viên
        /// </summary>
        /// <param name="positionStart"></param>
        /// <param name="offset"></param>
        /// <returns>Danh sách nhân viên theo vị trí và số lượng nhân viên</returns>
        /// CreatedBy: BDHIEU (04/02/2021)
        public IEnumerable<EmployeeInfo> GetEmployeeByIndexAndOffset(int positionStart, int offset)
        {
            return _employeeRepository.GetEmployeeByIndexAndOffset(positionStart, offset);
        }
        #endregion
    }
}
