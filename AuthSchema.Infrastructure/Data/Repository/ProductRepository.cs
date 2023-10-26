using AuthSchema.Domain.Model;
using AuthSchema.Domain.Repository;
using AuthSchema.Domain.UOW;
using AuthSchema.Infrastructure.Data.Context;
using AuthSchema.Infrastructure.Data.DTO;
using AutoMapper;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSchema.Infrastructure.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IUnitOfWork<IDapperContext> _unitOfWork;
        private readonly IMapper _mapper;
        public ProductRepository(IUnitOfWork<IDapperContext> unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Product> GetProductAsync(int idProduto)
        {
            try
            {
                var result = await _unitOfWork.Context.GetOpenConnection().QueryAsync<ProductDTO>(@"
                    SELECT IdProduto,
                        Descricao, 
                        Nome, 
                        Ativo
                    FROM TBSM_Produto
                    WHERE IdProduto = @IdProduto 
                        
                ",
                new
                {
                    IdProduto = idProduto
                }).ConfigureAwait(false);

                return _mapper.Map<Product>(result.First());
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<IEnumerable<Product>> GetProductsAsync(int userId)
        {
            try
            {
                var result = await _unitOfWork.Context.GetOpenConnection().QueryAsync<ProductDTO>(@"
                    SELECT P.IdProduto,
                           P.Descricao, 
                           P.Nome, 
                           P.Ativo
                        FROM TBSM_Produto P
                    INNER JOIN TBSM_AccessKey A ON P.IdProduto = A.ProductId
                    WHERE A.UserId = @UserId 
                        
                ",
                new
                {
                    UserId = userId
                }).ConfigureAwait(false);

                return _mapper.Map<IEnumerable<Product>>(result);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
