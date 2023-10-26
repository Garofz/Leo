using AuthSchema.Domain.Repository;
using AuthSchema.Domain.UOW;
using AuthSchema.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSchema.Infrastructure.Data.UOW
{
    public interface ICardapioVirtualUnitOfWork : IUnitOfWork<IDapperContext>
    {
        ICardapioVirtualRepository CardapioVirtualRepository{ get; }
    }
}
