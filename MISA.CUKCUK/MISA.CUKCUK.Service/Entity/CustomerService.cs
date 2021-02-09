using System;
using MISA.Common.Model;
using MISA.DataLayer.Interface;
using MISA.Service.Interface;

namespace MISA.Service.Entity
{
    /// <summary>
    /// Entity CusomerService kế thừa từ interface CustomerService
    /// </summary>
    public class CustomerService: BaseService<Customer>, ICustomerService
    {
        private readonly ICustomerDL _customerDL;

        public CustomerService(IBaseDL<Customer> baseDL, ICustomerDL customerDL): base (baseDL)
        {
            _customerDL = customerDL;
        }

        /// <summary>
        /// Insert khách hàng
        /// </summary>
        /// <param name="customer">Thực thể khách hàng</param>
        /// <returns>serviceResult</returns>
        /// CreatedBy Vtthien 08/02/21
        public ServiceResult InsertCustomer(Customer customer)
        {
            var serviceResult = new ServiceResult();
            var errorMsg = new ErrorMsg();

            // validate bắt buộc nhập
            // Bắt buộc nhập mã khách hàng
            if (customer.CustomerCode == null || customer.CustomerCode == string.Empty)
            {
                errorMsg.DevMsg = MISA.Common.Properties.Resources.Required_CustomerCode;
                errorMsg.UserMsg = MISA.Common.Properties.Resources.Error_UserMsg;
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
                return serviceResult;
            }
            // Bắt buộc nhập Email
            if (customer.Email == null || customer.Email == string.Empty)
            {
                errorMsg.DevMsg = MISA.Common.Properties.Resources.Required_Email;
                errorMsg.UserMsg = MISA.Common.Properties.Resources.Error_UserMsg;
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
                return serviceResult;
            }
            // Bắt buộc nhập số điện thoại
            if (customer.PhoneNumber == null || customer.PhoneNumber == string.Empty)
            {
                errorMsg.DevMsg = MISA.Common.Properties.Resources.Required_PhoneNumber;
                errorMsg.UserMsg = MISA.Common.Properties.Resources.Error_UserMsg;
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
                return serviceResult;
            }

            // validate không được trùng
            // validate trùng mã khách hàng, kiểm tra trong db có mã khách hàng chưa
            var isExisted = _customerDL.CheckCustomerCodeExisted(customer.CustomerCode);
            if (isExisted )
            {
                errorMsg.DevMsg = MISA.Common.Properties.Resources.Dupplicated_CustomerCode;
                errorMsg.UserMsg = MISA.Common.Properties.Resources.Error_UserMsg;
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
                return serviceResult;
            }

            //validate trùng số điện thoại
            isExisted = _customerDL.CheckPhoneNumberExisted(customer.PhoneNumber);
            if (isExisted)
            {
                errorMsg.DevMsg = MISA.Common.Properties.Resources.Dupplicated_PhoneNumber;
                errorMsg.UserMsg = MISA.Common.Properties.Resources.Error_UserMsg;
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
                return serviceResult;
            }
            // validate...gì nữa thì bổ sung sau
            //...

            var res = _customerDL.Insert(customer);
            if (res > 0)
            {
                serviceResult.Success = true;
                serviceResult.Data = res;
                return serviceResult;
            }
            else
            {
                serviceResult.Success = true;
                errorMsg.DevMsg = MISA.Common.Properties.Resources.HaveNoObject;
                errorMsg.UserMsg = MISA.Common.Properties.Resources.Error_UserMsg;
                serviceResult.Data = errorMsg;
                return serviceResult;
            }
        }

        /// <summary>
        /// Sửa khách hàng
        /// </summary>
        /// <param name="id"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        /// CreatedBy VTThien 08/02/21
        public ServiceResult UpdateCustomer(Guid id, Customer customer)
        {
            var serviceResult = new ServiceResult();
            var errorMsg = new ErrorMsg();
            if (id != customer.CustomerId)
            {
                return null;
            }

            // lay theo id
            var customerDelete = _customerDL.GetById(id);

            if (customerDelete != null)
            {
                var result = _customerDL.Update(customer);

                if (result > 0)
                {
                    serviceResult.Success = true;
                    serviceResult.Data = result;
                    return serviceResult;
                }
                else
                {
                    serviceResult.Success = false;
                    errorMsg.UserMsg = MISA.Common.Properties.Resources.Error_UserMsg;
                    serviceResult.Data = errorMsg;
                    return serviceResult;
                }
            }
            else
            {
                serviceResult.Success = true;
                errorMsg.DevMsg = MISA.Common.Properties.Resources.HaveNoObject;
                errorMsg.UserMsg = MISA.Common.Properties.Resources.Error_UserMsg;
                serviceResult.Data = errorMsg;
                return serviceResult;
            }
        }
    }
}
