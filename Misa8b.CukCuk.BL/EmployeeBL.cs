using Misa.CukCuk.Common;
using Misa.CukCuk.Common.Enum;
using Misa8b.CukCuk.BL.Interfaces;
using Misa8b.CukCuk.BL.Result;
using Misa8b.CukCuk.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Misa8b.CukCuk.BL
{
    public class EmployeeBL : IEmployeeBL
    {
        IEmployeeDL _employeeDL;
        /// <summary>
        /// Khởi tạo một kết nối tới tầng database
        /// </summary>
        /// <param name="employeeDL"></param>
        public EmployeeBL(IEmployeeDL employeeDL)
        {
            _employeeDL = employeeDL;
        }
        /// <summary>
        /// hàm lấy dữ liệu bằng phòng ban và vị trí
        /// </summary>
        /// <param name="dep"></param>
        /// <param name="posi"></param>
        /// <returns></returns>
        public ActionServiceResult GetDataByDepAndPosi(string dep, string posi)
        {
            if (dep == "" && posi == "")
            {
                return new ActionServiceResult()
                {
                    Data = _employeeDL.GetDatas(),
                    Success = true,
                    Message = Misa.CukCuk.Common.Properties.Resources.Success_Mesenger + ". ",
                    MisaCode = Enumarations.MisaCode.Success
                };
            }
            else if (dep != "" && posi == "")
            {
                return new ActionServiceResult()
                {
                    Data = _employeeDL.GetEmployeeByDep(dep),
                    Success = true,
                    Message = Misa.CukCuk.Common.Properties.Resources.Success_Mesenger + ". ",
                    MisaCode = Enumarations.MisaCode.Success
                };
            }
            else if (dep == "" && posi != "")
            {
                return new ActionServiceResult()
                {
                    Data = _employeeDL.GetEmployeeByPosi(posi),
                    Success = true,
                    Message = Misa.CukCuk.Common.Properties.Resources.Success_Mesenger + ". ",
                    MisaCode = Enumarations.MisaCode.Success
                };
            }
            else
            {
                return new ActionServiceResult()
                {
                    Data = _employeeDL.GetEmployeeByDepAndPosi(dep, posi),
                    Success = true,
                    Message = Misa.CukCuk.Common.Properties.Resources.Success_Mesenger + ". ",
                    MisaCode = Enumarations.MisaCode.Success
                };
            }

        }
        /// <summary>
        /// lấy dữ liệu bằng vị trí
        /// </summary>
        /// <param name="posi"></param>
        /// <returns></returns>
        public ActionServiceResult GetDataByPosi(string posi)
        {
            return new ActionServiceResult()
            {
                Data = _employeeDL.GetEmployeeByPosi(posi),
                Success = true,
                Message = Misa.CukCuk.Common.Properties.Resources.Success_Mesenger + ". ",
                MisaCode = Enumarations.MisaCode.Success
            };
        }
        /// <summary>
        /// lấy dữ liệu nhân viên bằng phòng ban
        /// </summary>
        /// <param name="dep"></param>
        /// <returns></returns>
        public ActionServiceResult GetDataByDep(string dep)
        {
            return new ActionServiceResult()
            {
                Data = _employeeDL.GetEmployeeByDep(dep),
                Success = true,
                Message = Misa.CukCuk.Common.Properties.Resources.Success_Mesenger + ". ",
                MisaCode = Enumarations.MisaCode.Success
            };
        }
        /// <summary>
        /// thêm mới nhân viên
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public ActionServiceResult InsertData(Employee data)
        {
            string mesage = "";
            // 1. Kiểm tra trùng mã code
            if (data.EmployeeCode.Trim() == string.Empty)
            {
                mesage += Misa.CukCuk.Common.Properties.Resources.Err_EmptyCode + ". ";
            }
            else if (_employeeDL.CheckDuplicateDataCode(data.EmployeeCode) == true)
            {
                mesage += Misa.CukCuk.Common.Properties.Resources.Err_DupCode + ". ";
            }
            // 2. kiểm tra họ tên phải nhập

            if (data.FullName.Trim() == string.Empty)
            {
                mesage += Misa.CukCuk.Common.Properties.Resources.Err_EmptyName + ". ";
            }
            // kiểm tra số điện thoại
            if (data.PhoneNumber.Trim() == string.Empty)
            {
                mesage += Misa.CukCuk.Common.Properties.Resources.Err_EmptyPhoneNumber + ". ";
            }
            else if (_employeeDL.CheckDuplicateDataPhoneNumber(data.PhoneNumber) == true)
            {
                mesage += Misa.CukCuk.Common.Properties.Resources.Err_DupPhoneNumber + ". ";
            }
            //Kiểm tra Email đã nhập chưa 
            if (data.Email.Trim() == string.Empty)
            {
                mesage += Misa.CukCuk.Common.Properties.Resources.Err_EmptyEmail + ". ";
            }
            //Kiểm tra CMND đã nhập chưa hay bị trùng
            if (data.IdentityCard.Trim() == string.Empty)
            {
                mesage += Misa.CukCuk.Common.Properties.Resources.Err_EmptyIdent + ". ";

            }
            else if (_employeeDL.CheckDuplicateIdent(data.IdentityCard) == true)
            {
                mesage += Misa.CukCuk.Common.Properties.Resources.Err_DupIdent + ". ";
            }
            if (mesage == "")
            {
                _employeeDL.InsertData(data);
                return new ActionServiceResult()
                {
                    Success = true,
                    Message = Misa.CukCuk.Common.Properties.Resources.Success_Mesenger + ". ",
                    MisaCode = Enumarations.MisaCode.Success,
                    Data = null
                };
            }
            else return new ActionServiceResult()
            {
                Success = false,
                Message = mesage,
                MisaCode = Enumarations.MisaCode.Validate,
                Data = null
            };
        }
        /// <summary>
        /// lấy toàn bộ dữ liệu nhân viên
        /// </summary>
        /// <returns></returns>
        public ActionServiceResult GetAllData()
        {
            return new ActionServiceResult()
            {
                Success = true,
                Message = Misa.CukCuk.Common.Properties.Resources.Success_Mesenger + ". ",
                MisaCode = Enumarations.MisaCode.Success,
                Data = _employeeDL.GetDatas()
            };
        }
        /// <summary>
        /// lấy dữ liệu nhân viên bằng phân trang
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="ofset"></param>
        /// <returns></returns>
        public ActionServiceResult GetAllDataPagging(int limit, int ofset)
        {
            return new ActionServiceResult()
            {
                Success = true,
                Message = Misa.CukCuk.Common.Properties.Resources.Success_Mesenger + ". ",
                MisaCode = Enumarations.MisaCode.Success,
                Data = _employeeDL.GetAllDataPagging(limit, ofset),
            };
        }
        /// <summary>
        /// lấy dữ liệu nhân viên bằng mã ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionServiceResult GetDataById(Guid id)
        {
            //kiểm tra xem có mã id trong database không
            if (_employeeDL.CheckDuplicateDataId(id) == true)
            {
                return new ActionServiceResult()
                {
                    Success = true,
                    Message = Misa.CukCuk.Common.Properties.Resources.Success_Mesenger + ". ",
                    MisaCode = Enumarations.MisaCode.Success,
                    Data = _employeeDL.GetDataId(id)
                };
            }

            else return new ActionServiceResult()
            {
                Success = false,
                Message = Misa.CukCuk.Common.Properties.Resources.Err_NotId + ". ",
                MisaCode = Enumarations.MisaCode.Validate,
                Data = null
            };

        }
        /// <summary>
        /// lấy dữ liệu bằng mã code, tên và số điện thoại
        /// </summary>
        /// <param name="datacode"></param>
        /// <param name="fullname"></param>
        /// <param name="phonenumber"></param>
        /// <returns></returns>
        public ActionServiceResult GetDataByOthers(string datacode, string fullname, string phonenumber)
        {
            if (_employeeDL.CheckListDataCode(datacode) == false &&
                _employeeDL.CheckListDataFullName(fullname) == false
                && _employeeDL.CheckListDataPhoneNumber(phonenumber) == false)
            {
                return new ActionServiceResult()
                {
                    Success = true,
                    Data = null,
                    Message = Misa.CukCuk.Common.Properties.Resources.Err_SearchData + ". ",
                    MisaCode = Enumarations.MisaCode.Success
                };
            }
            else
            {
                return new ActionServiceResult()
                {
                    Success = true,
                    Data = _employeeDL.GetEmployeeByOthers(datacode, fullname, phonenumber),
                    Message = Misa.CukCuk.Common.Properties.Resources.Success_Mesenger + ". ",
                    MisaCode = Enumarations.MisaCode.Success
                };
            };
        }
        /// <summary>
        /// cập nhật, sửa dữ liệu nhân viên
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public ActionServiceResult UpdateData(Employee data)
        {
            Employee tempData = _employeeDL.GetDataId(data.EmployeeId);
            string mesage = "";
            // 1. Kiểm tra trùng mã code
            if (data.EmployeeCode.Trim() == string.Empty)
            {
                mesage += Misa.CukCuk.Common.Properties.Resources.Err_EmptyCode + ". ";
            }
            else if (data.EmployeeCode != tempData.EmployeeCode && _employeeDL.CheckDuplicateDataCode(data.EmployeeCode) == true)
            {
                mesage += Misa.CukCuk.Common.Properties.Resources.Err_DupCode + ". ";
            }
            // 2. kiểm tra họ tên bị trùng

            if (data.FullName.Trim() == string.Empty)
            {
                mesage += Misa.CukCuk.Common.Properties.Resources.Err_EmptyName + ". ";
            }
            // kiểm tra số điện thoại
            if (data.PhoneNumber.Trim() == string.Empty)
            {
                mesage += Misa.CukCuk.Common.Properties.Resources.Err_EmptyPhoneNumber + ". ";
            }
            else if (data.PhoneNumber != tempData.PhoneNumber && _employeeDL.CheckDuplicateDataPhoneNumber(data.PhoneNumber) == true)
            {
                mesage += Misa.CukCuk.Common.Properties.Resources.Err_DupPhoneNumber + ". ";
            }
            //Kiểm tra Email đã nhập chưa 
            if (data.Email.Trim() == string.Empty)
            {
                mesage += Misa.CukCuk.Common.Properties.Resources.Err_EmptyEmail + ". ";
            }
            //Kiểm tra CMND đã nhập chưa hay bị trùng
            if (data.IdentityCard.Trim() == string.Empty)
            {
                mesage += Misa.CukCuk.Common.Properties.Resources.Err_EmptyIdent + ". ";

            }
            else if (data.IdentityCard != tempData.IdentityCard && _employeeDL.CheckDuplicateIdent(data.IdentityCard) == true)
            {
                mesage += Misa.CukCuk.Common.Properties.Resources.Err_DupIdent + ". ";
            }
            if (mesage == "")
            {
                _employeeDL.UpdateData(data);
                return new ActionServiceResult()
                {
                    Success = true,
                    Message = Misa.CukCuk.Common.Properties.Resources.Success_Mesenger + ". ",
                    MisaCode = Enumarations.MisaCode.Success,
                    Data = null
                };
            }
            else return new ActionServiceResult()
            {
                Success = false,
                Message = mesage,
                MisaCode = Enumarations.MisaCode.Validate,
                Data = null
            };
        }
        /// <summary>
        /// xóa 1 nhân viên
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionServiceResult DeleteEmployee(Guid id)
        {
            Employee data = _employeeDL.GetDataId(id);
            var dataCode = data.EmployeeCode;
            var dataName = data.FullName;
            if (_employeeDL.CheckDuplicateDataId(id) == false)
                return new ActionServiceResult()
                {
                    Success = false,
                    Message = Misa.CukCuk.Common.Properties.Resources.Err_NotDupId,
                    MisaCode = Enumarations.MisaCode.Validate,
                    Data = null
                };
            else
            {
                _employeeDL.DeleteData(id);
                return new ActionServiceResult()
                {
                    Success = true,
                    Message = Misa.CukCuk.Common.Properties.Resources.DeleteP1 + dataCode +
                    Misa.CukCuk.Common.Properties.Resources.DeleteP2 + dataName,
                    MisaCode = Enumarations.MisaCode.Success,
                    Data = null
                };
            }

        }
        


    }
}
