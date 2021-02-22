using MISA.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataLayer.DbContext2
{
    public class OfficeRepositoryV2<Office> : DbContextV2<Office>,IOfficeRepository<Office>
    {
       
    }
}
