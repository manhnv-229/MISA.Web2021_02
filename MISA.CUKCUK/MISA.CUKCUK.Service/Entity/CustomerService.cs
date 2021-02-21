using System;
using MISA.Common.Model;
using MISA.DataLayer.Interface;
using MISA.Service.Interface;

namespace MISA.Service.Entity
{
    /// <summary>
    /// Entity CusomerService 
    /// </summary>
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        private readonly ICustomerDL _customerDL;

        public CustomerService(IBaseDL<Customer> baseDL, ICustomerDL customerDL) : base(baseDL)
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
                errorMsg.DevMsg = Common.Properties.Resources.Required_CustomerCode;
                errorMsg.UserMsg = Common.Properties.Resources.Error_UserMsg;
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
                return serviceResult;
            }
            // Bắt buộc nhập Email
            if (customer.Email == null || customer.Email == string.Empty)
            {
                errorMsg.DevMsg = Common.Properties.Resources.Required_Email;
                errorMsg.UserMsg = Common.Properties.Resources.Error_UserMsg;
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
                return serviceResult;
            }
            // Bắt buộc nhập số điện thoại
            if (customer.PhoneNumber == null || customer.PhoneNumber == string.Empty)
            {
                errorMsg.DevMsg = Common.Properties.Resources.Required_PhoneNumber;
                errorMsg.UserMsg = Common.Properties.Resources.Error_UserMsg;
                serviceResult.Success = false;
                serviceResult.Data = errorMsg;
                return serviceResult;
            }


            //kiểm tra xem khách hàng này có các trường bị trùng lặp không
            serviceResult = CheckDuplicateDataCustomer(customer);

            // nếu bị trùng lặp, trả về luôn lỗi
            if (!serviceResult.Success)
            {
                return serviceResult;
            }

            // thông tin khách hàng không bị trùng lặp ==> insert
            var res = _customerDL.Insert(customer);

            // insert thành công
            if (res > 0)
            {
                serviceResult.Success = true;
                serviceResult.Data = res;
                return serviceResult;
            }
            else
            {
                // insert thất bại
                serviceResult.Success = true;
                errorMsg.DevMsg = Common.Properties.Resources.HaveNoObject;
                errorMsg.UserMsg = Common.Properties.Resources.Error_UserMsg;
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
                // trước khi cập nhật, kiểm tra dữ liệu sau khi sửa có bị trùng lặp với người dùng khác hay không
                //kiểm tra xem khách hàng này có các trường bị trùng lặp không
                serviceResult = CheckDuplicateDataCustomer(customer, id.ToString());

                // nếu bị trùng lặp, trả về luôn lỗi
                if (!serviceResult.Success)
                {
                    return serviceResult;
                }

                // không bị trùng lặp mới cho phép cập nhật
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
                    errorMsg.UserMsg = Common.Properties.Resources.Error_UserMsg;
                    serviceResult.Data = errorMsg;
                    return serviceResult;
                }
            }
            else
            {
                serviceResult.Success = true;
                errorMsg.DevMsg = Common.Properties.Resources.HaveNoObject;
                errorMsg.UserMsg = Common.Properties.Resources.Error_UserMsg;
                serviceResult.Data = errorMsg;
                return serviceResult;
            }
        }

        /// <summary>
        /// Kiểm tra dữ liệu trùng lặp với một khách hàng
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="id">ID người dùng (Trong trường hợp sửa)</param>
        /// <returns></returns>
        private ServiceResult CheckDuplicateDataCustomer(Customer customer, string id = "")
        {
            var serviceResult = new ServiceResult();
            var errorMsg = new ErrorMsg();

            // validate không được trùng
            // validate trùng mã khách hàng, kiểm tra trong db có mã khách hàng chưa
            var isExisted = _customerDL.GetEntityByCode(customer.CustomerCode);
            // nếu có truyền id vào => case sửa
            if (!string.IsNullOrEmpty(id))
            {
                if (id != isExisted.CustomerId.ToString())
                {
                    errorMsg.DevMsg = Common.Properties.Resources.Dupplicated_CustomerCode;
                    errorMsg.UserMsg = Common.Properties.Resources.Error_UserMsg;
                    serviceResult.Success = false;
                    serviceResult.Data = errorMsg;
                    return serviceResult;
                }
            }
            else
            {
                if (isExisted != null)
                {
                    errorMsg.DevMsg = Common.Properties.Resources.Dupplicated_CustomerCode;
                    errorMsg.UserMsg = Common.Properties.Resources.Error_UserMsg;
                    serviceResult.Success = false;
                    serviceResult.Data = errorMsg;
                    return serviceResult;
                }
            }

            //validate trùng số điện thoại
            isExisted = _customerDL.GetEntityByField("PhoneNumber", customer.PhoneNumber);
            // nếu có truyền id vào => case sửa
            if (!string.IsNullOrEmpty(id))
            {
                if (id != isExisted.CustomerId.ToString())
                {
                    errorMsg.DevMsg = Common.Properties.Resources.Dupplicated_PhoneNumber;
                    errorMsg.UserMsg = Common.Properties.Resources.Error_UserMsg;
                    serviceResult.Success = false;
                    serviceResult.Data = errorMsg;
                    return serviceResult;
                }
            }
            else
            {
                if (isExisted != null)
                {
                    errorMsg.DevMsg = Common.Properties.Resources.Dupplicated_PhoneNumber;
                    errorMsg.UserMsg = Common.Properties.Resources.Error_UserMsg;
                    serviceResult.Success = false;
                    serviceResult.Data = errorMsg;
                    return serviceResult;
                }
            }

            return serviceResult;
        }


    }
}
