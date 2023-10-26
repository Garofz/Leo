using AuthSchema.Domain.UOW;
using AuthSchema.Infrastructure.Data.Context;
using AuthSchema.Infrastructure.Data.Providers;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSchema.Infrastructure.Data.UOW
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IDapperContext _context;
        private readonly RepositoryProvider _provider;
        private readonly IMapper _mapper;

        public UnitOfWorkFactory(IDapperContext context, RepositoryProvider provider, IMapper mapper)
        {
            _context = context;
            _provider = provider;
            _mapper = mapper;
        }
        public IUsuarioServiceUnifOfWork CreateUserUOW()
        {
            return new UsuarioServiceUnifOfWork(_context, _provider, _mapper);
        }

        T IUnitOfWorkFactory.Create<T>()
        {
            return (T)Activator.CreateInstance(typeof(T), _context, _provider, _mapper);
        }
    }
}
