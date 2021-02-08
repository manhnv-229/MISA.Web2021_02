using Misa8b.CukCuk.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Misa8b.CukCuk.DL
{
    public class StringDbV2: IStringDb
    {
        protected string stringConnectionDb = "User Id=nvmanh;Host=103.124.92.43;" +
                "Database=MS2_29_DucToan_CukCuk;port=3306;password=12345678;Character Set=utf8";
        public string getStringDb()
        {
            return this.stringConnectionDb;
        }
    }
}
