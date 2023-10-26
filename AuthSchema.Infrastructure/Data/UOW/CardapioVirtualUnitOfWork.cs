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
    public class CardapioVirtualUnitOfWork : UnitOfWork, ICardapioVirtualUnitOfWork
    {
        private ICardapioVirtualRepository _cardapioRepository;
        private IDapperContext _context;
        private IMapper _mapper;

        public CardapioVirtualUnitOfWork(IDapperContext context, RepositoryProvider provider, IMapper mapper): base(context)
        {
            _cardapioRepository = provider.CardapioVirtualRepository;
            _context = context;
            _mapper = mapper;
        }

        public ICardapioVirtualRepository CardapioVirtualRepository => _cardapioRepository ?? (_cardapioRepository = new CardapioVirtualRepository(new UnitOfWork(_context), _mapper));
    }
}
