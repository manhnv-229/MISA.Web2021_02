using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Service.Entities
{
    public class ServiceResult
    {
        /// <summary>
        /// Trang thai Service ( true - thanh cong, false - that bai)
        /// </summary>
        /// <value></value>
        public bool Success {get;set;}
        public object  Data { get; set; }     
        public string MisaCode { get; set; }
    }
}