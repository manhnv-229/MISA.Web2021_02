using Misa.CukCuk.Common;
using Misa8b.CukCuk.BL.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace Misa8b.CukCuk.BL.Interfaces
{
    public interface IEmployeeBL
    {
        /// <summary>
        /// Hàm thêm mới nhân viên
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public ActionServiceResult InsertData(Employee employee);
        /// <summary>
        /// Hàm lấy toàn bộ nhân viên
        /// </summary>
        /// <returns></returns>
        public ActionServiceResult GetAllData();
        /// <summary>
        /// Hàm lấy 1 nhân viên bằng mã Id của nhân viên
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionServiceResult GetDataById(Guid id);
        /// <summary>
        /// Hàm lấy danh sách nhân viên bằng tìm kiếm mã code, số điên thoại, tên 
        /// </summary>
        /// <param name="employeecode"></param>
        /// <param name="fullname"></param>
        /// <param name="phonenumber"></param>
        /// <returns></returns>
        public ActionServiceResult GetDataByOthers(string employeecode, string fullname, string phonenumber);
        /// <summary>
        /// Hàm cập nhật, sửa nhân viên
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public ActionServiceResult UpdateData(Employee employee);
        /// <summary>
        /// Hàm xóa nhân viên
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionServiceResult DeleteEmployee(Guid id);
        /// <summary>
        /// Hàm lấy danh sach nhân viên bằng tìm kiếm phòng ban và vị trí
        /// </summary>
        /// <param name="dep"></param>
        /// <param name="posi"></param>
        /// <returns></returns>
        public ActionServiceResult GetDataByDepAndPosi(string dep, string posi);
        /// <summary>
        /// hàm lấy nhaan viên bằng vị trí
        /// </summary>
        /// <param name="posi"></param>
        /// <returns></returns>
        public ActionServiceResult GetDataByPosi(string posi);
        /// <summary>
        /// hàm lấy nhân viên bằng phòng ban
        /// </summary>
        /// <param name="dep"></param>
        /// <returns></returns>
        public ActionServiceResult GetDataByDep(string dep);
        /// <summary>
        /// hàm lấy nhân viên bằng phân trang
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="ofset"></param>
        /// <returns></returns>
        public ActionServiceResult GetAllDataPagging(int limit, int ofset);
    }
}
