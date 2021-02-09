using MISA.Common.Model;
using MISA.DataLayer;
using MISA.DataLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Service
{
    /// <summary>
    /// Base Class cho service
    /// </summary>
    /// <typeparam name="T">Thực thể cần thực hiện validate</typeparam>
    /// CreatedBy: NMDAT(07/02/2021)
    public class BaseService<T>
    {
        IBaseDBConnection<T> _baseDBConnection;
        
        public BaseService(IBaseDBConnection<T> baseDBConnection)
        {
            _baseDBConnection = baseDBConnection;
        }
        /// <summary>
        /// Lấy danh sách dư liệu
        /// </summary>
        /// <returns>Danh sách dữ liệu</returns>
        public virtual ServiceResult Get()
        {
            // Khởi tạo reponsive database
            var serviceResult = new ServiceResult();

            // Gọi đến method queyry của dbContex để thực hiện truy vấn vào database
            serviceResult.Data = _baseDBConnection.GetAll();
            serviceResult.MisaCode = MISACode.Success;

            return serviceResult;

        }
        /// <summary>
        /// Lấy dữ liệu theo Id
        /// </summary>
        /// <returns>Dữ liệu theo Id</returns>
        public virtual ServiceResult GetById(Guid id)
        {
            var className = typeof(T).Name;
            // Khởi tạo reponsive database
            var serviceResult = new ServiceResult();
            var sql = $"Select * from {className} Where {className}Id = '{id}'";

            // Gọi đến method queyry của dbContex để thực hiện truy vấn vào database
            serviceResult.Data = _baseDBConnection.GetAll(sql);
            serviceResult.MisaCode = MISACode.Success;

            return serviceResult;
        }
        /// <summary>
        /// Lấy dữ liệu theo số lượng 
        /// </summary>
        /// <param name="limit">số lượng đối tượng lấy ra</param>
        /// <param name="offset">bắt đâu lấy từ offset</param>
        /// <returns>trả về danh sách giới hạn cần lấy</returns>
        public virtual ServiceResult GetPagination(int limit,int offset)
        {
            var className = typeof(T).Name;
            // Khởi tạo reponsive database
            var serviceResult = new ServiceResult();
            var sql = $"SELECT * FROM {className} LIMIT {limit} OFFSET {offset}";

            // Gọi đến method queyry của dbContex để thực hiện truy vấn vào database
            serviceResult.Data = _baseDBConnection.GetAll(sql);
            serviceResult.MisaCode = MISACode.Success;

            return serviceResult;
        }
        /// <summary>
        /// Xử lý nghiệp vụ thêm mới khách hàng
        /// </summary>
        /// <param name="customer">đối tượng thêm mới</param>
        /// <returns>ServiceResult</returns>
        public virtual ServiceResult Insert(T entity)
        {
            // Khởi tạo đối tượng trả về
            var serviceResult = new ServiceResult();

            // Khởi tạo thông báo lỗi 
            var errorMsg = new ErrorMsg();

            // Thuực hiện validate dữ liệu
            var isValid = Validate(entity,errorMsg);

            //Validate dữ liệu oke thì thực hiện hàm thêm
            if (isValid)
            {
                var res = _baseDBConnection.InsertObject(entity);
                if (res > 0)
                {
                    serviceResult.Success = true;
                    serviceResult.Data = res;
                    serviceResult.MisaCode = MISACode.Success;
                    return serviceResult;
                }
                else
                {
                    serviceResult.Success = true;
                    serviceResult.Data = res;
                    serviceResult.MisaCode = MISACode.IsValid;
                    return serviceResult;
                }
            }
            else
            {
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
                serviceResult.MisaCode = MISACode.NotValid;
            }
            return serviceResult;
            
        }

        /// <summary>
        /// Thực hiện validate dữ liệu
        /// </summary>
        /// <param name="entity">Đối tượng validate</param>
        /// <param name="errorMsg">Messsnger gửi về</param>
        /// <returns>true : Dữ liệu hợp lệ ; false : Dữ liệu không hợp lệ</returns>
        protected virtual bool Validate(T entity,ErrorMsg errorMsg) {
            return true;
        }

        /// <summary>
        /// Xử lý nghiệp vụ Sửa
        /// </summary>
        /// <param name="customer">đối tượng Sửa</param>
        /// <returns>ServiceResult</returns>
        public virtual ServiceResult Update(T entity)
        {
            // Khởi tạo đối tượng trả về
            var serviceResult = new ServiceResult();

            // Khởi tạo thông báo lỗi 
            var errorMsg = new ErrorMsg();

            // Thuực hiện validate dữ liệu
            var isValid = ValidateUpdate(entity, errorMsg);

            //Validate dữ liệu oke thì thực hiện hàm thêm
            if (isValid)
            {
                var res = _baseDBConnection.UpdateObject(entity);
                if (res > 0)
                {
                    serviceResult.Success = true;
                    serviceResult.Data = res;
                    serviceResult.MisaCode = MISACode.Success;
                    return serviceResult;
                }
                else
                {
                    serviceResult.Success = true;
                    serviceResult.Data = res;
                    serviceResult.MisaCode = MISACode.IsValid;
                    return serviceResult;
                }
            }
            else
            {
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
                serviceResult.MisaCode = MISACode.NotValid;
            }
            return serviceResult;

        }

        /// <summary>
        /// Thực hiện validate dữ liệu update
        /// </summary>
        /// <param name="entity">Đối tượng validate</param>
        /// <param name="errorMsg">Messsnger gửi về</param>
        /// <returns>true : Dữ liệu hợp lệ ; false : Dữ liệu không hợp lệ</returns>
        protected virtual bool ValidateUpdate(T entity, ErrorMsg errorMsg)
        {
            return true;
        }

        /// <summary>
        /// Xử lý nghiệp vụ xóa
        /// </summary>
        /// <param name="entity">thực thể cần xóa</param>
        /// <returns></returns>
        public virtual ServiceResult Delete(T entity)
        {
            // Khởi tạo reponsive database
            var serviceResult = new ServiceResult();

            var res = _baseDBConnection.DeleteObject(entity);

            serviceResult.Data = res;
            serviceResult.MisaCode = MISACode.Success;

            return serviceResult;
        }

    }
}
