using MISA.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Service.interfaces
{
    public interface IEmployeeService: IBaseService<Employee>
    {
        /// <summary>
        /// Lấy danh sách theo trang 
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu truyền vào</typeparam>
        /// <param name="pageNumber">Vị trí</param>
        /// <param name="limit">Giới hạn bản ghi</param>
        /// <returns></returns>
        /// Created by PN Thuận : 6/2/2021
        ServiceResult GetAllData<T>(int pageNumber, int limit);
        /// <summary>
        /// Trả về mã lớn nhất của đối tượng
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu truyền vào</typeparam>
        /// <returns></returns>
        /// Created by PN Thuận : 6/2/2021
        ServiceResult GetMaxCode<T>();
        /// <summary>
        /// Trả về danh sách các đối tượng theo vị trí, chức vụ
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu truyền vào</typeparam>
        /// <param name="position">Tên vị trí, chức vụ</param>
        /// <returns></returns>
        /// Created by PN Thuận : 6/2/2021
        ServiceResult GetAllEmployeeByPosition<T>(string position);
        /// <summary>
        /// Trả vè danh sách các đối tượng theo phòng ban
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu truyền vào</typeparam>
        /// <param name="department">Tên phòng ban</param>
        /// <returns></returns>
        /// Created by PN Thuận : 6/2/2021
        ServiceResult GetAllEmployeeByDepartment<T>(string department);
        /// <summary>
        /// Lọc danh sách các đối tượng theo Mã, Họ tên, Số điện thoại, Vị trí/ Chức vụ, Phòng ban
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu truyền vào</typeparam>
        /// <param name="searchText">Chuỗi gồm : Họ tên || Mã đối tượng || Số điện thoại</param>
        /// <param name="department">Id phòng ban || Null</param>
        /// <param name="position">Id vị trí/chức vu || Null</param>
        /// <returns></returns>
        /// Created by PN Thuận : 6/2/2021
        ServiceResult SearchOther<T>(string searchText, Guid? department, Guid? position);
        /// <summary>
        /// Lọc sánh sách các đối tượng theo vị trí/ chức vụ và phòng ban
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu truyền vào</typeparam>
        /// <param name="positionName">Tên vị trí/ chức vụ</param>
        /// <param name="departmentName">Tên phòng ban</param>
        /// <returns></returns>
        /// Created by PN Thuận : 6/2/2021
        ServiceResult SearchOther<T>(string positionName, string departmentName);
        /// <summary>
        /// Lấy thông tin đối tượng theo Id
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu truyền vào</typeparam>
        /// <param name="id">Id của đối tượng</param>
        /// <returns></returns>
        /// Created by PN Thuận : 6/2/2021
        ServiceResult GetEntityById<T>(string id);
        /// <summary>
        /// Thêm đối tượng vào danh sách
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu truyền vào</typeparam>
        /// <param name="entity">Đối tượng cần chèn</param>
        /// <returns></returns>
        /// Created by PN Thuận : 6/2/2021       
        
    }
}
