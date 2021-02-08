using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using Dapper;
using MISA.CukCuk.Api.Model;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/v1/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        /// <summary>
        /// Lấy danh sách khách hàng
        /// </summary>
        /// <returns>Danh sách khách hàng</returns>
        /// CreatedBy: NVMANH (01/02//2021)
        [HttpGet]
        public IActionResult GetCustomers()
        {
            // Khai báo thông tin kết nối tới CSDL (MariaDb/MySQl)
            var connectionString = "" +
                "Host = 103.124.92.43;" +
                "Port = 3306;" +
                "Database = MS0_147_NVMANH_CukCuk;" +
                "User Id = nvmanh;" +
                "Password = 12345678";

            // Khởi tạo kết nối:
            IDbConnection dbConnection = new MySqlConnection(connectionString);

            // Thực thi truy vấn lấy dữ liệu
            var customers = dbConnection.Query<object>("Proc_GetCustomers", commandType: CommandType.StoredProcedure);

            // Trả về kết quả cho Client:
            return Ok(customers);
        }

        /// <summary>
        /// Thêm mới khách hàng
        /// </summary>
        /// <param name="customer">Thực thể khách hàng</param>
        /// <returns>Response tương ứng cho Client (201 - thêm thành công....)</returns>
        /// CreatedBy: NVMANH (01/02/2020)
        [HttpPost]
        public IActionResult PostCustomer(Customer customer)
        {
            // Khai báo thông tin kết nối tới CSDL (MariaDb/MySQl)
            var connectionString = "" +
                "Host = 103.124.92.43;" +
                "Port = 3306;" +
                "Database = MS0_147_NVMANH_CukCuk;" +
                "User Id = nvmanh;" +
                "Password = 12345678";

            // Khởi tạo kết nối:
            IDbConnection dbConnection = new MySqlConnection(connectionString);

            var erroMsg = new ErroMsg();
            // Validate dữ liệu (xử lý về nghiệp vụ):
            // 1. Validate bắt buộc nhập:
            if (customer.CustomerCode == null)
            {
                erroMsg.DevMsg = "Database thiết lập Unique cho mã khách hàng...";
                erroMsg.UserMsg = "Mã khách hàng không được phép để trống, vui lòng kiểm tra lại";
                return StatusCode(400, erroMsg);
            }

            // 2. validate dữ liệu không được phép trùng: trùng mã khách hàng, trùng số điện thoại
            // - Kiểm tra trong database đã tồn tại mã khách hàng này hay chưa?
            var sql = $"SELECT CustomerCode FROM Customer AS C WHERE C.CustomerCode = '{customer.CustomerCode}'";
            var customerCode = dbConnection.Query<string>(sql).FirstOrDefault();
            if (customerCode != null)
            {
                erroMsg.DevMsg = "Database thiết lập Unique cho mã khách hàng...";
                erroMsg.UserMsg = "Mã khách hàng không được pheps trùng, vui lòng kiểm tra lại";
                return StatusCode(400, erroMsg);
            }


            // - Kiểm tra trong database đã tồn tại số điện thoại này hay chưa?
            var sqlSelectPhoneNumber = $"SELECT PhoneNumber FROM Customer AS C WHERE C.PhoneNumber = '{customer.PhoneNumber}'";
            var phoneNumber = dbConnection.Query<string>(sqlSelectPhoneNumber).FirstOrDefault();
            if (phoneNumber != null)
            {
                return StatusCode(400, "Số điện thoại không được phép trùng");
            }

            // 3. Validate dữ liệu đúng định dạng không? (Email cần đúng định dạng).
            var res = dbConnection.Execute("Proc_InsertCustomer", param: customer, commandType: CommandType.StoredProcedure);
            if (res > 0)
            {
                return StatusCode(201, res);
            }
            else
            {
                return StatusCode(200, "Không có bản ghi nào được thêm mới!");
            }



        }
    }
}
