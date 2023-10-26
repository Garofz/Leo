using AuthSchema.Domain.Model;
using AuthSchema.Domain.Repository;
using AuthSchema.Domain.UOW;
using AuthSchema.Infrastructure.Data.Context;
using AuthSchema.Infrastructure.Data.DTO;
using AutoMapper;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSchema.Infrastructure.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IUnitOfWork<IDapperContext> _unitOfWork;
        private readonly IMapper _mapper;
        public UserRepository(IUnitOfWork<IDapperContext> unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<User> AddUserAsync(User user)
        {
            try
            {
                var result = await _unitOfWork.Context.GetOpenConnection().QueryAsync<UserDTO>(@"
                    INSERT INTO TBSM_Usuario(NomeUsuario, EmailUsuario)
                    OUTPUT inserted.*
                    VALUES(@NomeUsuario, @EmailUsuario)
                ", 
                new { 
                    NomeUsuario = user.Name,
                    EmailUsuario = user.Email
                }).ConfigureAwait(false);

                return _mapper.Map<User>(result.First());
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<User> GetUserByKeyAsync(string key)
        {
            try
            {
                
                var result = await _unitOfWork.Context.GetOpenConnection().QueryFirstAsync<UserDTO>(@"
                    SELECT IdUsuario, 
                            NomeUsuario, 
                            EmailUsuario 
                    FROM TBSM_Usuario
                    WHERE EmailUsuario = @EmailUsuario
                ",
                new
                {
                    EmailUsuario = key
                }, transaction: _unitOfWork.Transaction).ConfigureAwait(false);

                return _mapper.Map<User>(result);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<User> GetUserByNameAndEmailAsync(string name, string email)
        {
            try
            {
                var result = await _unitOfWork.Context.GetOpenConnection().QueryAsync<UserDTO>(@"
                    SELECT IdUsuario, 
                            NomeUsuario, 
                            EmailUsuario 
                    FROM TBSM_Usuario
                    WHERE NomeUsuario = @NomeUsuario AND EmailUsuario = @EmailUsuario
                ",
                new
                {
                    NomeUsuario = name,
                    EmailUsuario = email
                }, transaction: _unitOfWork.Transaction).ConfigureAwait(false);

                return result.Any() ? _mapper.Map<User>(result.First()) : null;
                
            }catch(Exception ex)
            {
                return null;
            }
        }
        public async Task<User> GetUserByIdAsync(int userId)
        {
            try
            {
                var result = await _unitOfWork.Context.GetOpenConnection().QueryAsync<UserDTO>(@"
                    SELECT IdUsuario, 
                            NomeUsuario, 
                            EmailUsuario 
                    FROM TBSM_Usuario
                    WHERE IdUsuario = @IdUsuario
                ",
                new
                {
                    IdUsuario = userId
                }, transaction: _unitOfWork.Transaction).ConfigureAwait(false);

                return result.Any() ? _mapper.Map<User>(result.First()) : null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Domain.Model.Profile>> GetUserProfilesAsync(int userID)
        {
            try
            {
                var result = await _unitOfWork.Context.GetOpenConnection().QueryAsync<ProfileDTO>(@"
                    SELECT P.IdPerfil,
		                P.Descricao,
		                P.Sigla,
		                P.Idproduto
                FROM TBSM_UsuarioPerfil UP
                INNER JOIN TBSM_Perfil P ON UP.IdPerfil = P.IdPerfil
                WHERE IdUsuario = @IdUsuario
                ",
                new
                {
                    IdUsuario = userID
                }, transaction: _unitOfWork.Transaction).ConfigureAwait(false);

                return result.Any() ? _mapper.Map<IEnumerable<Domain.Model.Profile>>(result) : null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
