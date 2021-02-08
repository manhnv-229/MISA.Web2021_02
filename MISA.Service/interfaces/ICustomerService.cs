using MISA.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Service.interfaces
{
    public interface ICustomerService : IBaseService<Customer>
    {
        /// <summary>
        /// Lấy danh sách theo trang 
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu truyền vào</typeparam>
        /// <param name="pageNumber">Vị trí</param>
        /// <param name="limit">Giới hạn bản ghi</param>
        /// <returns></returns>
        /// Created by PN Thuận : 6/2/2021
        ServiceResult GetAllData(int pageNumber, int limit);
        /// <summary>
        /// Trả về mã lớn nhất của đối tượng
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu truyền vào</typeparam>
        /// <returns></returns>
        /// Created by PN Thuận : 6/2/2021
        ServiceResult GetMaxCode();
        /// <summary>
        /// Lọc danh sách các đối tượng theo Mã, Họ tên, Số điện thoại, Vị trí/ Chức vụ, Phòng ban
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu truyền vào</typeparam>
        /// <param name="searchText">Chuỗi gồm : Họ tên || Mã đối tượng || Số điện thoại</param>
        /// <param name="department">Id phòng ban || Null</param>
        /// <param name="position">Id vị trí/chức vu || Null</param>
        /// <returns></returns>
        /// Created by PN Thuận : 6/2/2021
        ServiceResult SearchOther(string searchText);
        /// <summary>
        /// Lấy thông tin đối tượng theo Id
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu truyền vào</typeparam>
        /// <param name="id">Id của đối tượng</param>
        /// <returns></returns>
        /// Created by PN Thuận : 6/2/2021
        ServiceResult GetEntityById(string id);  

    }
}
