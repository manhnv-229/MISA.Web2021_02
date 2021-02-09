using MISA.Common.Model;
using MISA.DataLayer;
using MISA.DataLayer.Interfaces;

namespace MISA.Service
{
    public class CustomerGroupService:BaseService<CustomerGroup>
    {
        /// <summary>
        /// Hàm kế thừa BaseService, truyền param lên để gọi đến database
        /// </summary>
        /// <param name="DbContext">Gửi param lên cho cha để kết nối đến database</param>
        public CustomerGroupService(IBaseData<CustomerGroup> DbContext) : base(DbContext)
        {

        }
        protected override bool ValidateData(CustomerGroup entity, ErrorMsg errorMsg = null)
        {
            return true;
        }
    }
}
