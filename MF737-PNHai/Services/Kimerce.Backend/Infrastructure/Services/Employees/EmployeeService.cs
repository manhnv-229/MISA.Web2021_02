using Kimerce.Backend.Domain.Employees;
using Kimerce.Backend.Dto;
using Kimerce.Backend.Dto.Models;
using Kimerce.Backend.Dto.Models.Employees;
using Kimerce.Backend.Dto.Results;
using Kimerce.Backend.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kimerce.Backend.Infrastructure.Services.Employees
{
    /// <summary>
    /// Các method tương tác với dữ liệu Employee
    /// </summary>
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> repository;
        /// <summary>
        /// Class cung cấp phương thức để thao tác với database liên quan đến employees
        /// </summary>
        /// <param name="repository"></param>
        public EmployeeService(IRepository<Employee> repository)
        {
            this.repository = repository;
        }

        private bool IsPhoneNumber(string number)
        {
            return Regex.Match(number, @"^(\+[0-9]{11})$").Success;
        }

        private BaseResult Validate(EmployeeModel model)
        {
            var rs = new BaseResult();

            var properties = model.GetType().GetProperties();
            foreach (var property in properties)
            {
                var propertyValue = property.GetValue(model);
                if (property.IsDefined(typeof(Required), true))
                {
                    // check trường bắt buộc 
                   
                    if(propertyValue == null)
                    {
                        rs.Result = Result.Failed;
                        rs.Message += property.Name + " Bị trống, hãy kiểm tra lại; ";
                    }
                   
                }
                if (property.IsDefined(typeof(CheckDuplicate), true))
                {
                   
                    
                    // check trường duy nhất trong cột 

                    if (propertyValue!=null)
                    {

                        var duplicate = repository.Duplicate(property.Name, propertyValue.ToString(), "EMPLOYEES");
                        if (duplicate)
                        {
                            rs.Result = Result.Failed;
                            rs.Message += property.Name + " không được trùng; ";
                        }
                       
                    }
                    
                }


            }
            return rs;
        }

        

 
        /// <summary>
        /// Tạo nhân viên mới 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<BaseResult> Create(EmployeeModel model)
        {
            var rs = Validate(model);
            var  item = model.ToEmployee();

            //if (!IsPhoneNumber(item.PhoneNumber))
            //{
            //    rs.Result = Result.Failed;
            //    rs.Message = "Số điện thoại không đúng, vui lòng kiểm tra lại";
            //    return rs;
            //}

           

            try
            {
                
                if (rs.Result != Result.Success)
                {
                   
                    return rs;
                }
                await repository.InsertAsync(item);
            }
            catch (Exception ex)
            {
                rs.Result = Result.SystemError;
                rs.Message = ex.ToString();
            }
          
            return rs;
        }

        /// <summary>
        /// Lấy danh sách các nhân viên chưa bị xóa 
        /// </summary>
        /// <param name="Filter"></param>
        /// <returns></returns>
        public async Task<List<EmployeeModel>> GetAll(String? Filter)
        {


            if (string.IsNullOrEmpty(Filter))
            {
                var x = repository.Query().ToList();
                List<EmployeeModel> res = new List<EmployeeModel>();
                foreach (Employee a in x)
                {
                    res.Add(a.ToModel());
                }
                return res;

            }
            else
            {
                Filter = Filter.Trim().ToLower();

                var x = repository.Query().Where(x => (x.FullName.Contains(Filter)) ||
                                                (x.PhoneNumber.Contains(Filter)) ||
                                                (x.EmployeeCode.Contains(Filter))).ToList();

                List<EmployeeModel> res = new List<EmployeeModel>();

                foreach (Employee a in x)
                {
                    res.Add(a.ToModel());
                }
                return res;

            }



        }
        /// <summary>
        /// Cập nhật nhân viên đang có trong công ty 
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public async Task<BaseResult> Update(EmployeeModel employee)
        {

            var rs = Validate(employee);
            if(rs.Result != Result.Success)
            {
                return rs;
            }
            var item = employee.ToEmployee();
            //if (!IsPhoneNumber(employee.PhoneNumber))
            //{
            //    rs.Result = Result.Failed;
            //    rs.Message = "Số điện thoại không đúng, vui lòng kiểm tra lại";
            //    return rs;
            //}
            var employeeUpdate = repository.GetById(item.Id);

            if (employeeUpdate != null)
            {

                try
                {
                    employeeUpdate = item.ToEmployee(employeeUpdate);
                    await repository.UpdateAsync(employeeUpdate);
                    repository.SaveChange();
                }
                catch (Exception ex)
                {
                    rs.Result = Result.SystemError;
                    rs.Message = ex.ToString();
                }
            }
            else
            {
                rs.Message = "Không tìm thấy nhân viên cần sửa";
                rs.Result = Result.Failed;
            }
            return rs;
        }
        /// <summary>
        /// Xóa nhân viên 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BaseResult> Delete(Guid id)
        {
            var rs = new BaseResult();
            var em = repository.QueryAll().FirstOrDefault(x => x.Id == id);
            if(em == null)
            {
                rs.Result = Result.Failed;
                rs.Message = "Không tìm thấy nhân viên này";
            }
            else
            {
                try
                {
                    await repository.DeleteAsync(em);
                }
                catch (Exception e)
                {
                    rs.Result = Result.SystemError;
                    rs.Message = e.ToString();
                }
            }
            return rs;
        }
    }
}
