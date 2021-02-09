using Dapper;
using Misa8b.CukCuk.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Misa8b.CukCuk.DL
{
    /// <summary>
    /// định nghĩa lớp cha với các hàm cơ bản kết nối với db
    /// </summary>
    /// <typeparam name="DL"></typeparam>
    public class BaseDL<DL>: DbConnectionv1
    {
        //public BaseDL(IStringDb stringDb) : base(IStringDb)
        //{

        //}
        /// <summary>
        /// kiểm tra trùng mã code
        /// </summary>
        /// <param name="dataCode"></param>
        /// <returns>đúng hoặc sai</returns>
        public bool CheckDuplicateDataCode(string dataCode)
        {
            var data = dbConnection.Query<DL>($"Select * from {typeof(DL).Name} where {typeof(DL).Name}Code = '{dataCode}'").FirstOrDefault();
            if (data != null) return true;
            return false;
        }
        /// <summary>
        /// kiểm tra trùng mã CMND
        /// </summary>
        /// <param name="dataIdent">mã chừng minh nhân dân</param>
        /// <returns>đúng hoặc sai</returns>
        public bool CheckDuplicateIdent(string dataIdent)
        {
            var data = dbConnection.Query<DL>($"Select * from {typeof(DL).Name} where IdentityCard = '{dataIdent}'").FirstOrDefault();
            if (data != null) return true;
            return false;
        }
        /// <summary>
        /// kiểm tra trùng số điện thoại
        /// </summary>
        /// <param name="PhoneNumber"></param>
        /// <returns>đúng hoặc sai</returns>
        public bool CheckDuplicateDataPhoneNumber(string PhoneNumber)
        {
            var data = dbConnection.Query<DL>($"Select * from {typeof(DL).Name} where PhoneNumber = '{PhoneNumber}'").FirstOrDefault();
            if (data != null) return true;
            return false;
        }
        /// <summary>
        /// lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>danh sách dữ liệu</returns>
        public List<DL> GetDatas()
        {
            return this.GetAllData<DL>();
        }
        /// <summary>
        /// lấy dữ liệu bằng pagging
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="ofset"></param>
        /// <returns>danh sách dữ liệu</returns>
        public List<DL> GetAllDataPagging(int limit, int ofset)
        {
            return this.GetAllDataWithPagging<DL>(limit, ofset);
        }
        /// <summary>
        /// thêm mới dữ liệu vào db
        /// </summary>
        /// <param name="data"></param>
        public void InsertData(DL data)
        {
            this.Insert<DL>(data);
        }
        /// <summary>
        /// lấy dữ liệu bằng id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DL GetDataId(Guid id)
        {
            return this.GetDataById<DL>(id);
        }
        /// <summary>
        /// kiểm tra trùng mã id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>đúng hoặc sai</returns>
        public bool CheckDuplicateDataId(Guid id)
        {
            var data = dbConnection.Query<DL>($"Select * from {typeof(DL).Name} where {typeof(DL).Name}Id = '{id.ToString()}'").FirstOrDefault();
            if (data != null) return true;
            return false;
        }
        /// <summary>
        /// kiểm tra xem có dữ liệu nào trùng với đoạn số điện thoại nhập vào hay không
        /// </summary>
        /// <param name="phoneNumberContaints"></param>
        /// <returns>đúng hoặc sai</returns>
        public bool CheckListDataPhoneNumber(string phoneNumberContaints)
        {
            if (phoneNumberContaints == "") return true;
            List<DL> datas = dbConnection.Query<DL>($"Select * from {typeof(DL).Name} where PhoneNumber LIKE CONCAT('%', '{phoneNumberContaints}','%')").ToList();
            if (datas.Count != 0) return true;
            return false;
        }
        /// <summary>
        /// kiểm tra xem có dữ liệu nào trùng với đoạn code nhập vào hay không
        /// </summary>
        /// <param name="DataCodeContaints"></param>
        /// <returns>đúng hoặc sai</returns>
        public bool CheckListDataCode(string DataCodeContaints)
        {
            if (DataCodeContaints == "") return true;
            List<DL> datas = dbConnection.Query<DL>($"Select * from {typeof(DL).Name} where {typeof(DL).Name}Code LIKE CONCAT('%', '{DataCodeContaints}','%')").ToList();
            if (datas.Count != 0) return true;
            return false;
        }
        /// <summary>
        /// kiểm tra xem có dữ liệu nào trùng với đoạn tên nhập vào hay không
        /// </summary>
        /// <param name="FullNameContaints"></param>
        /// <returns>đúng hoặc sai</returns>
        public bool CheckListDataFullName(string FullNameContaints)
        {
            if (FullNameContaints == "") { return true; }
            List<DL> datas = dbConnection.Query<DL>($"Select * from {typeof(DL).Name} where FullName LIKE CONCAT('%', '{FullNameContaints}','%')").ToList();
            if (datas.Count != 0) return true;
            return false;
        }
        /// <summary>
        /// sửa dữ liệu
        /// </summary>
        /// <param name="data"></param>
        public void UpdateData(DL data)
        {
            this.Update<DL>(data);
        }
        /// <summary>
        /// xóa dữ liệu
        /// </summary>
        /// <param name="id"></param>
        public void DeleteData(Guid id)
        {
            this.DeleteData<DL>(id);
        }
    }
}
