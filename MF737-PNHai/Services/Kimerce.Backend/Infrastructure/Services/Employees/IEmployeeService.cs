using Kimerce.Backend.Domain.Employees;
using Kimerce.Backend.Dto.Models.Employees;
using Kimerce.Backend.Dto.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kimerce.Backend.Infrastructure.Services.Employees
{
    /// <summary>
    /// Interface của Employee Service 
    /// </summary>
    public interface IEmployeeService
    {
        /// <summary>
        /// Lấy danh sách nhân viên theo filter, nếu không có params lock thì trả về tất
        /// </summary>
        /// <param name="Filter"></param>
        /// <returns></returns>
        public Task<List<EmployeeModel>> GetAll(String? Filter);
        /// <summary>
        /// Tạo một nhân viên mới
        /// </summary>
        /// <param name="employeeModel"></param>
        /// <returns></returns>
        public Task<BaseResult> Create(EmployeeModel employeeModel);
        /// <summary>
        /// Chỉnh sửa một nhân viên đã tồn tại
        /// </summary>
        /// <param name="employeeModel"></param>
        /// <returns></returns>
        public Task<BaseResult> Update(EmployeeModel employeeModel);
        /// <summary>
        /// Xóa một employee ra khỏi danh sách nhân viên
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<BaseResult> Delete(Guid id);

    }
}
