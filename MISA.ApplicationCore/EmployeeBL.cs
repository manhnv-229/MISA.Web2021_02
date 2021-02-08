using MISA.ApplicationCore.Interface;
using MISA.Common;
using MISA.Common.Model;
using MISA.Infrastructure;
using MISA.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore
{
    public class EmployeeBL:BaseBL<Employee>, IEmployeeBL
    {
        #region DECLARE
        IEmployeeDL _employeeDL;
        #endregion

        #region Contructor
        public EmployeeBL(IEmployeeDL employeeDL): base(employeeDL)
        {
            _employeeDL = employeeDL;
        }
        #endregion

        #region Methods
        public IEnumerable<T> GetEmployeeCodeM<T>() {
            return _employeeDL.GetEmployeeCodeM<T>();
        }

        public IEnumerable<T> GetDataPage<T>(int offset,int size)
        {
            return _employeeDL.GetDatapage<T>(offset, size);
        }
        public long GetCountData<T>()
        {
            return _employeeDL.GetCountdata<T>();
        }
        //lấy dữ liệu bằng id 
        public IEnumerable<T> GetDataById<T>(string id)
        {
            return _employeeDL.GetEmployeeById<T>(id);
        }
        public ServiceResult InsertEmployee(Employee employee)
        {
            var serviceResult = this.CheckDuplicateInsert(employee);
            if (!serviceResult.Success)
            {
                return serviceResult;
            }
            serviceResult = this.CheckEmpty(employee);
            if (serviceResult.Success)
            {
                serviceResult.Data = _employeeDL.InsertData(employee);
            }
            return serviceResult;
        }
        //Cập nhật nhân viên
        public ServiceResult UpdateEmployee(Employee employee)
        {
            var serviceResult = this.CheckDuplicateUpDate(employee);
            if (!serviceResult.Success)
            {
                return serviceResult;
            }
            serviceResult = this.CheckEmpty(employee);
            if (serviceResult.Success)
            {
                serviceResult.Data = _employeeDL.UpdateData(employee);
            }
            return serviceResult;
        }
        //Xóa nhân viên
        public int DeleteEmployee(Employee employee)
        {
            if (!_employeeDL.CheckDuplicateEmployeeId(employee.EmployeeId.ToString()))
                return -1;
            return _employeeDL.DeleteEmployee(employee);
        }

        //show lỗi cho người dùng 
        public ServiceResult CheckDuplicateInsert(Employee employee)
        {
            var errorMsg = new ErrorMsg();
            var serviceResult = new ServiceResult();
            serviceResult.Success = true;
            if (_employeeDL.CheckDuplicateIndentify(employee))
            {
                errorMsg.DevMsg = "CMT bị trùng ";
                errorMsg.UserMsg.Add(MISA.Common.Properties.Resources.ErrorMsg_DuplicateIndentify);
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
            }

            if (_employeeDL.CheckDuplicatePhone(employee))
            {
                errorMsg.DevMsg = "Sđt bị trùng";
                errorMsg.UserMsg.Add(MISA.Common.Properties.Resources.ErrorMsg_DuplicatePhoneNumber);
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
            }
            if (_employeeDL.CheckDuplicateEmployeeCode(employee))
            {
                errorMsg.DevMsg = "Mã code bị trùng";
                errorMsg.UserMsg.Add(MISA.Common.Properties.Resources.ErrorMsg_DuplicateCode);
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
            }
            return serviceResult;
        }

        public ServiceResult CheckEmpty(Employee employee)
        {
            var errorMsg = new ErrorMsg();
            var serviceResult = new ServiceResult();
            serviceResult.Success = true;
            if (_employeeDL.CheckEmpty(employee) == -3)
            {
                errorMsg.DevMsg = "Tên bị bỏ trống";
                errorMsg.UserMsg.Add(MISA.Common.Properties.Resources.ErrorMsg_EmptyFullName);
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
            }
            if (_employeeDL.CheckEmpty(employee) == -4)
            {
                errorMsg.DevMsg = "CMT bị bỏ trống";
                errorMsg.UserMsg.Add(MISA.Common.Properties.Resources.ErrorMsg_EmptyIndentifyNumber);
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
            }
            if (_employeeDL.CheckEmpty(employee) == -5)
            {
                errorMsg.DevMsg = "Email bị bỏ trống";
                errorMsg.UserMsg.Add(MISA.Common.Properties.Resources.ErrorMsg_EmptyEmail);
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
            }
            if (_employeeDL.CheckEmpty(employee) == -6)
            {
                errorMsg.DevMsg = "Sđt bị bỏ trống";
                errorMsg.UserMsg.Add(MISA.Common.Properties.Resources.ErrorMsg_EmptyPhoneNumber);
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
            }
            
            return serviceResult;
        }

        public ServiceResult CheckDuplicateUpDate(Employee employee)
        {
            var errorMsg = new ErrorMsg();
            var serviceResult = new ServiceResult();
            serviceResult.Success = true;
            if (_employeeDL.CheckDuplicateIndentifyandId(employee))
            {
                errorMsg.DevMsg = "CMT bị trùng ";
                errorMsg.UserMsg.Add(MISA.Common.Properties.Resources.ErrorMsg_DuplicateIndentify);
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
            }

            if (_employeeDL.CheckDuplicatePhoneandId(employee))
            {
                errorMsg.DevMsg = "Sđt bị trùng";
                errorMsg.UserMsg.Add(MISA.Common.Properties.Resources.ErrorMsg_DuplicatePhoneNumber);
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
            }
    
            return serviceResult;
        }
        #endregion



    }
}
