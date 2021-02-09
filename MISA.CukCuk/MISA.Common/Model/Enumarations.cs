using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Common.Model
{
    public class Enumarations
    {
        public enum MISACode
        {
            Nocontent = 204,
            Success = 200,
            Validate = 404,
            Error = 500,
            Exception = 1000,
        }
        public enum Gender
        {
            Male = 1,
            Female = 0,
            Other = 2
        }
    }
}
