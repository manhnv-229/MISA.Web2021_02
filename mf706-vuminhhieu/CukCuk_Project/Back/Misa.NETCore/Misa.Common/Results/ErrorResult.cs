using System;
using System.Collections.Generic;
using System.Text;

namespace Misa.Common.Results
{
    public  class ErrorResult
    {
        /// <summary>
        /// thông báo lỗi tới develop
        /// </summary>
        private string devMsg;

        /// <summary>
        /// thông báo lỗi tới người dùng
        /// </summary>
        private string userMsg;

        /// <summary>
        /// code bị lỗi
        /// </summary>
        private string errorCode;

        /// <summary>
        /// thông tin thêm
        /// </summary>
        private string moreInfor;

        /// <summary>
        /// todo...
        /// </summary>
        private string traceId;

       public string DevMsg { get => devMsg; set => devMsg = value; }
       public string UserMsg { get => userMsg; set => userMsg = value; }
       public string ErrorCode { get => errorCode; set => errorCode = value; }
       public string MoreInfor { get => moreInfor; set => moreInfor = value; }
       public string TraceId { get => traceId; set => traceId = value; }
    }
}
