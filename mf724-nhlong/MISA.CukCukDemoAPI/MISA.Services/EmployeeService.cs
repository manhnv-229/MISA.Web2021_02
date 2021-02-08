using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using MISA.Service.Interfaces;
using MISA.Service.Entities;

namespace MISA.Service
{
    public class EmployeeService : BaseService<Employee>,IEmployeeServices
    {
        #region Declare Field
        IBaseReposity<Employee> _baseReposity;
        IEmployeeReposity _employeeReposity;
        #endregion

        #region Constructor
        public EmployeeService(IBaseReposity<Employee>  baseReposity,IEmployeeReposity employeeReposity):base(baseReposity)
        {
            _baseReposity = baseReposity;
            _employeeReposity = employeeReposity;
        }
        #endregion

        public override ServiceResult GetEntities()
        {
            var employeeList = _employeeReposity.GetEntities();
            var serviceResult = new ServiceResult();
            if (employeeList != null)
            {
                serviceResult.Data = employeeList;
                serviceResult.Success = true;
            }
            return serviceResult;
        }

        public override ServiceResult AddEntity(Employee employee)
        {
            
            var serviceResult = new ServiceResult();
            var errorMsg = new ErrorMsg();


            if (employee.EmployeeCode == null)
            {
                // errorMsg.DevMsg = "DB thiet lap unique code cho khach hang";
                // errorMsg.UserMsg = "Ma NV khong duocj ph";
                serviceResult.Success = false;
                serviceResult.Data = "Khong duoc de trong Ma Nhan Vien";
                return serviceResult;
            }

            if (employee.DepartmentName != "Phòng Marketing" && employee.DepartmentName != "Phòng Công Nghệ" && employee.DepartmentName != "Phòng Nhân Sự"
                    && employee.DepartmentName != "Phòng Đào Tạo")
            {
                // errorMsg.DevMsg = "DB thiet lap unique code cho khach hang";
                // errorMsg.UserMsg = "Ma NV khong duocj ph"
                serviceResult.Success = false;
                serviceResult.Data = "Sai Phong Ban";
                return serviceResult;
            }
            
            if (employee.JobPosition != "Giám Đốc" && employee.JobPosition != "Phó phòng" && employee.JobPosition != "Trưởng phòng" && employee.JobPosition != "Nhân Viên")
            {
                // errorMsg.DevMsg = "DB thiet lap unique code cho khach hang";
                // errorMsg.UserMsg = "Ma NV khong duocj ph"
                serviceResult.Success = false;
                serviceResult.Data = "Sai Vi tri";
                return serviceResult;
            }
            if (String.IsNullOrEmpty(employee.FullName))
            {
                // errorMsg.DevMsg = "DB thiet lap unique code cho khach hang";
                // errorMsg.UserMsg = "Ma NV khong duocj ph"
                serviceResult.Success = false;
                serviceResult.Data = "Ho ten khong duoc de trong";
                return serviceResult;
            }
            if (!IsValid(employee.Email))
            {
                // errorMsg.DevMsg = "DB thiet lap unique code cho khach hang";
                // errorMsg.UserMsg = "Ma NV khong duocj ph"
                serviceResult.Success = false;
                serviceResult.Data = "Email Khong Hop Le";
                return serviceResult;
            }

            if (!IsDigitsOnly(employee.PhoneNumber) || !IsDigitsOnly(employee.IdentityCardCode))
            {
                // errorMsg.DevMsg = "DB thiet lap unique code cho khach hang";
                // errorMsg.UserMsg = "Ma NV khong duocj ph"
                serviceResult.Success = false;
                serviceResult.Data = "SDT khong hop le";
                return serviceResult;
            }

            var isExist  = _employeeReposity.GetEntityByCode(employee.EmployeeCode);
            if (isExist != null)
            {
                // errorMsg.DevMsg = "DB thiet lap unique code cho khach hang";
                // errorMsg.UserMsg = "Ma NV khong duocj ph";
                serviceResult.Success = false;
                serviceResult.Data = "Trung Ma Nhan vien";
                return serviceResult;
            }

            // isExist = dbContext.CheckExistPhoneNumber(employee.PhoneNumber);
            // if (isExist == true)
            // {
            //     // errorMsg.DevMsg = "DB thiet lap unique code cho khach hang";
            //     // errorMsg.UserMsg = "Ma NV khong duocj ph";
            //     serviceResult.Success = false;
            //     serviceResult.Data = "Trung SDT";
            //     return serviceResult;
            // }

            employee.EmployeeID = Guid.NewGuid();

            var res = _employeeReposity.AddEntity(employee);
            if (res > 0)
            {
                serviceResult.Success = true;
                serviceResult.Data = res;
                return serviceResult;
            }
            else {
                serviceResult.Success = false;
                serviceResult.Data = "Khong them duoc nhan vien. Loi DB";
                return serviceResult;
            }
        }

        public override ServiceResult UpdateEntity(Employee employee)
        {
            var serviceResult = new ServiceResult
            {
                Success = true
            };

            if (employee.DepartmentName != "Phòng Marketing" && employee.DepartmentName != "Phòng Công Nghệ" && employee.DepartmentName != "Phòng Nhân Sự"
                    && employee.DepartmentName != "Phòng Đào Tạo")
                {
                    serviceResult.Success = false;
                    serviceResult.Data = "Sai phòng ban";
                    return serviceResult;
                };
                
            if (employee.JobPosition != "Giám Đốc" && employee.JobPosition != "Phó phòng" && employee.JobPosition != "Trưởng phòng" && employee.JobPosition != "Nhân Viên")
                {
                    serviceResult.Success = false;
                    serviceResult.Data = "Sai Vi tri";
                    return serviceResult;
                };
            
            if (String.IsNullOrEmpty(employee.FullName))
                {
                    serviceResult.Success = false;
                    serviceResult.Data = "Khong Duoc de trong ten";
                    return serviceResult;
                };

            if (!IsValid(employee.Email))
                {
                    serviceResult.Success = false;
                    serviceResult.Data = "Sai Email";
                    return serviceResult;
                };

            if (!IsDigitsOnly(employee.PhoneNumber) || !IsDigitsOnly(employee.IdentityCardCode))
                {
                    serviceResult.Success = false;
                    serviceResult.Data = "Sai SDT";
                    return serviceResult;
                };

            serviceResult.Data = _employeeReposity.UpdateEntity(employee);
            
            return serviceResult;
        }

        public ServiceResult GetEmployeePaging(int limit, int offset){
            
            var serviceResult = new ServiceResult();
            serviceResult.Success = false;
            
            return serviceResult;
        }

         public ServiceResult GetEmployeesByDepartment(Guid id){
            
            var serviceResult = new ServiceResult();
            serviceResult.Success = false;
            
            return serviceResult;
        }

         public ServiceResult GetEmployeesByPosition(int JobPosition){
            
            var serviceResult = new ServiceResult();
            serviceResult.Success = false;
            
            return serviceResult;
        }
        
        public ServiceResult GetLastestEmployeeCode(){
            var serviceResult = new ServiceResult();
            serviceResult.Success = false;
            var employee = _employeeReposity.GetLastestEmployeeCode();
            serviceResult.Data = employee.EmployeeCode;
            return serviceResult;
        }
    }
}
