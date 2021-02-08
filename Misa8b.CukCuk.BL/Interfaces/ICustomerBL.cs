using Misa.CukCuk.Common;
using Misa8b.CukCuk.BL.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace Misa8b.CukCuk.BL.Interfaces
{
    public interface ICustomerBL
    {
        public ActionServiceResult InsertData(Customer customer);
        public ActionServiceResult GetAllData();
        public ActionServiceResult GetDataById(Guid id);
        public ActionServiceResult GetDataByOthers(string customercode, string fullname, string phonenumber);
        public ActionServiceResult UpdateData(Customer customer);
        public ActionServiceResult DeleteCustomer(Guid id);
    }
}
