
using MISA.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Common.Models
{
    public class ServiceResult
    {
     
        public object Data { get; set; }

        //Chuỗi các câu thông báo
        public List<string> Messenger { get; set; } = new List<string>();

        /// <summary>
        /// Mã kết quả
        /// </summary>
        public MISAServiceCode MISACode { get; set; }
    }
}
