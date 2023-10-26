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
    public class AccessKeyUnitOfWork : UnitOfWork, IAccessKeyUnitOfWork
    {
        private IAccessKeyRepository _accessKeyRepository;
        private IProductRepository _productRepository;
        private IDapperContext _context;
        private IMapper _mapper;

        public AccessKeyUnitOfWork(IDapperContext context, RepositoryProvider provider, IMapper mapper) : base(context)
        {
            _accessKeyRepository = provider.AccessKeyRepository;
            _productRepository = provider.ProductRepository;
            _context = context;
            _mapper = mapper;
        }

        public IAccessKeyRepository AccessKeyRepository => _accessKeyRepository ?? (_accessKeyRepository = new AccessKeyRepository(new UnitOfWork(_context), _mapper));
        public IProductRepository ProductRepository => _productRepository ?? (_productRepository = new ProductRepository(new UnitOfWork(_context), _mapper));
    }
}

