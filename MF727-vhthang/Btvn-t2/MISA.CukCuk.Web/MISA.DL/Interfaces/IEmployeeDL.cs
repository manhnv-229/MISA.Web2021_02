﻿using MISA.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DL.Interfaces
{
    public interface IEmployeeDL
    {
        public IEnumerable<Employee> CheckDuplicate(string name, string value);


    }
}