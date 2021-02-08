using Misa.Common;
using Misa.Common.Requests;
using Misa.Common.Requests.Customer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Misa.Bussiness.Interfaces
{
    public interface IBaseBussiness<T>
    {

        /// <summary>
        /// Lấy ra toàn bộ danh sách - kỹ thuật DI
        /// </summary>
        /// <returns>ServiceResult</returns>
        /// create 5/2/2021
        public Task<ServiceResult> GetData();

        /// <summary>
        /// Lấy danh sách đối tượng theo trang và số bản ghi - kỹ thuật DI
        /// </summary>
        /// <param name="pageRequestBase">trang và bản ghi</param>
        /// <returns>ServiceResult</returns>
        /// create 4/2/2021
        public Task<ServiceResult> GetData(PageRequestBase pageRequestBase);


        /// <summary>
        /// thêm mới đối tượng - kỹ thuật DI
        /// </summary>
        /// <param name="entity">thông tin nhân viên</param>
        /// <returns>ServiceResult</returns>
        /// update: 3/2/2021
        public Task<ServiceResult> Insert(T entity);

        /// <summary>
        /// cập nhập đối tượng - kỹ thuật DI
        /// </summary>
        /// <param name="entity">thông tin nhân viên</param>
        /// <returns>ServiceResult</returns>

        public Task<ServiceResult> Update(T entity);


        /// <summary>
        /// Xóa nhân đối tượng theo id - kỹ thuật DI
        /// </summary>
        /// <param name="id">id của nhân viên</param>
        /// <returns>ServiceResult</returns>

        public Task<ServiceResult> Delete(string id);


        public void ValidateObject(ref ServiceResult serviceResult, T entity);
    }
}
