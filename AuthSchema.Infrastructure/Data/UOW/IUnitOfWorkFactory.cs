using AuthSchema.Domain.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSchema.Infrastructure.Data.UOW
{
    public interface IUnitOfWorkFactory
    {
        IUsuarioServiceUnifOfWork CreateUserUOW();
        T Create<T>();
    }
}
