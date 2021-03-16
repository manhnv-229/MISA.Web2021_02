using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common
{
    public class Employeee
    {
        /// <summary>
        /// Nhân viên Id
        /// </summary>
        public Guid? EmployeeeId { get; set; }
        /// <summary>
        /// Mã nhân viên    
        /// </summary>
        public string EmployeeeCode { get; set; }
        /// <summary>
        /// Họ và tên
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }
        /// <summary>
        /// Giới tính (0: Nữ, 1 Nam)
        /// </summary>
        public int? Gender { get; set; }
        /// <summary>
        /// Phòng làm việc
        /// </summary>
        public Guid? PlaceWork { get; set; }
        /// <summary>
        /// Số chứng minh thư nhân dân
        /// </summary>
        public string Identity { get; set; }
        /// <summary>
        /// Ngày cấp chứng minh thư nhân dân
        /// </summary>
        public DateTime? IdentityDate { get; set; }
        /// <summary>
        /// Chức danh
        /// </summary>
        public string Position { get; set; }
        /// <summary>
        /// Nơi cấp chứng minh thư nhân dân
        /// </summary>
        public string IdentityPlace { get; set; }
        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Điện thoại di động
        /// </summary>
        public string CellPhone { get; set; }
        /// <summary>
        /// Điện thoại cố định
        /// </summary>
        public string HomePhone { get; set; }
        /// <summary>
        /// email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// tư cách (0 : nhà cung cấp, 1 : khách hàng)
        /// </summary>
        public int? Capacity { get; set; }
    }
}
