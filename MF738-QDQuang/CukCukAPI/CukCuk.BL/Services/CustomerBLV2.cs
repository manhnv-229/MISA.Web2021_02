using CukCuk.BL.Interfaces;
using CukCuk.Common.Models;
using CukCuk.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CukCuk.BL.Services
{
    public class CustomerBLV2:BaseBL<Customer>, ICustomerBL
    {
        public CustomerBLV2(IDbConnector<Customer> _customerDL) : base(_customerDL)
        {

        }
        protected override bool ValidateInsertData(Customer entity, ErrMsg errMsg)
        {
            return true;
        }
        protected override bool ValidateUpdateData(Customer entity, ErrMsg errMsg)
        {
            return true;
        }
    }
}
