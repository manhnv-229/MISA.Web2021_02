using MISA.Common.Model;
using MISA.DataLayer.Interface;
using MISA.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Service
{

    public class BaseService<T>: IBaseService<T> where T:class
    {
        private readonly IBaseDL<T> _baseDL;

        public BaseService(IBaseDL<T> baseDL)
        {
            this._baseDL = baseDL;
        }

        /// <summary>
        /// Lấy tất cả đối tượng
        /// </summary>
        /// <returnsr>Danh sách đối tượng</returnsr></returns>
        /// CreatedBy VTThien 08/02/21
        public ServiceResult GetAll()
        {
            var result = new ServiceResult();
            var listEntity = _baseDL.GetAll();

            if (listEntity != null)
            {
                result.Data = listEntity;
                result.MISACode = "200";
                result.Success = true;
            }
            else
            {
                result.Data = new ErrorMsg()
                {
                    DevMsg = MISA.Common.Properties.Resources.HaveNoObject,
                    MoreInfo = MISA.Common.Properties.Resources.MoreInfo,
                    UserMsg = MISA.Common.Properties.Resources.Error_UserMsg
                };
                result.Success = false;
                result.MISACode = "400";
            }

            return result;
        }

        /// <summary>
        /// Lấy tất cả đối tượng theo Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Danh sách đối tượng</returns>
        /// CreatedBy VTThien 08/02/21
        public ServiceResult GetById(Guid id)
        {
            var result = new ServiceResult();
            var listEntity = _baseDL.GetById(id);

            if (listEntity != null)
            {
                result.Data = listEntity;
                result.MISACode = "200";
                result.Success = true;
            }
            else
            {
                result.Data = new ErrorMsg()
                {
                    DevMsg = MISA.Common.Properties.Resources.HaveNoObject,
                    MoreInfo = MISA.Common.Properties.Resources.MoreInfo,
                    UserMsg = MISA.Common.Properties.Resources.Error_UserMsg
                };
                result.Success = false;
                result.MISACode = "400";
            }

            return result;
        }
    }
}
