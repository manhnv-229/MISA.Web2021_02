using MISA.Common.Model;
using MISA.CUKCUK.DataLayer;
using MISA.DataLayer.Interface;
using MISA.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Service
{
    public class CustomerGroupService: BaseService<CustomerGroup>, ICustomerGroupService
    {
        private readonly ICustomerGroupDL _customerGroupDL;
        
        public CustomerGroupService(IBaseDL<CustomerGroup> baseDL, ICustomerGroupDL customerGroupDL) : base(baseDL)
        {
            _customerGroupDL = customerGroupDL;
        }

        public ServiceResult InsertCustomerGroup(CustomerGroup customerGroup)
        {
            var serviceResult = new ServiceResult();
            var errorMsg = new ErrorMsg();

            //kiểm tra xem khách hàng này có các trường bị trùng lặp không
            serviceResult = CheckDuplicateDataCustomerGroup(customerGroup , customerGroup.CustomerGroupId.ToString());

            // nếu bị trùng lặp, trả về luôn lỗi
            if (!serviceResult.Success)
            {
                return serviceResult;
            }

            // thông tin khách hàng không bị trùng lặp ==> insert
            var res = _customerGroupDL.Insert(customerGroup);

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

        public ServiceResult UpdateCustomerGroup(Guid id, CustomerGroup customerGroup)
        {
            var serviceResult = new ServiceResult();
            var errorMsg = new ErrorMsg();
            if (id != customerGroup.CustomerGroupId)
            {
                return null;
            }
            // lay theo id
            var customerDelete = _customerGroupDL.GetById(id);

            if (customerDelete != null)
            {
                // trước khi cập nhật, kiểm tra dữ liệu sau khi sửa có bị trùng lặp với người dùng khác hay không
                //kiểm tra xem khách hàng này có các trường bị trùng lặp không
                serviceResult = CheckDuplicateDataCustomerGroup(customerGroup , id.ToString());

                // nếu bị trùng lặp, trả về luôn lỗi
                if (!serviceResult.Success)
                {
                    return serviceResult;
                }

                // không bị trùng lặp mới cho phép cập nhật
                var result = _customerGroupDL.Update(customerGroup);

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

        private ServiceResult CheckDuplicateDataCustomerGroup(CustomerGroup customerGroup, string id = "")
        {
            var serviceResult = new ServiceResult();
            var errorMsg = new ErrorMsg();

            // validate không được trùng
            // validate trùng id customerGroup, kiểm tra trong db có mã khách hàng chưa
            var isExisted = _customerGroupDL.GetEntityByCode(customerGroup.CustomerGroupId.ToString());
            // nếu có truyền id vào => case sửa
            if (!string.IsNullOrEmpty(id))
            {
                if (id != isExisted.CustomerGroupId.ToString())
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
            return serviceResult;
        }

    }
}
