using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kimerce.Backend.Dto.Models.Employees
{
    public class EmployeeModel : BaseModelGuid
    {
        [Required]
        [CheckDuplicate]
        public string EmployeeCode { get; set; }

        [Required]
        public string FullName { get; set; }
        [Required]
        public int Gender { set; get; }

        public DateTime DateOfBirth { set; get; }
        [CheckDuplicate]
        public string PhoneNumber { get; set; }
        [CheckDuplicate]
        [Email]
        public string Email { get; set; }

        public string Address { get; set; }
        [Required]
        [CheckDuplicate]
        public int IdentityNumber { get; set; }

        public string IdentityPlace { get; set; }

        public DateTime IdentityDate { get; set; }

        public DateTime JoinDate { get; set; }
        [Required]
        public int PersonalTaxCode { get; set; }

        public Decimal Salary { get; set; }
        [Required]
        public int WorkStatus { get; set; }
        [Required]
        public int PositionId { set; get; }
        [Required]
        public int DepartmentId { set; get; }
    }
}
