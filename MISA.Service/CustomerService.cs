using Microsoft.AspNetCore.Mvc;
using MISA.Common.Enum;
using MISA.Common.Models;
using MISA.Common;
using MISA.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MISA.Service.interfaces;

namespace MISA.Service
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        #region Declare

        #endregion
        #region Constructor
        public CustomerService(IDbConnector dbConnector) : base(dbConnector)
        {
        }
        #endregion
        #region Method      
        /// <summary>
        /// Lấy danh sách theo trang 
        /// </summary>
        /// <param name="pageNumber">Vị trí</param>
        /// <param name="limit">Giới hạn bản ghi</param>
        /// <returns></returns>
        /// Created by PN Thuận : 2/1/2021
        public ServiceResult GetAllData(int pageNumber, int limit)
        {
            return new ServiceResult()
            {
                Data = _dbConnector.GetAllData<Customer>(pageNumber, limit),
                userMsg = new List<string>(),
                Code = EnumPattern.Success
            };
        }

        /// <summary>
        /// Trả về mã lớn nhất của đối tượng
        /// </summary>
        /// <returns></returns>
        /// Created by PN Thuận : 2/1/2021
        public ServiceResult GetMaxCode()
        {
            return new ServiceResult()
            {
                Data = _dbConnector.GetMaxCode<Customer>(),
                userMsg = new List<string>(),
                Code = EnumPattern.Success
            };
        }
        /// <summary>
        /// Lọc danh sách các đối tượng theo Mã, Họ tên, Số điện thoại, Vị trí/ Chức vụ, Phòng ban
        /// </summary>
        /// <param name="searchText">Chuỗi gồm : Họ tên || Mã đối tượng || Số điện thoại</param>
        /// <returns></returns>
        /// Created by PN Thuận : 2/1/2021
        public ServiceResult SearchOther(string searchText)
        {
            if (searchText.Trim().Length > 50)
            {
                return new ServiceResult()
                {
                    Code = EnumPattern.BadRequest,
                    userMsg = new List<string> { MISA.Common.Properties.Resources.Error_Max_Length },
                    devMsg = new List<string> { MISA.Common.Properties.Resources.Error_Max_Length },
                };
            }
            else
                return new ServiceResult()
                {
                    Data = _dbConnector.SearchOther<Customer>(searchText),
                    userMsg = new List<string>(),
                    Code = EnumPattern.Success
                };
        }
        /// <summary>
        /// Lấy thông tin đối tượng theo Id
        /// </summary>
        /// <param name="id">Id của đối tượng</param>
        /// <returns></returns>
        /// Created by PN Thuận : 2/1/2021
        public ServiceResult GetEntityById(string id)
        {
            return new ServiceResult()
            {
                Data = _dbConnector.GetById<Customer>(id),
                userMsg = new List<string>(),
                Code = EnumPattern.Success
            };
        }
        #endregion
    }
}
