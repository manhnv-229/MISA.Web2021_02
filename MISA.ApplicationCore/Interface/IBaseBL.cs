using MISA.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Interface
{
    public interface IBaseBL<T>
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu của thuộc tính
        /// </summary>
        /// <typeparam name="T">Thuộc tính chung</typeparam>
        /// <returns></returns>
        ServiceResult GetData();
    }
}
