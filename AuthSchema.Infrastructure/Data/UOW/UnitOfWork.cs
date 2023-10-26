using AuthSchema.Domain.UOW;
using AuthSchema.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace AuthSchema.Infrastructure.Data.UOW
{
    public class UnitOfWork : IUnitOfWork<IDapperContext> 
    {
        private readonly IDapperContext _context;
        private DbTransaction _transaction;
        public UnitOfWork(IDapperContext context)
        {
            _context = context;
        }

        public DbTransaction Transaction => _transaction;
        public IDapperContext Context => _context;


        public void BeginTransaction()
        {
            _transaction = (DbTransaction)_context.GetOpenConnection().BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
            _transaction = null;
        }

        public void Rollback()
        {
            _transaction.Rollback();
            _transaction = null;
        }
        public void Open()
        {
            _context.Open();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
