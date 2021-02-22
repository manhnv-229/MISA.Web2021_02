using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.CukCuk.Core.Entities
{
    public class Rule
    {
        /// <summary>
        /// khóa chính
        /// </summary>
        public Guid RuleId { get; set; }
        /// <summary>
        /// Tên quyền
        /// </summary>
        public string RuleName { get; set; }
    }
}
