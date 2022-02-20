using Core.Repositories.Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class SqlDapperHelper : DapperHelper
    {
        protected override IDbConnection CreateConnection()
        {
            var connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=DilekDB;Integrated Security=True;MultipleActiveResultSets=True";
            var factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
            var connection = factory.CreateConnection();
            connection.ConnectionString = connectionString;
            return connection;
        }
    }
}
