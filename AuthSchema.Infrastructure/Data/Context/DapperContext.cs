using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSchema.Infrastructure.Data.Context
{
    public class DapperContext : IDapperContext, IDbConnection
    {
        private readonly IDbConnection _connection;
        private readonly IConfiguration _configuration;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = new SqlConnection(_configuration.GetConnectionString("DBSM01"));
        }

        public IDbConnection GetOpenConnection()
        {
            return _connection;
        }

        public IDbConnection GetCardapioVirtualConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("CardapioVirtual"));
        }

        public string ConnectionString { get; set; }

        public int ConnectionTimeout => _connection.ConnectionTimeout;

        public string Database => _connection.Database;

        public ConnectionState State => _connection.State;

        public IDbTransaction BeginTransaction()
        {
            return _connection.BeginTransaction();
        }

        public IDbTransaction BeginTransaction(IsolationLevel il)
        {
            return _connection.BeginTransaction(il);
        }

        public void ChangeDatabase(string databaseName)
        {
            _connection.ChangeDatabase(databaseName);
        }

        public void Close()
        {
            _connection.Close();
        }

        public IDbCommand CreateCommand()
        {
            return _connection.CreateCommand();
        }

        public void Dispose()
        {
            _connection.Dispose();
        }

        public void Open()
        {
            _connection.Open();
        }
    }
}
