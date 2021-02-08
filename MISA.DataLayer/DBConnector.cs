using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;

namespace MISA.DataLayer
{
    public class DBConnector<TEntity>
    {
        #region DECLARE
        /// <summary>
        /// Tạo kết nối
        /// </summary>
        protected static string _connectionString = "Host=103.124.92.43;Port=3306; User Id=nvmanh;Password=12345678;Database=MS2_30_Trinh_CukCuk;Character Set=utf8";
        #endregion

        #region Constructor
        protected IDbConnection _db;
        public DBConnector()
        {
            _db = new MySqlConnection(_connectionString);
        }
        #endregion

        #region Method
        /// <summary>
        /// Lấy danh sách
        /// </summary>
        /// <typeparam name="TEntity">Kiểu của object</typeparam>
        /// <returns>List các object lấy đc</returns>
        /// CreatedBy: TXTrinh (02/02/2021)
        public IEnumerable<TEntity> GetAll()
        {
            string className = typeof(TEntity).Name;
            string proc = $"Proc_Get{className}s";
            var entities = _db.Query<TEntity>(proc, commandType: CommandType.StoredProcedure);
            return entities;
        }
        
        /// <summary>
        /// Lấy danh sách bản ghi theo tiêu chí khác nhau
        /// </summary>
        /// <typeparam name="TEntity">Kiểu object</typeparam>
        /// <param name="commandText">Câu lệnh Sql/ Tên store</param>
        /// <param name="parameters">Tham số của store</param>
        /// <param name="type">Loại commandType (mặc định là Text)</param>
        /// <returns>Danh sách bản ghi</returns>
        /// Created By: TXTrinh (08/02/2021)
        public IEnumerable<TEntity> GetData(string commandText, object parameters = null, CommandType type = CommandType.Text)
        {
            var data = _db.Query<TEntity>(commandText, param: parameters, commandType: type);
            return data;
        }
        /// <summary>
        /// Lấy theo Id
        /// </summary>
        /// <typeparam name="TEntity">Loại đối tượng</typeparam>
        /// <param name="id">Id của đối tượng</param>
        /// <returns>Bản ghi cần tìm</returns>
        /// CreatedBy: TXTrinh (02/02/2021)
        public TEntity GetById(object id)
        {
            string className = typeof(TEntity).Name;
            var sql = $"Select * from {className} Where {className}Id = '{id.ToString()}'";
            return _db.Query<TEntity>(sql).FirstOrDefault();
        }

        /// <summary>
        /// Thêm mới thông tin
        /// </summary>
        /// <typeparam name="TEntity">Loại đối tượng</typeparam>
        /// <param name="entity">Dối tượng mới</param>
        /// <returns>Số bản ghi thêm được</returns>
        /// CreatedBy: TXTrinh (02/02/2021)
        public int Insert(TEntity entity)
        {
            string className = typeof(TEntity).Name;
            string proc = $"Proc_Insert{className}";
            var res = _db.Execute(proc, param: entity, commandType: CommandType.StoredProcedure);
            return res;
        }
        /// <summary>
        /// Chỉnh sửa thông tin
        /// </summary>
        /// <typeparam name="TEntity">Loại đối tượng</typeparam>
        /// <param name="entity">Đối tượng mới đã chỉnh sửa</param>
        /// <returns>Số bản ghi ảnh hưởng</returns>
        /// CreatedBy: TXTrinh (02/02/2021)
        public int Update(TEntity entity)
        {
            string className = typeof(TEntity).Name;
            string proc = $"Proc_Update{className}ById";
            var res = _db.Execute(proc, param: entity, commandType: CommandType.StoredProcedure);
            return res;
        }
        /// <summary>
        /// Xóa theo Id
        /// </summary>
        /// <typeparam name="TEntity">Loại đối tượng</typeparam>
        /// <param name="id">Id của đối tượng cần xóa</param>
        /// <returns>Số bản ghi ảnh hường</returns>
        /// CreatedBy: TXTrinh (02/02/2021)
        public int Delete(object id)
        {
            string className = typeof(TEntity).Name;
            var sql = $"DELETE FROM {className} WHERE {className}Id = '{id.ToString()}'";
            return _db.Execute(sql);
        }

        /// <summary>
        /// Kiểm tra trùng dữ liệu
        /// </summary>
        /// <typeparam name="TEntity">Loại đối tượng</typeparam>
        /// <param name="param">Tên thuộc tính cần kiểm tra</param>
        /// <param name="value">giá trị cần kiểm tra</param>
        /// <returns>true - trùng ; false - không trùng</returns>
        /// Created By: TXTrinh 08/02/2021
        public bool checkDuplicate(string property, object value)
        {
            var sql = $"Select {property} From {typeof(TEntity).Name} Where {property} = '{value}'";
            var entity = _db.Query<string>(sql).FirstOrDefault();
            if (entity != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Lấy bản ghi từ vị trí, số lượng lấy
        /// </summary>
        /// <typeparam name="TEntity">Loại đối tượng</typeparam>
        /// <param name="startPoint">Thứ tự bản ghi bắt đầu lấy</param>
        /// <param name="number">Số lượng bản ghi cần lấy</param>
        /// <returns>Mảng các đối tượng</returns>
        /// CreatedBy: TXTrinh (02/02/2021)
        public IEnumerable<TEntity> GetWithRange(int startPoint, int number)
        {
            string className = typeof(TEntity).Name;
            var sql = $"SELECT * FROM {className}  ORDER BY {className}Code ASC LIMIT {startPoint}, {number}";
            var entities = _db.Query<TEntity>(sql);
            return entities;
        }
        /// <summary>
        /// Lấy mã cao nhất
        /// </summary>
        /// <typeparam name="TEntity">Kiểu đối tượng</typeparam>
        /// <returns>Mã cao nhất</returns>
        /// CreatedBy: TXTrinh (02/02/2021)
        public TEntity GetMaxCode()
        {
            string className = typeof(TEntity).Name;
            var sql = $"SELECT EmployeeCode FROM {className} WHERE {className}Code = (SELECT MAX({className}Code) FROM {className})";
            var result = _db.Query<TEntity>(sql).FirstOrDefault();
            return result;
        }
        #endregion
    }
}
