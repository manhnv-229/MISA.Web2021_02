using Misa.Common;
using Misa.Common.Entities;
using Misa.Common.Requests.Employee;
using System.Threading.Tasks;

namespace Misa.Bussiness.Interfaces
{
    public interface IEmployeeBussiness: IBaseBussiness<Employee>
    {
        /// <summary>
        /// Lấy ra danh sách nhân viên  - kỹ thuật DI
        /// </summary>
        /// <param name="pageRequest">keyword, id phòng ban, id chức vụ, trang số, số bản ghi</param>
        /// <returns>ServiceResult</returns>
        /// create :4/2/2021
        public Task<ServiceResult> GetData(PageRequest pageRequest);

        /// <summary>
        /// Lấy ra toàn bộ danh sách nhân viên đầy đủ  - kỹ thuật DI
        /// </summary>
        /// <returns>ServiceResult</returns>
        /// create :4/2/2021
        public Task<ServiceResult> GetFullData();

        /// <summary>
        /// Kiểm tra mã nhân viên đã tồn tại hay chưa - kỹ thuật DI
        /// </summary>
        /// <param name="serviceResult">tham chiếu gói trả về</param>
        /// <param name="employeeCode">mã nhân viên</param>
        /// create: 4/2/2021
        public void CheckCustomerCodeDuplicate(ref ServiceResult serviceResult, string employeeCode);


        /// <summary>
        /// Kiểm tra số điện thoại đã tồn tại hay chưa - kỹ thuật DI
        /// </summary>
        /// <param name="serviceResult">tham chiếu gói trả về</param>
        /// <param name="phoneNumber">số điện thoại</param>
        /// create: 4/2/2021
        public void CheckPhoneNumberDuplicate(ref ServiceResult serviceResult, string phoneNumber);


        /// <summary>
        /// Kiểm tra email đã tồn tại hay chưa - kỹ thuật DI
        /// </summary>
        /// <param name="serviceResult">tham chiếu gói trả về</param>
        /// <param name="email">email</param>
        /// create: 4/2/2021
        public void CheckEmailDuplicate(ref ServiceResult serviceResult, string email);

        
    }
}
