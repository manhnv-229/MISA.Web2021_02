using MISA.CukCuk.Core.Entities;
using MISA.CukCuk.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MISA.CukCuk.Core.Services
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {

        #region Declare
        /// <summary>
        /// Baserepository
        /// </summary>
        IEmployeeRepository _employeeRepository;
        /// <summary>
        /// Service result 
        /// </summary>
        ServiceResult _serviceResult;
        #endregion
        #region Constructor
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="baseRepository">repository để cho hàm cha khởi tạo</param>
        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _serviceResult = new ServiceResult();
        }
        #endregion

        #region Method
        public ServiceResult GetEmployees()
        {
            var employees = _employeeRepository.GetEmployees() as List<Employee>;
            if (employees.Count > 0)
            {
                _serviceResult.StatusCode = MisaCode.Success;
                _serviceResult.Data = employees;
            }
            return _serviceResult;
        }

        public ServiceResult GetByWorkStatus(string work_status = null)
        {
            if (work_status == null)
            {
                _serviceResult.Data = _employeeRepository.GetEmployees();
                return _serviceResult;
            }
            else
            {
                _serviceResult.Data = _employeeRepository.Get("Proc_GetEmployeeByWorkStatusId",
                    new {WorkStatusId = work_status },
                    System.Data.CommandType.StoredProcedure);
                return _serviceResult;
            }

        }

        public ServiceResult GetMaxCode()
        {
            var maxCode = _employeeRepository.GetMaxCode();
            _serviceResult.Data = maxCode;
            return _serviceResult;
        }

        /// <summary>
        /// Hàm sử lý validate dữ liệu riêng cho nhân viên
        /// </summary>
        /// <param name="employee">Nhân viên truyền từ body</param>
        /// <param name="errorMsg">các thông tin lỗi trả về cho client</param>
        /// <param name="id">id của khách hàng cần cập nhật chỉ dùng khi cập nhật một bản ghi</param>
        /// <returns>Trạng thái có hợp lệ hay không: hợp lệ : true, không hợp lệ: false</returns>
        /// CreatedBy: TLKhanh (19/2/2021)
        /// ModifiedBy: TLKhanh (20/2/2021)
        public override bool Validate(Employee employee, ErrorMessage errorMsg = null, string id = null)
        {
            bool isValid = true;
            // Sử lý validate chung
            //kiểm tra xem mã khách hàng có để trống không
            if (employee.EmployeeCode == string.Empty || employee.EmployeeCode == null)
            {
                if (errorMsg != null)
                    errorMsg.UserMsg.Add("Mã Nhân viên không được để trống!");
                isValid = false;
            }
            // kiểm tra xem số điện thoại có để trống không
            if (employee.PhoneNumber == string.Empty || employee.PhoneNumber == null)
            {
                if (errorMsg != null)
                    errorMsg.UserMsg.Add("Số điện thoại không được để trống!");
                isValid = false;
            }
            // kiểm tra xem họ và tên có để trống không
            if (employee.FullName == string.Empty || employee.FullName == null)
            {
                if (errorMsg != null)
                    errorMsg.UserMsg.Add("Họ và tên không được để trống!");
                isValid = false;
            }
            // kiểm tra xem email có để trống không
            if (employee.Email == string.Empty || employee.Email == null)
            {
                if (errorMsg != null)
                    errorMsg.UserMsg.Add("Email không được để trống!");
                isValid = false;
            }

            // kiểm tra xem email có đúng định dạng không
            else
            {
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(employee.Email);
                if(!match.Success)
                {
                    if (errorMsg != null)
                        errorMsg.UserMsg.Add("Email sai định dạng!");
                    isValid = false;
                }
                
            }

            // kiểm tra xem số cmt có để trống không
            if (employee.IdentityNumber == string.Empty || employee.IdentityNumber == null)
            {
                if (errorMsg != null)
                    errorMsg.UserMsg.Add("Số CMT/CCCD không được để trống!");
                isValid = false;
            }
            // kiểm tra xem quyền có để trống không
            if (employee.RuleId.ToString() == string.Empty || employee.RuleId == null)
            {
                if (errorMsg != null)
                    errorMsg.UserMsg.Add("Phải phân quyền cho nhân viên!");
                isValid = false;
            }

            // kiểm tra xem trạng thái làm việc có để trống không
            if (employee.WorkStatusId.ToString() == string.Empty || employee.WorkStatusId == null)
            {
                if (errorMsg != null)
                    errorMsg.UserMsg.Add("Phải xác định trạng thái công việc cho nhân viên!");
                isValid = false;
            }
            // lấy ra nhân viên theo mã nhân viên
            var employeeByCode = _employeeRepository.Get($"Select * from Employee Where EmployeeCode = '{employee.EmployeeCode}'").FirstOrDefault();
            // lất ra khách hàng theo số điện thoại
            var employeeByPhone = _employeeRepository.Get($"Select * from Employee Where PhoneNumber = '{employee.PhoneNumber}'").FirstOrDefault();
            // lất ra khách hàng theo số cmt
            var employeeByIdentity = _employeeRepository.Get($"Select * from Employee Where IdentityNumber = '{employee.IdentityNumber}'").FirstOrDefault();
            var employeeByEmail = _employeeRepository.Get($"Select * from Employee Where Email = '{employee.Email}'").FirstOrDefault();
            // Xử lý valy date các trường cho update
            if (id != null)
            {
                // lấy ra khách hàng theo id
                var employeeById = _employeeRepository.Get($"Select * from Employee Where EmployeeId = '{id}'").FirstOrDefault();
                // nếu mã khách hàng bị trùng với bản ghi nào đó trong db , không tính chính bản ghi cần cập nhật
                if (employeeByCode != null && employeeByCode.EmployeeCode != employeeById.EmployeeCode)
                {
                    if (errorMsg != null)
                        errorMsg.UserMsg.Add("Mã nhân viên đã tồn tại, vui lòng kiểm tra lại!");
                    isValid = false;
                }
                // nếu số điện thoại bị trùng với bản ghi nào đó trong db , không tính chính bản ghi cần cập nhật
                if (employeeByPhone != null && employeeByPhone.PhoneNumber != employeeById.PhoneNumber)
                {
                    if (errorMsg != null)
                        errorMsg.UserMsg.Add("Số điện thoại đã được sử dụng, vui lòng kiểm tra lại!");
                    isValid = false;
                }
                // nếu số chứng minh thư bị trùng với một bản ghi nào đó trong db, không tính chính bản ghi cần cập nhật
                if (employeeByIdentity != null && employeeByIdentity.IdentityNumber != employeeById.IdentityNumber)
                {
                    if (errorMsg != null)
                        errorMsg.UserMsg.Add("Số CMT đã được sử dụng, vui lòng kiểm tra lại!");
                    isValid = false;
                }
                // nếu email bị trùng với một bản ghi nào đó trong db, không tính chính bản ghi cần cập nhật
                if (employeeByEmail != null && employeeByEmail.Email != employeeById.Email)
                {
                    if (errorMsg != null)
                        errorMsg.UserMsg.Add("Email đã được sử dụng, vui lòng kiểm tra lại!");
                    isValid = false;
                }
            }
            // Xử lý valy date các trường cho insert
            else
            {
                // nếu mã khách hàng bị trùng với một bản ghi nào đó trong db
                if (employeeByCode != null)
                {
                    if (errorMsg != null)
                        errorMsg.UserMsg.Add("Mã nhân viên đã tồn tại, vui lòng kiểm tra lại!");
                    isValid = false;
                }
                // nếu số điện thọai bị trùng với một bản ghi nào đó trong db
                if (employeeByPhone != null)
                {
                    if (errorMsg != null)
                        errorMsg.UserMsg.Add("Số điện thoại đã được sử dụng, vui lòng kiểm tra lại!");
                    isValid = false;
                }
                // nếu số chứng minh thư bị trùng với một bản ghi nào đó trong db
                if (employeeByIdentity != null)
                {
                    if (errorMsg != null)
                        errorMsg.UserMsg.Add("Số CMT đã được sử dụng, vui lòng kiểm tra lại!");
                    isValid = false;
                }

                // nếu email bị trùng với một bản ghi nào đó trong db
                if (employeeByEmail != null)
                {
                    if (errorMsg != null)
                        errorMsg.UserMsg.Add("Email đã được sử dụng, vui lòng kiểm tra lại!");
                    isValid = false;
                }
            }
            // trả về trạng thái có hợp lệ hay không
            return isValid;
        }
        #endregion

    }
}
