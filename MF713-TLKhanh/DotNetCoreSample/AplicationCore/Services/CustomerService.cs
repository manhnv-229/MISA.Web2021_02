using AplicationCore.Entities;
using AplicationCore.Interfaces;
using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AplicationCore.Services
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        IBaseRepository<Customer> _baseRepository;
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="baseRepository">repository để cho hàm cha khởi tạo</param>
        public CustomerService(IBaseRepository<Customer> baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
        }
        /// <summary>
        /// Hàm sử lý validate dữ liệu riêng cho khách hàng
        /// </summary>
        /// <param name="customer">Khách hàng truyền từ body</param>
        /// <param name="errorMsg">các thông tin lỗi trả về cho client</param>
        /// <param name="id">id của khách hàng cần cập nhật chỉ dùng khi cập nhật một bản ghi</param>
        /// <returns>Trạng thái có hợp lệ hay không: hợp lệ : true, không hợp lệ: false</returns>
        public override bool Validate(Customer customer, ErrorMsg errorMsg = null, string id = null)
        {
            bool isValid = true;
            // Sử lý validate chung
            //kiểm tra xem mã khách hàng có để trống không
            if(customer.CustomerCode == string.Empty || customer.CustomerCode == null)
            {
                if(errorMsg != null)
                    errorMsg.UserMsg.Add("Mã khách hàng không được để trống!");
                isValid = false;
            }
            // kiểm tra xem số điện thoại có để trống không
            if(customer.PhoneNumber == string.Empty || customer.PhoneNumber == null)
            {
                if (errorMsg != null)
                    errorMsg.UserMsg.Add("Số điện thoại không được để trống!");
                isValid = false;
            }
            // kiểm tra xem họ và tên có để trống không
            if (customer.FullName == string.Empty || customer.FullName == null)
            {
                if (errorMsg != null)
                    errorMsg.UserMsg.Add("Họ và tên không được để trống!");
                isValid = false;
            }
            // lấy ra khách hàng theo mã khách hàng
            var customerByCode = _baseRepository.Get($"Select * from Customer Where CustomerCode = '{customer.CustomerCode}'").FirstOrDefault();
            // lất ra khách hàng theo số điện thoại
            var customerByPhone = _baseRepository.Get($"Select * from Customer Where PhoneNumber = '{customer.PhoneNumber}'").FirstOrDefault();
            // Xử lý valy date các trường cho update
            if(id != null)
            {
                // lấy ra khách hàng theo id
                var customerById = _baseRepository.Get($"Select * from Customer Where CustomerId = '{id}'").FirstOrDefault();
                // nếu mã khách hàng bị trùng với bản ghi nào đó trong db , không tính chính bản ghi cần cập nhật
                if (customerByCode != null && customerByCode.CustomerCode != customerById.CustomerCode)
                {
                    if (errorMsg != null)
                        errorMsg.UserMsg.Add("Mã khách hàng đã tồn tại, vui lòng kiểm tra lại!");
                    isValid = false;
                }
                // nếu số điện thoại bị trùng với bản ghi nào đó trong db , không tính chính bản ghi cần cập nhật
                if (customerByPhone != null && customerByPhone.PhoneNumber != customerById.PhoneNumber)
                {
                    if (errorMsg != null)
                        errorMsg.UserMsg.Add("Số điện thoại đã được sử dụng, vui lòng kiểm tra lại!");
                    isValid = false;
                }
            }
            // Xử lý valy date các trường cho insert
            else
            {
                // nếu mã khách hàng bị trùng với một bản ghi nào đó trong db
                if (customerByCode != null)
                {
                    if (errorMsg != null)
                        errorMsg.UserMsg.Add("Mã khách hàng đã tồn tại, vui lòng kiểm tra lại!");
                    isValid = false;
                }
                // nếu số điện thọai bị trùng với một bản ghi nào đó trong db
                if (customerByPhone != null)
                {
                    if (errorMsg != null)
                        errorMsg.UserMsg.Add("Số điện thoại đã được sử dụng, vui lòng kiểm tra lại!");
                    isValid = false;
                }
            }
            // trả về trạng thái có hợp lệ hay không
            return isValid;
        }
    }
}
