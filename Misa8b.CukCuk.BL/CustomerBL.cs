using Misa.CukCuk.Common;
using Misa.CukCuk.Common.Enum;
using Misa8b.CukCuk.BL.Interfaces;
using Misa8b.CukCuk.BL.Result;
using Misa8b.CukCuk.DL;
using Misa8b.CukCuk.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using static Misa.CukCuk.Common.Enum.Enumarations;

namespace Misa8b.CukCuk.BL
{
    public class CustomerBL : ICustomerBL
    {
        ICustomerDL _customerDL;
        public CustomerBL(ICustomerDL customerDL)
        {
            _customerDL = customerDL;
        }
        public ActionServiceResult InsertData(Customer data)
        {
            string mesage = "";
            // 1. Kiểm tra trùng mã code
            if (data.CustomerCode.Trim() == string.Empty)
            {
                mesage += Misa.CukCuk.Common.Properties.Resources.Err_EmptyCode + ". ";
            }
            else if (_customerDL.CheckDuplicateDataCode(data.CustomerCode) == true)
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
            else if (_customerDL.CheckDuplicateDataPhoneNumber(data.PhoneNumber) == true)
            {
                mesage += Misa.CukCuk.Common.Properties.Resources.Err_DupPhoneNumber + ". ";
            }
            if (mesage == "")
            {
                _customerDL.InsertData(data);
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
        public ActionServiceResult GetAllData()
        {
            return new ActionServiceResult()
            {
                Success = true,
                Message = Misa.CukCuk.Common.Properties.Resources.Success_Mesenger + ". ",
                MisaCode = Enumarations.MisaCode.Success,
                Data = _customerDL.GetDatas()
            };
        }
        public ActionServiceResult GetDataById(Guid id)
        {
            if (_customerDL.CheckDuplicateDataId(id) == true)
            {
                return new ActionServiceResult()
                {
                    Success = true,
                    Message = Misa.CukCuk.Common.Properties.Resources.Success_Mesenger + ". ",
                    MisaCode = Enumarations.MisaCode.Success,
                    Data = _customerDL.GetDataId(id)
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
        public ActionServiceResult GetDataByOthers(string datacode, string fullname, string phonenumber)
        {
            if (_customerDL.CheckListDataCode(datacode) == false)
            {
                return new ActionServiceResult()
                {
                    Success = false,
                    Data = null,
                    Message = Misa.CukCuk.Common.Properties.Resources.Err_EmptyListCode + ". ",
                    MisaCode = Enumarations.MisaCode.Validate
                };
            }
            if (_customerDL.CheckListDataFullName(fullname) == false)
            {
                return new ActionServiceResult()
                {
                    Success = false,
                    Data = null,
                    Message = Misa.CukCuk.Common.Properties.Resources.Err_EmptyListName + ". ",
                    MisaCode = Enumarations.MisaCode.Validate
                };
            }
            if (_customerDL.CheckListDataPhoneNumber(phonenumber) == false)
            {
                return new ActionServiceResult()
                {
                    Success = false,
                    Data = null,
                    Message = Misa.CukCuk.Common.Properties.Resources.Err_EmptyListPhoneNumber + ". ",
                    MisaCode = Enumarations.MisaCode.Validate
                };
            }
            return new ActionServiceResult()
            {
                Success = true,
                Data = _customerDL.GetCustomerByOthers(datacode, fullname, phonenumber),
                Message = Misa.CukCuk.Common.Properties.Resources.Success_Mesenger + ". ",
                MisaCode = Enumarations.MisaCode.Success
            };
        }
        public ActionServiceResult UpdateData(Customer data)
        {
            Customer tempData = _customerDL.GetDataId(data.CustomerId);
            string mesage = "";
            // 1. Kiểm tra trùng mã code
            if (data.CustomerCode.Trim() == string.Empty)
            {
                mesage += Misa.CukCuk.Common.Properties.Resources.Err_EmptyCode + ". ";
            }
            else if (data.CustomerCode != tempData.CustomerCode && _customerDL.CheckDuplicateDataCode(data.CustomerCode) == true)
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
            else if (data.PhoneNumber != tempData.PhoneNumber && _customerDL.CheckDuplicateDataPhoneNumber(data.PhoneNumber) == true)
            {
                mesage += Misa.CukCuk.Common.Properties.Resources.Err_DupPhoneNumber + ". ";
            }
            if (mesage == "")
            {
                _customerDL.UpdateData(data);
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
        public ActionServiceResult DeleteCustomer(Guid id)
        {
            Customer data = _customerDL.GetDataId(id);
            if (_customerDL.CheckDuplicateDataId(id) == false)
                return new ActionServiceResult()
                {
                    Success = false,
                    Message = Misa.CukCuk.Common.Properties.Resources.Err_NotDupId,
                    MisaCode = Enumarations.MisaCode.Validate,
                    Data = null
                };
            else
            {
                _customerDL.DeleteData(id);
                return new ActionServiceResult()
                {
                    Success = true,
                    Message = Misa.CukCuk.Common.Properties.Resources.Success_Mesenger + ". ",
                    MisaCode = Enumarations.MisaCode.Success,
                    Data = null
                };
            }

        }
    }
}
