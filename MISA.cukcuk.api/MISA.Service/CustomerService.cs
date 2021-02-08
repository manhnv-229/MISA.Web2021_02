using MISA.Common.Model;
using MISA.DataLayer;
using MISA.DataLayer.Interfaces;
using MISA.Service.Interfaces;

namespace MISA.Service
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {

        public CustomerService(IBaseData<Customer> DbContext) : base(DbContext)
        {

        } 
        //public ServiceResult GetCustomersTop100()
        //{
        //    var serviceResult = new ServiceResult();
        //    var dbContext = new CustomerRepostory();
        //    serviceResult.Data = dbContext.GetCustomerTop100();
        //    return serviceResult;
        //}

        protected override bool ValidateData(Customer customer, ErrorMsg errorMsg = null)
        {
            var dbContext = new CustomerRepostory();
            var isValid = true;
            // validate ma khach hang
            if (customer.CustomerCode == null || customer.CustomerCode == string.Empty)
            {
                if (errorMsg != null)
                    errorMsg.UserMsg.Add(MISA.Common.Properties.Resources.ErrorService_EmptyCustomerCode);
                isValid = false;
            }

            var isExists = dbContext.checkCustomerCodeExists(customer.CustomerCode);
            if (isExists == true)
            {
                if (errorMsg != null)
                    errorMsg.UserMsg.Add(MISA.Common.Properties.Resources.ErrorService_DuplicateCustomerCode);
                isValid = false;
            }

            //validate sdt
            isExists = dbContext.checkCustomerPhoneNumberExists(customer.PhoneNumber);
            if (isExists == true)
            {
                if (errorMsg != null)
                    errorMsg.UserMsg.Add(MISA.Common.Properties.Resources.ErrorService_DuplicateCustomerPhoneNumber);
                isValid = false;
            }
            return isValid;
        }
    }
}
