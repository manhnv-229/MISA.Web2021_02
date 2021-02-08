using Common;
using MISA.Common;
using MISA.DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.DataLayer.DbContext2
{
    public class DbContextV2<TEntity> : IDbContext<TEntity>
    {
        List<Employee> employees;
        List<Office> offices;
        List<Position> positions;

        public DbContextV2()
        {
            employees = new List<Employee>();
            offices = new List<Office>();
            positions = new List<Position>();

            var e1 = new Employee()
            {
                EmployeeId = Guid.NewGuid(),
                EmployeeCode = "NV-000218",
                FullName = "Trương Văn Lan",
                Gender = 1,
                DateOfBirth = DateTime.Parse("1991-06-29"),
                PhoneNumber = "0894797778",
                Email = "Titus1@nowhere.com",
                OfficeId = null,
                PositionId = null,
                Salary = 25835675,
                StatusWork = 1,
                CMTND = "73873651",
                CMTNDDate = DateTime.Parse("1991-06-29"),
                CMTNDPlace = "Bắc Ninh",
                PersonalTaxCode = null,
                DateStartWork = DateTime.Parse("2000-06-29")
            };
            var e2 = new Employee()
            {
                EmployeeId = Guid.NewGuid(),
                EmployeeCode = "NV-000219",
                FullName = "Trương Văn Thành",
                Gender = 1,
                DateOfBirth = DateTime.Parse("1991-06-29"),
                PhoneNumber = "0894797778",
                Email = "Titus1@nowhere.com",
                OfficeId = null,
                PositionId = null,
                Salary = 111111111,
                StatusWork = 1,
                CMTND = "73873651",
                CMTNDDate = DateTime.Parse("1998-06-29"),
                CMTNDPlace = "Bắc Ninh",
                PersonalTaxCode = null,
                DateStartWork = DateTime.Parse("2000-06-29")
            };
            employees.Add(e1);
            employees.Add(e2);
            var o1 = new Office()
            {
                OfficeId = Guid.NewGuid(),
                OfficeName = "Phòng 1",
                Description = "Phòng đầu tiên"
            };
            var o2 = new Office()
            {
                OfficeId = Guid.NewGuid(),
                OfficeName = "Phòng 2",
                Description = "Phòng thứ hai"
            };
            offices.Add(o1); offices.Add(o2);
            var p1 = new Position()
            {
                PositionId = Guid.NewGuid(),
                PositionName = "Phòng 1",
                Description = "Vị trí đầu tiên"
            };
            var p2 = new Position()
            {
                PositionId = Guid.NewGuid(),
                PositionName = "Phòng 2",
                Description = "Vị trí thứ hai"
            };
            positions.Add(p1); positions.Add(p2);
        }

        public int Delete(string entityId)
        {
            return 0;
        }

        public IEnumerable<TEntity> GetAll(string query = null, object param = null, CommandType cmdType = CommandType.Text)
        {
            if (typeof(TEntity).Name == "Employee")
                return (IEnumerable<TEntity>)employees;
            else if (typeof(TEntity).Name == "Office")
                return (IEnumerable<TEntity>)offices;
            return (IEnumerable<TEntity>)positions;
        }

        public int Insert(TEntity entity)
        {
            return 1;
        }

        public int Put(TEntity entity)
        {
            return 1;
        }
    }
}
