using MISA.ApplicationCore.Entity;
using MISA.ApplicationCore.interfaces;
using MISA.ApplicationCore.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore
{
    public class DepartmentService: IDepartmentService
    {
        IDepartmentRepository _departmentRepository;
        IDbContext _dbContext;

        #region Constructor
        public DepartmentService(IDepartmentRepository departmentRepository, IDbContext dbContext)
        {
            _departmentRepository = departmentRepository;
            _dbContext = dbContext;
        }
        #endregion

        #region Method
        /// <summary>
        /// Lấy phòng ban theo id
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns>Phòng ban theo id</returns>
        /// CreatedBy: BDHIEU (01/02/2021)
        public string GetDepartmentById(int departmentId)
        {
            return _departmentRepository.GetDepartmentById(departmentId);
        }

        /// <summary>
        /// Lấy danh sách phòng ban 
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns>Danh sách phòng ban</returns>
        /// CreatedBy: BDHIEU (01/02/2021)
        public ServiceResult GetDepartments()
        {
            var serviceResult = new ServiceResult();
            serviceResult.Data = _dbContext.GetAll<EmployeeDepartment>();
            return serviceResult;
        }
        #endregion

    }
}
