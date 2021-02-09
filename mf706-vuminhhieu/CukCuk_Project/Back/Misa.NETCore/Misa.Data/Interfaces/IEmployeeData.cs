using Misa.Common.Entities;
using Misa.Common.Requests.Employee;
using Misa.Common.Results.model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Misa.Data.Interfaces
{
    public interface IEmployeeData : IBaseData<Employee>
    {
        /// <summary>
        /// Lấy danh sách thông tin nhân đầy đủ - kỹ thuật DI
        /// </summary>
        /// <param name="pageRequest"> theo keyword, id phòng ban, id vị trí, trang số, sô bản ghi</param>
        /// <returns>danh sách nhân viên</returns>
        /// create:5/2/2021
        public Task<IEnumerable<EmployeeResult>> GetData(PageRequest pageRequest);

        /// <summary>
        /// Lấy danh sách đầy đủ thông tin nhân - kỹ thuật DI
        /// </summary>
        /// <returns>danh sách nhân viên</returns>
        /// create:5/2/2021
        public Task<IEnumerable<EmployeeResult>> GetData();

        /// <summary>
        /// Lấy danh sách nhân viên theo mã - kỹ thuật DI
        /// </summary>
        /// <param name="employeeCode"> mã nhân viên</param>
        /// <returns>danh sách nhân viên</returns>
        /// create: 5/2/2021
        public Task<IEnumerable<Employee>> GetByEmployeeCode(string employeeCode);

        /// <summary>
        /// lấy danh sách nhân viên theo số điện thoại - kỹ thuật DI
        /// </summary>
        /// <param name="phoneNumber"> số điện thoại</param>
        /// <returns>danh sách nhân viên</returns>
        /// create: 5/2/2021
        public Task<IEnumerable<Employee>> GetByPhoneNumber(string phoneNumber);

        /// <summary>
        /// Lất danh sách nhân viên theo email - kỹ thuật DI
        /// </summary>
        /// <param name="email">email</param>
        /// <returns>danh sách nhân viên</returns>
        public Task<IEnumerable<Employee>> GetByEmail(string email);
       
    }
}
