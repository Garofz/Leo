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
    public class AccessKeyRepository : IAccessKeyRepository
    {
        private readonly IUnitOfWork<IDapperContext> _unitOfWork;
        private readonly IMapper _mapper;
        public AccessKeyRepository(IUnitOfWork<IDapperContext> unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<AccessKey> GetAccessKeyAsync(int userId, int productId, bool onlyActive = true)
        {
            try
            {
                var result = await _unitOfWork.Context.GetOpenConnection().QueryAsync<AccessKeyDTO>($@"
                    SELECT IdAccessKey,
                        AccessKeyName, 
                        AccessKey, 
                        Active, 
                        Blocked, 
                        CreationDate, 
                        UpdatedDate, 
                        ProductId, 
                        UserId
                    FROM TBSM_AccessKey
                        WHERE ProductId = @ProductId 
                        AND @UserId = UserId 
                        {(onlyActive? "AND Active = 1" :"")}
                ",
                new
                {
                    UserId = userId,
                    ProductId = productId
                }).ConfigureAwait(false);

                return _mapper.Map<AccessKey>(result.First());
            }
            catch (Exception e)
            {
                return null; 
            }
        }

        public async Task<AccessKey> AddAccessKeyAsync(AccessKey accessKey)
        {
            try
            {
                var result = await _unitOfWork.Context.GetOpenConnection().QueryAsync<AccessKeyDTO>(@"
                    INSERT INTO TBSM_AccessKey(AccessKeyName, AccessKey, Active, Blocked, CreationDate, UpdatedDate, ProductId, UserId)
                    OUTPUT inserted.*
                    VALUES(@AccessKeyName, @AccessKey, @Active, @Blocked, @CreationDate, @UpdatedDate, @ProductId, @UserId)
                ",
                new
                {
                    AccessKeyName = accessKey.AccessKeyName,
                    AccessKey = accessKey.AccessKeyAttr,
                    Active = accessKey.Active,
                    Blocked = accessKey.Blocked,
                    CreationDate = accessKey.CreationDate,
                    UpdatedDate = accessKey.UpdatedDate ,
                    ProductId = accessKey.ProductId ,
                    UserId = accessKey.UserID
                }).ConfigureAwait(false);

                return _mapper.Map<AccessKey>(result.First());
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> UpdateAccessKeyAsync(AccessKey accessKey)
        {
            try
            {
                var result = await _unitOfWork.Context.GetOpenConnection().ExecuteAsync(@"
                    UPDATE TBSM_AccessKey SET 
                    AccessKeyName = @AccessKeyName, 
                    AccessKey = @AccessKey, 
                    Active = @Active, 
                    Blocked = @Blocked, 
                    UpdatedDate = @UpdatedDate, 
                    ProductId = @ProductId, 
                    UserId = @UserId
                    WHERE IdAccessKey = @IdAccessKey
                ",
                new
                {
                    IdAccessKey = accessKey.IdAccessKey,
                    AccessKeyName = accessKey.AccessKeyName,
                    AccessKey = accessKey.AccessKeyAttr,
                    Active = accessKey.Active,
                    Blocked = accessKey.Blocked,
                    UpdatedDate = accessKey.UpdatedDate,
                    ProductId = accessKey.ProductId,
                    UserId = accessKey.UserID
                }).ConfigureAwait(false);

                return result > 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
