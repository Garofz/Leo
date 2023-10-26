using AuthSchema.Domain.Model;
using AuthSchema.Domain.Model.CardapioVirtual;
using AuthSchema.Domain.Repository;
using AuthSchema.Domain.UOW;
using AuthSchema.Infrastructure.Data.Context;
using AuthSchema.Infrastructure.Data.DTO;
using AuthSchema.Infrastructure.Data.DTO.CardapioVirtual;
using AutoMapper;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSchema.Infrastructure.Data.Repository
{
    public class CardapioVirtualRepository : ICardapioVirtualRepository
    {
        private readonly IUnitOfWork<IDapperContext> _unitOfWork;
        private readonly IMapper _mapper;
        public CardapioVirtualRepository(IUnitOfWork<IDapperContext> unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Cliente> ConsultarClientesAsync(int idCliente)
        {
            var result = await _unitOfWork.Context.GetCardapioVirtualConnection().QueryFirstOrDefaultAsync<ClienteDTO>(@"
                SELECT        IdCliente, Nome, Inscricao, IdTipoPessoa, Ativo, Logo, UsuarioInclusao, DataInclusao, UsuarioAlteracao, DataAlteracao
                FROM            Cliente
                WHERE        (IdCliente = @IdCliente)
            ", new 
            {
                IdCliente = idCliente
            }).ConfigureAwait(false);
            return _mapper.Map<Cliente>(result);
        }

        public async Task<IEnumerable<UserCliente>> ConsultarClientesUsuarioAsync(int userId)
        {
            var result = await _unitOfWork.Context.GetCardapioVirtualConnection().QueryAsync<UserClienteDTO>(@"
                SELECT        IdUsuarioCliente, IdUsuario, IdCliente, IndAcessoPrincipal, IndPrimeiroAcesso, IdTipoAcesso, DataUltimoAcesso, DataInativacaoAcesso, DataCadastro
                FROM            UsuarioCliente
                WHERE        (IdUsuario = @IdUsuario )
            ", new
            {
                IdUsuario = userId
            }).ConfigureAwait(false);
            return _mapper.Map<IEnumerable<UserCliente>>(result);
        }

        public async Task<TipoAcesso> ConsultarTipoAcessoAsync(int idTipoAcesso)
        {
            var result = await _unitOfWork.Context.GetCardapioVirtualConnection().QueryFirstOrDefaultAsync<TipoAcessoDTO>(@"
                SELECT        IdTipoAcesso, Descricao
                FROM            TipoAcesso
                WHERE        (IdTipoAcesso = @IdTipoAcesso)
            ", new
            {
                IdTipoAcesso = idTipoAcesso
            }).ConfigureAwait(false);
            return _mapper.Map<TipoAcesso>(result);
        }

        public async Task<TipoPessoa> ConsultarTipoPessoaAsync(int idTipoPessoa)
        {
            var result = await _unitOfWork.Context.GetCardapioVirtualConnection().QueryFirstOrDefaultAsync<TipoPessoaDTO>(@"
                SELECT        IdTipoPessoa, Descricao
                FROM            TipoPessoa
                WHERE        (IdTipoPessoa = @IdTipoPessoa)
            ", new
            {
                IdTipoPessoa = idTipoPessoa
            }).ConfigureAwait(false);
            return _mapper.Map<TipoPessoa>(result);
        }
    }
}
