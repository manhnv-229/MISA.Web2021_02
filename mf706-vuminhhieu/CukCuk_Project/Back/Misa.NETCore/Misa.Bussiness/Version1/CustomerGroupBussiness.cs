using Misa.Common;
using Misa.Common.Enum;
using Misa.Data;
using Misa.Data.Version1;

namespace Misa.Bussiness.Version1
{
    public class CustomerGroupBussiness
    {
        private CustomerGroupData customerGroupData;
        public CustomerGroupBussiness()
        {
            customerGroupData = new CustomerGroupData();
        }
        /// <summary>
        /// lấy ra toàn bộ danh sách nhân viên
        /// </summary>
        /// <returns>ServiceResult</returns>
        /// update: 3/2/2021
        public ServiceResult GetData()
        {

            var listCustomerGroup = customerGroupData.GetData();
            return new ServiceResult()
            {
                Data = listCustomerGroup,
                Error = null,
                MISACukCukCode = MISACukCukServiceCode.Success

            };

        }

    }
}
