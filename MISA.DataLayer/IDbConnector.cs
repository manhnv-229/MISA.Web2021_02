using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataLayer
{
    public interface IDbConnector
    {
        /// <summary>
        /// Lấy danh sách nhân viên
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<T> GetAllData<T>();

        /// <summary>
        /// Lấy danh sách phòng ban
        /// </summary>
        /// <typeparam name="Department"></typeparam>
        /// <returns></returns>
        public IEnumerable<Department> GetAllDepartment<Department>();

        /// <summary>
        /// Lấy danh sách vị trí/ chức vụ
        /// </summary>
        /// <typeparam name="Position"></typeparam>
        /// <returns></returns>
        public IEnumerable<Position> GetAllPosition<Position>();

        /// <summary>
        /// Lấy danh sách nhân viên theo trang
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="PageNumber"> vị trí trang</param>
        /// <param name="Limit">Số lượng giới hạn</param>
        /// <returns>Danh sách nhân viên theo trang</returns>
        public IEnumerable<T> GetAllData<T>(int PageNumber, int Limit);

        /// <summary>
        /// Lấy danh sách nhân viên theo vị trí
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu trả về</typeparam>
        /// <param name="position">tên vị trí/ chức vụ</param>
        /// <returns>Danh sách nhân viên theo vị trí/chức vụ</returns>
        public IEnumerable<T> GetAllEmployeeByPosition<T>(string position);

        /// <summary>
        /// Lấy danh sách nhân viên theo phòng ban
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu trả về</typeparam>
        /// <param name="department">Tên phòng ban</param>
        /// <returns>Danh sách nhân viên theo phòng ban</returns>
        public IEnumerable<T> GetAllEmployeeByDepartment<T>(string department);

        /// <summary>
        /// Tìm kiếm nhân viên theo keywords
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu trả về</typeparam>
        /// <param name="searchText">keyword: Mã nhân viên, Tên nhân viên, Số điện thoại</param>
        /// <returns>Trả về danh sách theo keyword</returns>
        public IEnumerable<T> SearchOther<T>(string searchText, Guid? DepartmentId = null, Guid? PositionId = null);

        /// <summary>
        /// Tìm kiếm danh sách nhân viên theo phòng ban và vị trí/ chức vụ
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu trả về</typeparam>
        /// <param name="PositionSearch">Tên vị trí/chức vụ</param>
        /// <param name="DepartmentSearch">Tên phòng ban</param>
        /// <returns>Trả về danh sách theo yêu cầu</returns>
        public IEnumerable<T> SearchOther<T>(string PositionSearch, string DepartmentSearch);
        /// <summary>
        /// Lấy mã nhân viên hiện tại lớn nhất
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Trả về Mã nhân viên lớn nhất</returns>
        public IEnumerable<T> GetMaxCode<T>();
        /// <summary>
        /// lấy dữ liệu dựa vào commandtext
        /// </summary>
        /// <typeparam name="T">Kiểu object</typeparam>
        /// <param name="commandText">mã SQL</param>
        /// <return> số dòng trùng</returns>
        public IEnumerable<T> GetAllData<T>(string commandText);

        /// <summary>
        /// lay thong tin 1 nguoi dung
        /// </summary>
        /// <typeparam name="T">kieu du lieu cua nguoi dung</typeparam>
        /// <param name="id">id cua nguoi can tim</param>
        /// <returns>tra ve thong tin nguoi dung</returns>
        public T GetById<T>(object id);
        /// <summary>
        /// Thêm đối tượng vào danh sách
        /// </summary>
        /// <typeparam name="T">kiểu dữ liệu truyền vào</typeparam>
        /// <param name="entity">đối tượng truyền vào</param>
        /// <returns>trả về số dòng thay đổi</returns>
        public int Insert<T>(T entity);
        /// <summary>
        /// xóa nhân viên dựa vào Id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id">Id nhân viên </param>
        /// <returns>trả về số dòng thay đổi</returns>
        public int DeleteById<T>(object id);
        /// <summary>
        /// Sửa thông tin nhân viên
        /// </summary>
        /// <typeparam name="T">Kiểu dữ liệu đối tượng</typeparam>
        /// <param name="entity">Đối tượng cần sửa </param>
        /// <returns>Trả về số dòng chỉnh sửa</returns>
        public int ModifiedEntity<T>(T entity);
    }
}
