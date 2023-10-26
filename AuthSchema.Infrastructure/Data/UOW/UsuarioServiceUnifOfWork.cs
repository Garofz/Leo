using AuthSchema.Domain.Repository;
using AuthSchema.Infrastructure.Data.Context;
using AuthSchema.Infrastructure.Data.Providers;
using AuthSchema.Infrastructure.Data.Repository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSchema.Infrastructure.Data.UOW
{
    public class UsuarioServiceUnifOfWork : UnitOfWork, IUsuarioServiceUnifOfWork
    {
        private IUserRepository _userRepository;
        private IDapperContext _context;
        private IMapper _mapper;

        public UsuarioServiceUnifOfWork(IDapperContext context, RepositoryProvider provider, IMapper mapper): base(context)
        {
            _userRepository = provider.UserRepository;
            _context = context;
            _mapper = mapper;
        }

        public IUserRepository UserRepository => _userRepository ?? (_userRepository = new UserRepository(new UnitOfWork(_context), _mapper));
    }
}
