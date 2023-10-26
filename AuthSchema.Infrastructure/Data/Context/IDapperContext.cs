using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSchema.Infrastructure.Data.Context
{
    public interface IDapperContext
    {
        IDbConnection GetOpenConnection();
        IDbConnection GetCardapioVirtualConnection();
        IDbTransaction BeginTransaction();
        IDbTransaction BeginTransaction(IsolationLevel il);
        void ChangeDatabase(string databaseName);
        void Close();
        IDbCommand CreateCommand();
        void Dispose();
        void Open();

    }
}
