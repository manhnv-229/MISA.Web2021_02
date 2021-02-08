﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.BTL.Common
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
        public string Id
        {
            get
            {
                return CustomerId.ToString();
            }
        }
        public string CustomerCode { get; set; }
        public string FullName { get; set; }
        public string MemberCardCode { get; set; }
        public Guid CustomerGroupId { get; set; }
        public string IdCustomerGroup
        {
            get
            {
                return CustomerGroupId.ToString();
            }
        }
        public DateTime? DateOfBirth { get; set; }
        public int Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string CompanyTaxCode { get; set; }
    }
}