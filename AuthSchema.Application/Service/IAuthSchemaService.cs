using AuthSchema.Application.Model.Request;
using AuthSchema.Application.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSchema.Application.Service
{
    public interface IAuthSchemaService
    {
        Task<ILoginUsuarioResponse> LoginUsuario(LoginUsuarioRequest model, string token);
        Task<IUserResponse> NovaSenhaUsuario(NewUserPasswordRequest model, string token);

    }
}
