using Microsoft.AspNetCore.Mvc;
using MISA.Common.Enum;
using MISA.Common.Models;
using MISA.Common;
using MISA.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MISA.Service.interfaces;

namespace MISA.Service
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        #region Declare
        
        #endregion
        #region Constructor
        public EmployeeService(IDbConnector dbConnector) : base(dbConnector)
        {
        }
        #endregion
        #region Method      
        /// <summary>
        /// Lấy danh sách theo trang 
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu truyền vào</typeparam>
        /// <param name="pageNumber">Vị trí</param>
        /// <param name="limit">Giới hạn bản ghi</param>
        /// <returns></returns>
        /// Created by PN Thuận : 2/1/2021
        public ServiceResult GetAllData(int pageNumber, int limit)
        {
            return new ServiceResult()
            {
                Data = _dbConnector.GetAllData<Employee>(pageNumber, limit),
                userMsg = new List<string>(),
                Code = EnumPattern.Success
            };
        }

        /// <summary>
        /// Trả về mã lớn nhất của đối tượng
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu truyền vào</typeparam>
        /// <returns></returns>
        /// Created by PN Thuận : 2/1/2021
        public ServiceResult GetMaxCode()
        {
            return new ServiceResult()
            {
                Data = _dbConnector.GetMaxCode<Employee>(),
                userMsg = new List<string>(),
                Code = EnumPattern.Success
            };
        }
        /// <summary>
        /// Trả về danh sách các đối tượng theo vị trí, chức vụ
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu truyền vào</typeparam>
        /// <param name="position">Tên vị trí, chức vụ</param>
        /// <returns></returns>
        /// Created by PN Thuận : 2/1/2021
        public ServiceResult GetAllEmployeeByPosition(string position)
        {
            return new ServiceResult()
            {
                Data = _dbConnector.GetAllEmployeeByPosition<Employee>(position),
                userMsg = new List<string>(),
                Code = EnumPattern.Success
            };
        }
        /// <summary>
        /// Trả vè danh sách các đối tượng theo phòng ban
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu truyền vào</typeparam>
        /// <param name="department">Tên phòng ban</param>
        /// <returns></returns>
        /// Created by PN Thuận : 2/1/2021
        public ServiceResult GetAllEmployeeByDepartment(string department)
        {
            return new ServiceResult()
            {
                Data = _dbConnector.GetAllEmployeeByDepartment<Employee>(department),
                userMsg = new List<string>(),
                Code = EnumPattern.Success
            };
        }
        /// <summary>
        /// Lọc danh sách các đối tượng theo Mã, Họ tên, Số điện thoại, Vị trí/ Chức vụ, Phòng ban
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu truyền vào</typeparam>
        /// <param name="searchText">Chuỗi gồm : Họ tên || Mã đối tượng || Số điện thoại</param>
        /// <param name="department">Id phòng ban || Null</param>
        /// <param name="position">Id vị trí/chức vu || Null</param>
        /// <returns></returns>
        /// Created by PN Thuận : 2/1/2021
        public ServiceResult SearchOther(string searchText, Guid? department, Guid? position)
        {
            if (searchText.Trim().Length > 50)
            {
                return new ServiceResult()
                {
                    Code = EnumPattern.BadRequest,
                    userMsg = new List<string> { MISA.Common.Properties.Resources.Error_Max_Length },
                    devMsg = new List<string> { MISA.Common.Properties.Resources.Error_Max_Length },
                };
            }
            else 
                return new ServiceResult()
                {
                    Data = _dbConnector.SearchOther<Employee>(searchText, department, position),
                    userMsg = new List<string>(),
                    Code = EnumPattern.Success
                };
        }
        /// <summary>
        /// Lọc sánh sách các đối tượng theo vị trí/ chức vụ và phòng ban
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu truyền vào</typeparam>
        /// <param name="positionName">Tên vị trí/ chức vụ</param>
        /// <param name="departmentName">Tên phòng ban</param>
        /// <returns></returns>
        /// Created by PN Thuận : 2/1/2021
        public ServiceResult SearchOther(string positionName , string departmentName)
        {
            return new ServiceResult()
            {
                Data = _dbConnector.SearchOther<Employee>(positionName, departmentName),
                userMsg = new List<string>(),
                Code = EnumPattern.Success
            };
        }
        /// <summary>
        /// Lấy thông tin đối tượng theo Id
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu truyền vào</typeparam>
        /// <param name="id">Id của đối tượng</param>
        /// <returns></returns>
        /// Created by PN Thuận : 2/1/2021
        public ServiceResult GetEntityById(string id)
        {
            return new ServiceResult()
            {
                Data = _dbConnector.GetById<Employee>(id),
                userMsg = new List<string>(),
                Code = EnumPattern.Success
            };
        }
        #endregion
    }
}
