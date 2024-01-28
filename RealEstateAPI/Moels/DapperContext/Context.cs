﻿using Microsoft.Data.SqlClient;
using System.Data;

namespace RealEstateAPI.Moels.DapperContext
{
    public class Context
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public Context(IConfiguration configuration )
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("connection");
        }
        public IDbConnection CreateConnection() =>new SqlConnection(_connectionString);
    }
}
