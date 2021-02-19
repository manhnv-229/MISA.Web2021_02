using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.DataLayer.Interfaces
{
    public interface IDbContext<TEntity>
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu theo các tiêu chí
        /// </summary>
        /// <param name="query">Câu lệnh truy vấn hoặc Produced; Default : null</param>
        /// <param name="param">Tham số dùng kèm với lệnh truy vấn; Default : null</param>
        /// <param name="cmdType">Kiểu truy vấn(Text,Produced)</param>
        /// <returns>Danh sách các bản ghi</returns>
        /// CreatedBy: TLMinh (07/02/2021)
        public IEnumerable<TEntity> GetAll(string query = null, object param = null, CommandType cmdType = CommandType.Text);

        /// <summary>
        /// Thêm một bản ghi vào database
        /// </summary>
        /// <param name="entity">Thực thể thêm mới</param>
        /// <returns>Số lượng bản ghi được thêm</returns>
        /// CreatedBy: TLMinh (07/02/2021)
        public int Insert(TEntity entity);

        /// <summary>
        /// Xóa một bản ghi khỏi database
        /// </summary>
        /// <param name="entityId">Id của thực thể cần xóa</param>
        /// <param name="way">1 xóa theo Id chính, 2 xóa theo Id ngoại; Default: 1</param>
        /// <returns>Số bản ghi bị xóa</returns>
        /// CreatedBy: TLMinh (07/02/2021)
        public int Delete(string entityId,int way = 1);

        /// <summary>
        /// Sửa thông tin bản ghi
        /// </summary>
        /// <param name="entity">Thực thể đã sửa thông tin</param>
        /// <returns>Số bản ghi đuộc cập nhật</returns>
        /// CreatedBy: TLMinh (07/02/2021)
        public int Put(TEntity entity);
    }
}
