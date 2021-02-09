using MISA.Common.Model;
using MISA.DataLayer.Interfaces;
using MISA.Service.Interfaces;

namespace MISA.Service.Services
{
    public class CustomerServiceV2:BaseService<Customer>, ICustomerService
    {
        public CustomerServiceV2(IBaseData<Customer> DbContext) : base(DbContext)
        {

        }
        protected override bool ValidateData(Customer entity, ErrorMsg errorMsg = null)
        {
            return true;
        }
    }
}
