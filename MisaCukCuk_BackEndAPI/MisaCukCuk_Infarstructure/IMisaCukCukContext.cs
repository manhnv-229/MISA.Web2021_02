using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MisaCukCuk_Infarstructure
{
    public interface IMisaCukCukContext<T>
    {
        /// <summary>
        /// Lấy tất cả bản ghi
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        /// <returns>Trả về danh sách truy vấn</returns>
        Task<IEnumerable<T>> GetAllData();
        /// <summary>
        /// Lấy bản ghi theo ID
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        /// <param name="code"></param>
        /// <returns>Trả về bản ghi có Id truyền vào</returns>
        Task<IEnumerable<T>> GetByID(Guid code);
        /// <summary>
        /// Thêm mới bản ghi
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Trả về: 1: thành công; 0: thất bại</returns>
        Task<int> Insert(T entity);
        /// <summary>
        /// Chỉnh sửa bản ghi
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Trả về : 1: Chỉnh sửa thành công; 0: Chỉnh sửa thất bại</returns>
        Task<int> Update(T entity);
        /// <summary>
        /// Xóa bản ghi theo ID
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        /// <param name="code"></param>
        /// <returns>trả về: 1: xóa thành công; 2: xóa thất bại</returns>
        Task<int> DeleteById(Guid code);
        /// <summary>
        /// Check trùng mã Code
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        /// <param name="code"></param>
        /// <returns>true:không trùng mã; false: trùng mã</returns>
        Task<bool> CheckCodeExit(string code);
        /// <summary>
        /// Check trùng số điện thoại
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns>true: không trùng số điện thoại; false: trùng số điện thoại</returns>
        Task<bool> CheckPhoneNumberExit(string phoneNumber);
        /// <summary>
        /// Check trùng tên
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        /// <param name="name"></param>
        /// <returns>true: không trùng tên; false: trùng tên</returns>
        Task<bool> CheckNameExit(string name);
    }
}
