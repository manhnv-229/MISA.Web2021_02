using ApplicationCore.Interfaces;
using Common.Model;
using Infrastructure;

namespace ApplicationCore
{
    /// <summary>
    /// Lớp xử lý nghiệp vụ cho đối tượng khách hàng
    /// </summary>
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        public CustomerService(IDbContext<Customer> dbContext):base(dbContext)
        {

        }
    }
}
