using MISA.Common.Model;
using MISA.DataLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.DataLayer
{
    /// <summary>
    /// Kết nối với Database bảng CustomerGroup
    /// </summary>
    /// CreatedBy: NMDAT (02/04/2021)
    public class DbConnectCustomerGroup : DbContextV2<CustomerGroup>, ICustomerGroupDBConnection
    {
    }
}
