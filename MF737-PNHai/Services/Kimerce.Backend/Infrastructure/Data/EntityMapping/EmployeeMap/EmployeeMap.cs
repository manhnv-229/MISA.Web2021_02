
using Kimerce.Backend.Domain.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kimerce.Backend.Infrastructure.Data.EntityMapping.EmployeeMap
{
    public class EmployeeMap : IEntityMappingConfiguration<Employee>
    {
        public void Map(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");
        }
    }
}
