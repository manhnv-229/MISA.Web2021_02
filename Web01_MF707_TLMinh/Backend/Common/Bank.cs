using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common
{
    public class Bank
    {
        /// <summary>
        /// Tài khoản ngân hàng Id
        /// </summary>
        public Guid? BankId { get; set; }
        /// <summary>
        /// Chủ tài khoản Id
        /// </summary>
        public Guid? UserId { get; set; }
        /// <summary>
        /// Số tài khoản
        /// </summary>
        public string BankCode { get; set; }
        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        public string NameBank { get; set; }
        /// <summary>
        /// Chi nhánh ngân hàng
        /// </summary>
        public string BranchBank { get; set; }
        /// <summary>
        /// Tỉnh/TP của ngân hàng
        /// </summary>
        public string PlaceBank { get; set; }
    }
}
