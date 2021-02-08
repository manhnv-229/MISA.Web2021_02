using MisaCukCuk_ApplicationCore.BaseApplicationCore;
using MisaCukCuk_Entity.Common;
using MisaCukCuk_Entity.Models;
using MisaCukCuk_Infarstructure;
using MisaCukCuk_Infarstructure.Infarstructure.EmployeeInfarstructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MisaCukCuk_ApplicationCore.ApplicationCore.EmployeeApplicationCore
{
    public class EmployeeApplicationCore : BaseApplicationCore<Employee>, IEmployeeApplicationCore
    {
        IEmployeeInfarstructure _employeeInfarstructure;
        public EmployeeApplicationCore(IEmployeeInfarstructure employeeInfarstructure) : base(employeeInfarstructure)
        {
            _employeeInfarstructure = employeeInfarstructure;
        }
        /// <summary>
        /// Validate thêm mới dữ liệu Employee
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="errorMsg"></param>
        /// <returns>true : đúng; false: trùng số điện thoại || trùng mã khách hàng || mã khách hàng để trống</returns>
        protected override async Task<bool> ValidateDataInsert(Employee employee, ErrorMsg errorMsg = null)
        {
            var service = new ServiceResult();
            //var _db = new MisaCukCukContext<Employee>();
            var isValid = true;
            #region kiểm tra mã nhân viên có trống hay không?
            if (employee.EmployeeCode == null || employee.EmployeeCode == string.Empty)
            {
                errorMsg.UserMsg.Add(MisaCukCuk_Entity.Properties.Resources.ErroService_EmptyEmployeeCode);
                service.Success = false;
                service.Data = errorMsg;
                isValid = false;
            }
            #endregion

            #region kiểm tra trùng mã nhân viên
            var isExitByCode = await _employeeInfarstructure.CheckCodeExit(employee.EmployeeCode);
            if (isExitByCode == false)
            {
                errorMsg.UserMsg.Add(MisaCukCuk_Entity.Properties.Resources.ErroService_DuplicateEmployeeCode);
                service.Success = false;
                service.Data = errorMsg;
                isValid = false;
            }
            #endregion

            #region kiểm tra trùng số điện thoại
            var isExitPhoneNumber = await _employeeInfarstructure.CheckPhoneNumberExit(employee.PhoneNumber);
            if (isExitPhoneNumber == false)
            {
                errorMsg.UserMsg.Add(MisaCukCuk_Entity.Properties.Resources.ErroService_DuplicatePhoneNumber);
                service.Success = false;
                service.Data = errorMsg;
                isValid = false;
            }
            #endregion

            return isValid;
        }
        /// <summary>
        /// Validate sửa dữ liệu Employee
        /// CreateBy: MinhHq(08/02/2021)
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="errorMsg"></param>
        /// <returns>true : đúng; false: trùng số điện thoại || trùng mã khách hàng || mã khách hàng để trống</returns>
        protected override async Task<bool> ValidateDataUpdate(Employee employee, ErrorMsg errorMsg = null)
        {
            var service = new ServiceResult();
            //var _db = new MisaCukCukContext<Employee>();
            var isValid = true;

            #region kiểm tra mã nhân viên có để trống hay không?
            if (employee.EmployeeCode == null || employee.EmployeeCode == string.Empty)
            {
                errorMsg.UserMsg.Add(MisaCukCuk_Entity.Properties.Resources.ErroService_EmptyEmployeeCode);
                service.Success = false;
                service.Data = errorMsg;
                isValid = false;
            }
            #endregion

            #region kiểm tra trùng mã nhân viên
            var isExitByCode = await _employeeInfarstructure.CheckCodeExit(employee.EmployeeCode);
            if (isExitByCode == false)
            {
                errorMsg.UserMsg.Add(MisaCukCuk_Entity.Properties.Resources.ErroService_DuplicateEmployeeCode);
                service.Success = false;
                service.Data = errorMsg;
                isValid = false;
            }
            #endregion

            #region kiểm tra trùng số điện thoại
            var isExitPhoneNumber = await _employeeInfarstructure.CheckPhoneNumberExit(employee.PhoneNumber);
            if (isExitPhoneNumber == false)
            {
                errorMsg.UserMsg.Add(MisaCukCuk_Entity.Properties.Resources.ErroService_DuplicatePhoneNumber);
                service.Success = false;
                service.Data = errorMsg;
                isValid = false;
            }
            #endregion

            return isValid;
        }
    }
}
