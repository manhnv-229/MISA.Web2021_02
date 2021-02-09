using FresherProject.Common.Enum;
using FresherProject.Common.Result;
using FresherProject.DataLayer.Database;
using FresherProject.DataLayer.Interfaces;
using FresherProject.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FresherProject.Service
{
    public class BaseService<T> : IBaseService<T>
    {
        protected IDBConnector<T> _dBConnector;
        protected ServiceResult _serviceResult;
        public BaseService(IDBConnector<T> dBConnector)
        {
            _dBConnector = dBConnector;
            _serviceResult = new ServiceResult();

        }
        /// <summary>
        /// Hàm service lấy ra danh sách nhân viênn
        /// </summary>
        /// <returns>List Employee</returns>
        /// Created By: PVNgoc (07/02/2021)
        public ServiceResult GetAllData()
        {
            _serviceResult.Data = _dBConnector.GetAllData();
            return _serviceResult;
        }
        /// <summary>
        /// Validate việc thêm mới dữ liệu rồi tiến hành thêm mới
        /// </summary>
        /// <param name="entity">object thêm mới</param>
        /// <returns></returns>
        /// Created by: Ngoc (3/1/2021)
        public ServiceResult Insert(T t)
        {
            // Validate dữ liệu
            ValidateObject(t);
            //Kiểm tra Validate
            if (_serviceResult.MISACukCukCode == MISACukCukServiceCode.BadRequest)
            {
                return _serviceResult;
            }
            //Thêm mới
            var serviceResult = new ServiceResult()
            {
                Data = _dBConnector.Insert(t),
                Messenger = new List<string> { Properties.Resources.Msg_Success },
                MISACukCukCode = MISACukCukServiceCode.Success
            };
            return serviceResult;
        }
        protected virtual void ValidateObject(T t)
        {
        }
        /// <summary>
        /// Hàm service lấy đối tượng theo id
        /// </summary>
        /// <returns>object</returns>
        /// Created By: PVNgoc (07/02/2021)
        public ServiceResult GetById(Guid id)
        {
            _serviceResult.Data = _dBConnector.GetById(id);
            return _serviceResult;
        }
        /// <summary>
        /// Hàm service lấy ra danh sách nhân viên theo command text
        /// </summary>
        /// <returns>List Employee</returns>
        /// Created By: PVNgoc (07/02/2021)
        public ServiceResult GetAllData(string cmText)
        {
            _serviceResult.Data = _dBConnector.GetAllData(cmText);
            return _serviceResult;
        }
        /// <summary>
        /// Hàm service cập nhập đối tượng
        /// </summary>
        /// <param name="entity">Đối tượng cần cập nhật</param>
        /// <returns>List Employee</returns>
        /// Created By: PVNgoc (07/02/2021)
        public ServiceResult Update(T entity)
        {
            _serviceResult.Data = _dBConnector.Update(entity);
            return _serviceResult;
        }
        /// <summary>
        /// Hàm service Xóa đối tượng
        /// </summary>
        /// <param name="id">ID đối tượng cần xóa</param>
        /// <returns>List Employee</returns>
        /// Created By: PVNgoc (07/02/2021)
        public ServiceResult Delete(Guid id)
        {
            _serviceResult.Data = _dBConnector.Delete(id);
            return _serviceResult;
        }
    }
}
