using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Models
{
    public class BaseModel
    {
        public BaseModel()
        {
            CustomerId = Guid.NewGuid();
        }
        public Guid CustomerId { get; set; }

       
    }
}
