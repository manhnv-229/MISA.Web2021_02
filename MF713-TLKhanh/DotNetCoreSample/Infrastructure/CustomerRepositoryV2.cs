using AplicationCore.Entities;
using AplicationCore.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Text;
using Dapper;

namespace Infrastructure
{
    public class CustomerRepositoryV2 : BaseRepositoryV2<Customer>, ICustomerRepository
    {
        public CustomerRepositoryV2(IConfiguration configuration) : base(configuration)
        {

        }
    }
}
