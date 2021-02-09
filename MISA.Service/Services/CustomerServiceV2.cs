using MISA.Common.Models;
using MISA.DataLayer;
using MISA.Service;
using MISA.Service.Interface;

namespace MISA.Services
{
    public class CustomerServiceV2 : BaseService<Customer>, ICustomerService
    {
        public CustomerServiceV2(IDBConnector<Customer> dbContext) : base(dbContext)
        {
          
        }
        /// <summary>
        /// Test interface
        /// </summary>
        /// <returns></returns>
        public override ActionServiceResult GetData()
        {
            return new ActionServiceResult
            {
                Success = true,
                Message = MISA.Common.Properties.Resources.SuccessMsg,
                Data = 678,
                MISACode = EnumCodes.Created,
            };
        }
    }
}
