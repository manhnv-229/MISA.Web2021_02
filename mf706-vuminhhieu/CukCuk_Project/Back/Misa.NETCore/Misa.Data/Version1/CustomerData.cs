using Misa.Common.Entities;

namespace Misa.Data.Version1
{
    public class CustomerData : DbConnection<Customer>
    {       
        public CustomerData() : base()
        {
            ;
        }
    }
}
