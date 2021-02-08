using System;
using System.Collections.Generic;
using MISA.Service.Interfaces;
using MISA.Service.Entities;
using System.Net.Mail;

namespace MISA.Service
{
    public class BaseService<TEntity> : IBaseService<TEntity>
    {
        #region Declare Field
        IBaseReposity<TEntity> _baseReposity;
        ServiceResult _seviceResulst;
        #endregion
        
        #region Constructor
        public BaseService(IBaseReposity<TEntity> baseReposity){
            _baseReposity = baseReposity;
            _seviceResulst = new ServiceResult();
            _seviceResulst.Success = false;
            _seviceResulst.Data = "Khong Thuc hien duoc Service";
        }
        #endregion

        /// <summary>
        /// Hàm Check valid của Email
        /// </summary>
        /// <param name="emailaddress">string Email</param>
        /// <returns>Mail đúng định dạng trả về true, sai trả về false</returns>
        /// Created By : NHLong (06/02/2021)
        
        protected static bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        /// <summary>
        /// Hàm Kiểm tra string chỉ chứa toàn chữ số. Dùng cho số CMT/ số ĐT
        /// </summary>
        /// <param name="str">string cần kiểm tra</param>
        /// <returns>True nếu chỉ toàn số, false nếu có chứa loại ký tự khác</returns>
        /// Created By : NHLong (06/02/2021)
        protected static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
       
        public virtual ServiceResult GetEntities()
        {
            var employeeList = _baseReposity.GetEntities();
            if (employeeList != null)
            {
                _seviceResulst.Data = employeeList;
                _seviceResulst.Success = true;
            }
            return _seviceResulst;
        }

        public ServiceResult  GetEntityByCode(string entityCode)
        {
            var employee = _baseReposity.GetEntityByCode(entityCode);
            if (employee != null)
            {
                _seviceResulst.Data = employee;
                _seviceResulst.Success = true;
            }
            return _seviceResulst;
        }

        public ServiceResult GetEntityByID(Guid entityId)
        {
            var employeeList = _baseReposity.GetEntityByID(entityId);
            _seviceResulst.Data = employeeList;
            _seviceResulst.Success = true;
            return _seviceResulst;
        }
        
        public virtual ServiceResult AddEntity(TEntity entity)
        {
            var rowAffecteds = _baseReposity.AddEntity(entity);
            if (rowAffecteds >  0)
            {
                _seviceResulst.Success = true;
            }
            _seviceResulst.Data = rowAffecteds;
            return _seviceResulst;
        }


        public virtual ServiceResult UpdateEntity(TEntity entity)
        {
            
            var rowAffecteds = _baseReposity.UpdateEntity(entity);
            if (rowAffecteds >  0)
            {
                _seviceResulst.Data = rowAffecteds;
                _seviceResulst.Success = true;
            }
            return _seviceResulst;
        }

        public ServiceResult DeleteEntity(List<Guid> entityId)
        {
            var rowAffecteds = _baseReposity.DeleteEntity(entityId);
            if (rowAffecteds >  0)
            {
                _seviceResulst.Data = rowAffecteds;
                _seviceResulst.Success = true;
            }
            return _seviceResulst;
        }

    }
}
