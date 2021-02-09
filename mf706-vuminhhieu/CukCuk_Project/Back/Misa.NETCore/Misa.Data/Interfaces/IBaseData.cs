using Misa.Common.Requests;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Misa.Data.Interfaces
{
    public interface IBaseData<T>
    {
        /// <summary>
        /// Lấy danh sách theo chuỗi sql - kỹ thuật DI
        /// </summary>
        /// <param name="commandText">chuỗi sql</param>
        /// <param name="parameters">tham sô truyền vào</param>
        /// <param name="commandType">Kiểu truy vấn</param>
        /// <returns>Danh sách đối tượng</returns>
        public Task<IEnumerable<T>> GetData(string commandText = null, object parameters = null, CommandType commandType = CommandType.Text);

        /// <summary>
        /// Lấy danh sách theo chuỗi sql chỉ định đầu ra cụ thể - kỹ thuật DI
        /// </summary>
        /// <param name="commandText">chuỗi sql</param>
        /// <param name="parameters">tham sô truyền vào</param>
        /// <param name="commandType">Kiểu truy vấn</param>
        /// <returns>Danh sách đối tượng</returns>
        public Task<IEnumerable<T2>> GetData<T2>(string commandText = null, object parameters = null, CommandType commandType = CommandType.Text);

        /// <summary>
        /// Lấy danh sách nhân viên theo số trang và kích thước trang - kỹ thuật DI
        /// </summary>
        /// <param name="pageRequestBase">số trang và kích thước trang</param>
        /// <returns>danh sách nhân viên</returns>
        public Task<IEnumerable<T>> GetData(PageRequestBase pageRequestBase);

        /// <summary>
        /// Lấythông tin nhâ viên nhân viên theo id - kỹ thuật DI
        /// </summary>
        /// <param name="id"> EmployeeId</param>
        /// <returns>1 đối tượng nhân viên</returns>
        /// create: 5/2/2021
        public Task<T> GetById(object id);

        /// <summary>
        /// Thêm mới đối tượng - kỹ thuật DI
        /// </summary>
        /// <param name="entiry">thông tin đối tượng</param>
        /// <returns>số dòng bị ảnh hưởng</returns>
        /// create: 5/2/2021
        public Task<int> Insert(T entiry);


        /// <summary>
        /// Cập nhật thông tin đối tượng - kỹ thuật DI
        /// </summary>
        /// <param name="entiry">thông tin đối tượng</param>
        /// <returns>số dòng bị ảnh hưởng</returns>
        /// create: 5/2/2021
        public Task<int> Update(T entiry);

        /// <summary>
        /// Xóa đối tượng - kỹ thuật DI
        /// </summary>
        /// <param name="id">id của đối tượng:</param>
        /// <returns>số dòng bị ảnh hưởng</returns>
        /// create: 5/2/2021        
        public Task<int> Delete(string id);
    }
}
