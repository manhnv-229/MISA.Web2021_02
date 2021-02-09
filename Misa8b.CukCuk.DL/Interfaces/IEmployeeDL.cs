using Misa.CukCuk.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Misa8b.CukCuk.DL.Interfaces
{
    public interface IEmployeeDL: IBaseDL<Employee>
    {
        /// <summary>
        /// lấy nhân viên bằng mã code, tên và số điện thoại
        /// </summary>
        /// <param name="employeecode"></param>
        /// <param name="fullname"></param>
        /// <param name="phonenumber"></param>
        /// <returns>trả về danh sach nhân viên thỏa mãn</returns>
        public List<Employee> GetEmployeeByOthers(string employeecode, string fullname, string phonenumber);
        /// <summary>
        /// lấy nhân viên bằng tên phòng ban và vị trí
        /// </summary>
        /// <param name="dep"></param>
        /// <param name="posi"></param>
        /// <returns>danh sách nhân viên thỏa mãn cả vị trí và chức vụ tương ứng</returns>
        public List<Employee> GetEmployeeByDepAndPosi(string dep, string posi);
        /// <summary>
        /// lấy nhân viên bằng vị trí
        /// </summary>
        /// <param name="posi"></param>
        /// <returns>danh sách vị trí</returns>
        public List<Employee> GetEmployeeByPosi(string posi);
        /// <summary>
        /// lấy nhân viên bằng phòng ban
        /// </summary>
        /// <param name="posi"></param>
        /// <returns>danh sách phòng ban</returns>
        public List<Employee> GetEmployeeByDep(string posi);

    }
}
