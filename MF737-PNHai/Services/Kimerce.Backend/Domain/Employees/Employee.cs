using Kimerce.Backend.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kimerce.Backend.Domain.Employees
{
    public class Employee : BaseEntityByGuid
    {
       
        public string EmployeeCode { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public int Gender { set; get; }

        public DateTime DateOfBirth { set; get; }
        [Required]
        
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }

        public string Address { get; set; }
        [Required]
        public string IdentityNumber { get; set; }

        public string IdentityPlace { get; set; }

        public DateTime IdentityDate { get; set; }
        [Required]
        public DateTime JoinDate { get; set; }
        
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
