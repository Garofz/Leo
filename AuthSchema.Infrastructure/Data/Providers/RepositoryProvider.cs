using AuthSchema.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSchema.Infrastructure.Data.Providers
{
    public class RepositoryProvider
    {
        public IUserRepository UserRepository { get; set; }
        public IAccessKeyRepository AccessKeyRepository{ get; set; }
        public IProductRepository ProductRepository{ get; set; }
        public ICardapioVirtualRepository CardapioVirtualRepository { get; set; }
    }
}
