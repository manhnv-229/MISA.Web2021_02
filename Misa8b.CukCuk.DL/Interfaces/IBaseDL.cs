using System;
using System.Collections.Generic;
using System.Text;

namespace Misa8b.CukCuk.DL.Interfaces
{
    /// <summary>
    /// Interface định nghĩa các hàm cơ bản kết nối với database
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseDL<T>
    {
        /// <summary>
        /// lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns></returns>
        public List<T> GetDatas();
        /// <summary>
        /// lấy dữ liệu bằng pagging
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="ofset"></param>
        /// <returns></returns>
        public List<T> GetAllDataPagging(int limit, int ofset);
        /// <summary>
        /// thêm mới dữ liệu
        /// </summary>
        /// <param name="data"></param>
        void InsertData(T data);
        /// <summary>
        /// kiểm tra mã code của nhân viên đã có trong db hay chưa
        /// </summary>
        /// <param name="dataCode"></param>
        /// <returns></returns>
        bool CheckDuplicateDataCode(string dataCode);
        /// <summary>
        /// kiểm tra trùng số điện thoại
        /// </summary>
        /// <param name="PhoneNumber"></param>
        /// <returns></returns>
        public bool CheckDuplicateDataPhoneNumber(string PhoneNumber);
        /// <summary>
        /// lấy dữ liệu bằng mã id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetDataId(Guid id);
        /// <summary>
        /// kiểm tra trùng mã id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool CheckDuplicateDataId(Guid id);
        /// <summary>
        /// kiểm tra xem có bản ghi nào chứ đoạn tên nhập vào hay không
        /// </summary>
        /// <param name="FullNameContaints"></param>
        /// <returns></returns>
        public bool CheckListDataFullName(string FullNameContaints);
        /// <summary>
        /// kiểm tra xem có bản ghi nào chứ đoạn code nhập vào hay không
        /// </summary>
        /// <param name="DataCodeContaints"></param>
        /// <returns></returns>
        public bool CheckListDataCode(string DataCodeContaints);
        /// <summary>
        /// kiểm tra xem có bản ghi nào chứ đoạn số điện thoại nhập vào hay không
        /// </summary>
        /// <param name="phoneNumberContaints"></param>
        /// <returns></returns>
        public bool CheckListDataPhoneNumber(string phoneNumberContaints);
        /// <summary>
        /// cập nhât nhân viên
        /// </summary>
        /// <param name="data"></param>
        public void UpdateData(T data);
        /// <summary>
        /// xóa nhân viên
        /// </summary>
        /// <param name="id"></param>
        public void DeleteData(Guid id);
        /// <summary>
        /// kiểm tra trùng mã chứng minh nhân dân
        /// </summary>
        /// <param name="dataIdent"></param>
        /// <returns></returns>
        public bool CheckDuplicateIdent(string dataIdent);
    }
}
