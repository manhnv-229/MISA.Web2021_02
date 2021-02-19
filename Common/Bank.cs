using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common
{
    public class Bank
    {
        public Guid? BankId { get; set; }
        public Guid? UserId { get; set; }
        public string BankCode { get; set; }
        public string NameBank { get; set; }
        public string BranchBank { get; set; }
        public string PlaceBank { get; set; }
    }
}
