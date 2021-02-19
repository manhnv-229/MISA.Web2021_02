using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common
{
    public class Employeee
    {
        public Guid? EmployeeeId { get; set; }
        public string EmployeeeCode { get; set; }
        public string FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? Gender { get; set; }
        public Guid? PlaceWork { get; set; }
        public string Identity { get; set; }
        public DateTime? IdentityDate { get; set; }
        public string Position { get; set; }
        public string IdentityPlace { get; set; }
        public string Address { get; set; }
        public string CellPhone { get; set; }
        public string HomePhone { get; set; }
        public string Email { get; set; }
        public int? Capacity { get; set; }
    }
}
