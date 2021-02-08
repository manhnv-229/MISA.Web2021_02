using MisaCukCuk_Entity.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MisaCukCuk_Infarstructure.Infarstructure.CustomerGroupInfarstructure
{
    public class CustomerGroupInfarstructureV2 : CustomerGroupInfarstructure
    {
        public CustomerGroupInfarstructureV2()
        {
            connectString = "User Id = nvmanh; host = 103.124.92.43; Database = MS1_23_TLMINH_CukCuk; port = 3306; password = 12345678; character Set = utf8"; 
             _db = new MySqlConnection(connectString);
        }
    }
}
