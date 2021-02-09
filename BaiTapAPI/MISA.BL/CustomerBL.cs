using MISA.BL.Interfaces;
using MISA.Common;
using MISA.DAO;
using MISA.DAO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.BL//xử lý nghiệp vụ
{
    public class CustomerBL:BaseBL<Customer>, ICustomerBL
    {
        //ICustomerDAO _customerDAO;
        public CustomerBL(IDbConnector<Customer> _customerDL) : base(_customerDL)
        {

        }

        ///<summary>
        /// Xóa khách hàng
        /// </summary>
        /// <param name="customerCode">string</param>
        /// <returns>ServiceResult (Object thông tin kết quả)</returns>
        /// CreatedBy: NDLuu (8/2/2021)
        public override ServiceResult Delete(string customerCode)
        {
            // Gọi đến tầng DataLayer
            var customerDL = new CustomerDAO();
            // Xóa dữ liệu khách hàng
            var affectedRows = customerDL.Delete(customerCode);
            // Kiểm tra kết quả trả về
            if (affectedRows > 0)
                _serviceResult.Success = true;
            else
                _serviceResult.Success = false;

            return _serviceResult;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public int InsertCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Kiểm tra dữ liệu khi thêm mới
        /// </summary>
        /// <param name="customer">Object</param>
        /// <param name="errMsg">Thông báo lỗi</param>
        /// <returns>true - hop le, false - sai</returns>
        /// CreatedBy: NDLuu (8/2/2021)
        protected override bool ValidateInsertData(Customer customer, ErrorMsg errMsg)
        {
            // Gọi đến tầng DataLayer
            var customerDL = new CustomerDAO();
            var isValid = true;
            // Validate dữ liệu
            // 1. Validate bắt buộc nhập
            // 1.1 Check mã trống hoặc null
            if (customer.CustomerCode == null || customer.CustomerCode == string.Empty)
            {
                errMsg.UserMsg = MISA.Common.Properties.Resources.ErrorException;
                isValid = false;
            }
            // 1.2 Họ và tên
            if (customer.FullName == null || customer.FullName == string.Empty)
            {
                errMsg.UserMsg = MISA.Common.Properties.Resources.ErrorService_CustomerName;
                isValid = false;
            }
            // 1.3 số điện thoại
            if (customer.PhoneNumber == null || customer.PhoneNumber == string.Empty)
            {
                errMsg.UserMsg= MISA.Common.Properties.Resources.ErrorService_CustomerPhoneNumber;
                isValid = false;
            }
            // 2. Kiểm tra trùng
            //   2.2 Trùng số điện thoại
            if (customerDL.CheckDuplicatedPhoneNumber(customer.PhoneNumber))
            {
                errMsg.UserMsg = MISA.Common.Properties.Resources.ErrService_DuplicatedPhoneNumber;
                isValid = false;
            }
            //   2.1 Trùng mã khách hàng
            if (customerDL.checkDublicateCustomerCode(customer.CustomerCode))
            {
                errMsg.UserMsg = MISA.Common.Properties.Resources.ErrService_DuplicatedCustomerCode;
                isValid = false;
            }

            return isValid;
        }

        /// <summary>
        /// Kiểm tra dữ liệu khi cập nhật
        /// </summary>
        /// <param name="customer">Object</param>
        /// <param name="errMsg">Thông báo lỗi</param>
        /// <returns>true nếu valid, false nếu invalid</returns>
        /// CreatedBy: NDLuu (8/2/2021)
        protected override bool ValidateUpdateData(Customer customer, ErrorMsg errMsg)
        {
            // Gọi đến tầng DataLayer
            var customerDL = new CustomerDAO();
            var isValid = true;
            // Validate dữ liệu
            // 1. Validate bắt buộc nhập
            // 1.1 Check mã trống hoặc null
            if (customer.CustomerCode == null || customer.CustomerCode == string.Empty)
            {
                errMsg.UserMsg = MISA.Common.Properties.Resources.ErrorException;
                isValid = false;
            }
            // 1.2 Họ và tên
            if (customer.FullName == null || customer.FullName == string.Empty)
            {
                errMsg.UserMsg = MISA.Common.Properties.Resources.ErrorService_CustomerName;
                isValid = false;
            }
            // 1.3 số điện thoại
            if (customer.PhoneNumber == null || customer.PhoneNumber == string.Empty)
            {
                errMsg.UserMsg = MISA.Common.Properties.Resources.ErrorService_CustomerPhoneNumber;
                isValid = false;
            }
            // 2. Kiểm tra trùng
            //   2.1 Trùng mã khách hàng
            /*if (customerDL.checkDublicateCustomerCode(customer.CustomerCode))
            {
                errMsg.UserMsg = MISA.Common.Properties.Resources.ErrService_DuplicatedCustomerCode;
                isValid = false;
            }*/
            //   2.2 Trùng số điện thoại
            /*if (customerDL.CheckDuplicatedPhoneNumber(customer.PhoneNumber))
            {
                errMsg.UserMsg = MISA.Common.Properties.Resources.ErrService_DuplicatedPhoneNumber;
                isValid = false;
            }*/

            // 2.3 Kiểm tra mã có tồn tại
            if (customerDL.checkExistCustomerCode(customer.CustomerCode)==false)
            {
                errMsg.UserMsg = MISA.Common.Properties.Resources.ErrService_ExistCustomerCode;
                isValid = false;
            }
            return isValid;
        }

        //---------------------------------------------------------------=====================

        /*public IEnumerable<Customer> GetCustomers()
        {
            //xử lý
            return _customerDAO.GetCustomers();
        }

        public int InsertCustomer(Customer customer)
        {
            //1. check trùng mã...
            if (_customerDAO.checkDublicateCustomerCode(customer.CustomerCode) == true)
            {
                return -1;
            }
            else
            {
                var effectRow = _customerDAO.Insert(customer);
                return effectRow;
            }
            

            //2. Check các trường dl

        }*/
    }
}
