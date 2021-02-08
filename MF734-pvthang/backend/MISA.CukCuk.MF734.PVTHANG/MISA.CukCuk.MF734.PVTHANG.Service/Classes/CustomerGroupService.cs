using MISA.CukCuk.MF734.PVTHANG.Common.Models;
using MISA.CukCuk.MF734.PVTHANG.DataLayer.Interfaces;
using MISA.CukCuk.MF734.PVTHANG.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.MF734.PVTHANG.Service.Classes
{
    public class CustomerGroupService : BaseService<CustomerGroup>, ICustomerGroupService
    {
        public CustomerGroupService(ICustomerGroupRepository customerGroupService) : base(customerGroupService)
        {

        }

        public override ServiceResult GetById(string id)
        {
            _serviceResult.Code = Common.Enum.ResultCode.Unauthorized;
            _serviceResult.Message = Common.Properties.Resources.ErrorUnauthorized;
            return _serviceResult;
        }

        public override ServiceResult Delete(string id)
        {
            _serviceResult.Code = Common.Enum.ResultCode.Unauthorized;
            _serviceResult.Message = Common.Properties.Resources.ErrorUnauthorized;
            return _serviceResult;
        }

        protected override bool ValidateData(CustomerGroup entity)
        {
            _serviceResult.Code = Common.Enum.ResultCode.Unauthorized;
            _serviceResult.Message = Common.Properties.Resources.ErrorUnauthorized;
            return false;
        }
    }
}
