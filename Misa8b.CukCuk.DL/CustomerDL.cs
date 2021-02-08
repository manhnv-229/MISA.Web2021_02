using Dapper;
using Misa.CukCuk.Common;
using Misa8b.CukCuk.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Misa8b.CukCuk.DL
{
    public class CustomerDL:BaseDL<Customer>, ICustomerDL
    {
        //public List<Customer> GetDataByOthers(string datacode, string fullname, string phonenumber)
        //{
        //    return this.GetCustomerByOthers<Customer>(datacode, fullname, phonenumber);
        //}
        public List<Customer> GetCustomerByOthers(string customercode, string fullname, string phonenumber)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add($"@CustomerCodeContaints", customercode);
            dynamicParameters.Add($"@FullNameContaints", fullname);
            dynamicParameters.Add($"@PhoneNumberContaints", phonenumber);
            return dbConnection.Query<Customer>($"Proc_GetCustomerByOthers", dynamicParameters, commandType: CommandType.StoredProcedure).ToList();
        }
    }
}
