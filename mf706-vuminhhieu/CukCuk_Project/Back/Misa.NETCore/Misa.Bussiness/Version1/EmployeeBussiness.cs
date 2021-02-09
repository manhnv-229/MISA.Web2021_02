using Misa.Bussiness.Interfaces;
using Misa.Common;
using Misa.Common.Entities;
using Misa.Common.Enum;
using Misa.Common.Requests.Employee;
using Misa.Common.Results;
using Misa.Common.Results.model;
using Misa.Data.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Misa.Bussiness.Version1
{
    //BaseBussiness<Employee>: chỉ định lớp cha nếu như không dùng kỹ thuật DI
    public class EmployeeBussiness : BaseBussiness<Employee>,  IEmployeeBussiness
    {
        private IEmployeeData _employeeData;
        private IBaseBussiness<Employee> _baseBussiness;


        public EmployeeBussiness(IEmployeeData employeeData, IBaseBussiness<Employee> baseBussiness, IBaseData<Employee> baseData) : base(baseData)
        {
            _employeeData = employeeData;
            _baseBussiness = baseBussiness;
        }

        /// <summary>
        /// lấy ra toàn bộ danh sách nhân viên
        /// </summary>
        /// <returns>ServiceResult</returns>
        /// update: 3/2/2021
        //public ServiceResult GetData()
        //{
             
        ////string command = "SELECT * FROM Employee WHERE EmployeeCode LIKE CONCAT('%',@EmployeeCode,'%') AND PhoneNumber LIKE CONCAT('%',@PhoneNumber,'%')";
            
                     
        //    var listEmployee = _employeeData.GetData();
        //    return new ServiceResult()
        //    {
        //        Data = listEmployee,
        //        Error = null,
        //        MISACukCukCode = MISACukCukServiceCode.Success
        //    };
        //}   

        /// <summary>
        /// Lấy ra danh sách nhân viên
        /// </summary>
        /// <param name="pageRequest">keyword, id phòng ban, id chức vụ, trang số, số bản ghi</param>
        /// <returns>ServiceResult</returns>
        /// create :4/2/2021
        public async Task<ServiceResult> GetData(PageRequest pageRequest)
        {
            var listEmployee = await _employeeData.GetData(pageRequest);
            var ListPage = new PageResult<EmployeeResult>()
            {
                Items = listEmployee,
                TotalRecord = listEmployee.Count()
            };
            return new ServiceResult()
            {
                Data = ListPage,
                Error = null,
                MISACukCukCode = MISACukCukServiceCode.Success
            };
        }

        /// <summary>
        /// Lấy ra toàn bộ danh sách nhân viên đầy đủ
        /// </summary>
        /// <param name="pageRequest"></param>
        /// <returns>ServiceResult</returns>
        /// create :4/2/2021
        public async Task<ServiceResult> GetFullData()
        {
            var listEmployee = await _employeeData.GetData();
            var ListPage = new PageResult<EmployeeResult>()
            {
                Items = listEmployee,
                TotalRecord = listEmployee.Count()
            };
            return new ServiceResult()
            {
                Data = ListPage,
                Error = null,
                MISACukCukCode = MISACukCukServiceCode.Success
            };
        }

        /// <summary>
        /// thêm mới nhân viên
        /// </summary>
        /// <param name="employee">thông tin nhân viên</param>
        /// <returns>ServiceResult</returns>
        /// update: 3/2/2021
        public override async Task<ServiceResult> Insert(Employee employee)
        {

            ServiceResult serviceResult = new ServiceResult();

            //validate Data
            _baseBussiness.ValidateObject(ref serviceResult, employee);
            // check trùng mã nhân viên
            CheckCustomerCodeDuplicate(ref serviceResult, employee.EmployeeCode);

            // Check trùng số điện thoại
            CheckPhoneNumberDuplicate(ref serviceResult, employee.PhoneNumber);

            // Check trùng email
            CheckEmailDuplicate(ref serviceResult, employee.Email);


            if (serviceResult.MISACukCukCode == MISACukCukServiceCode.BadRequest)
            {
                return serviceResult;
            }
            return await base.Insert(employee);            
        }

        /// <summary>
        /// cập nhập nhân viên
        /// </summary>
        /// <param name="employee">thông tin nhân viên</param>
        /// <returns>ServiceResult</returns>

        public override async Task<ServiceResult> Update(Employee employee)
        {
            ServiceResult serviceResult = new ServiceResult();
            _baseBussiness.ValidateObject(ref serviceResult, employee);
            var oldEmployee = (await _baseBussiness.GetById(employee.EmployeeId.ToString())).Data as Employee;
            
            // check mã nhân viên có bị trùng
            if (employee.EmployeeCode != oldEmployee.EmployeeCode)
            {
                CheckCustomerCodeDuplicate(ref serviceResult, employee.EmployeeCode);
            }
            // Check trùng số điện thoại
            if (employee.PhoneNumber != oldEmployee.PhoneNumber)
            {
                CheckPhoneNumberDuplicate(ref serviceResult, employee.PhoneNumber);
            }

            // Check trùng email
            if (employee.Email != oldEmployee.Email)
            {
                CheckEmailDuplicate(ref serviceResult, employee.Email);
            }
            
            if (serviceResult.MISACukCukCode == MISACukCukServiceCode.BadRequest)
            {
                return serviceResult;
            }
            
            return await base.Update(employee);
        }

        /// <summary>
        /// Xóa nhân viên theo id
        /// </summary>
        /// <param name="id">id của nhân viên</param>
        /// <returns>ServiceResult</returns>
        public override Task<ServiceResult> Delete(string id)
        {
            // valiable dữ liệu
            //todo...
            return base.Delete(id);
        }        

        /// <summary>
        /// Kiểm tra mã nhân viên đã tồn tại hay chưa
        /// </summary>
        /// <param name="serviceResult">tham chiếu gói trả về</param>
        /// <param name="employeeCode">mã nhân viên</param>
        /// create: 4/2/2021
        public void CheckCustomerCodeDuplicate(ref ServiceResult serviceResult, string employeeCode)
        {
            //var t = _employeeData.GetByEmployeeCode(employeeCode).GetAwaiter().GetResult();
            var listEmployee = Task.Run(async () => await _employeeData.GetByEmployeeCode(employeeCode)).Result;            
            if (listEmployee.Count() > 0)
            {
                serviceResult.Error.Add(new ErrorResult()
                {
                    DevMsg = Properties.Resources.ErrorService_Employee_EmployeeCode_duplicate,
                    UserMsg = Properties.Resources.ErrorService_Employee_EmployeeCode_duplicate

                });
                serviceResult.MISACukCukCode = MISACukCukServiceCode.BadRequest;
            }
        }

        /// <summary>
        /// Kiểm tra số điện thoại đã tồn tại hay chưa
        /// </summary>
        /// <param name="serviceResult">tham chiếu gói trả về</param>
        /// <param name="phoneNumber">số điện thoại</param>
        /// create: 4/2/2021
        public void CheckPhoneNumberDuplicate(ref ServiceResult serviceResult, string phoneNumber)
        {
            var listEmployee = Task.Run(async () => await _employeeData.GetByPhoneNumber(phoneNumber)).Result;
            if (listEmployee.Count() > 0)
            {
                serviceResult.Error.Add(new ErrorResult()
                {
                    DevMsg = Properties.Resources.ErrorService_Employee_PhoneNumber_duplicate,
                    UserMsg = Properties.Resources.ErrorService_Employee_PhoneNumber_duplicate

                });
                serviceResult.MISACukCukCode = MISACukCukServiceCode.BadRequest;
            }

        }

        /// <summary>
        /// Kiểm tra email đã tồn tại hay chưa
        /// </summary>
        /// <param name="serviceResult">tham chiếu gói trả về</param>
        /// <param name="email">email</param>
        /// create: 4/2/2021
        public void CheckEmailDuplicate(ref ServiceResult serviceResult, string email)
        {
            var listEmployee = Task.Run(async () => await _employeeData.GetByEmail(email)).Result;
            if (listEmployee.Count() > 0)
            {
                serviceResult.Error.Add(new ErrorResult()
                {
                    DevMsg = Properties.Resources.ErrorService_Employee_Email_duplicate,
                    UserMsg = Properties.Resources.ErrorService_Employee_Email_duplicate

                });
                serviceResult.MISACukCukCode = MISACukCukServiceCode.BadRequest;
            }
        }
    }
}
