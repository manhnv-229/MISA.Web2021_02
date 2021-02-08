using Misa.Common.Entities;
using Misa.Common.Requests.Employee;
using Misa.Common.Results.model;
using Misa.Data.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Misa.Data.Version1
{
    ///DbConnection<Employee>: chỉ định lớp cha nếu như không dùng kỹ thuật DI
    public class EmployeeData : DbConnection<Employee>, IEmployeeData
    {
        IBaseData<Employee> _baseData;
        public EmployeeData(IBaseData<Employee> baseData) : base()
        {
            _baseData = baseData;
        }
        /// <summary>
        ///  Lấy danh sách thông tin nhân đầy đủ 
        /// </summary>
        /// <param name="pageRequest"> theo keyword, id phòng ban, id vị trí, trang số, sô bản ghi</param>
        /// <returns>danh sách nhân viên</returns>
        /// create:5/2/2021
        public async Task<IEnumerable<EmployeeResult>> GetData(PageRequest pageRequest)
        {
            int indexStart = (pageRequest.PageIndex - 1) * pageRequest.PageSize;            
            var queryString = "SELECT * FROM Employee e INNER JOIN EmployeeDepartment ed ON e.DepartmentId = ed.DepartmentId " +
                "INNER JOIN EmployeePosition ep ON e.PositionId = ep.PositionId" + 
                $" LIMIT {indexStart.ToString()}, {pageRequest.PageSize.ToString()}";
            return await _baseData.GetData<EmployeeResult>(queryString);
        }

        /// <summary>
        /// Lấy danh sách đầy đủ thông tin nhân
        /// </summary>        
        /// <returns>danh sách nhân viên </returns>
        /// create:5/2/2021
        public async Task<IEnumerable<EmployeeResult>> GetData()
        {
            var queryString = "SELECT * FROM Employee e INNER JOIN EmployeeDepartment ed ON e.DepartmentId = ed.DepartmentId " +
                "INNER JOIN EmployeePosition ep ON e.PositionId = ep.PositionId";
            return await _baseData.GetData<EmployeeResult>(queryString);
        }

        /// <summary>
        /// Lấy danh sách nhân viên theo mã
        /// </summary>
        /// <param name="employeeCode"> mã nhân viên</param>
        /// <returns>danh sách nhân viên</returns>
        /// create: 5/2/2021
        public async Task<IEnumerable<Employee>> GetByEmployeeCode(string employeeCode)
        {
            var query = $"SELECT * FROM Employee WHERE EmployeeCode = '{employeeCode}'";
            return await _baseData.GetData(query);
        }

        /// <summary>
        /// Lấy danh sách nhân viên theo số điên thoại 
        /// </summary>
        /// <param name="employeeCode"> mã nhân viên</param>
        /// <returns>danh sách nhân viên</returns>
        /// create: 5/2/2021
        public async Task<IEnumerable<Employee>> GetByPhoneNumber(string phoneNumber)
        {
            var query = $"SELECT * FROM Employee WHERE PhoneNumber = '{phoneNumber}'";
            return await _baseData.GetData(query);
        }

        /// <summary>
        /// Lấy danh sách nhân viên theo số điên thoại 
        /// </summary>
        /// <param name="employeeCode"> mã nhân viên</param>
        /// <returns>danh sách nhân viên</returns>
        /// create: 5/2/2021
        public async Task<IEnumerable<Employee>> GetByEmail(string email)
        {
            var query = $"SELECT * FROM Employee WHERE Email = '{email}'";
            return await _baseData.GetData(query);
        }
    }
}
