using AuthSchema.Application.Model.Request;
using AuthSchema.Application.Model.Response;
using AuthSchema.Application.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AuthSchema.WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v1/authschema")]
    public class AuthschemaController : Controller
    {
        private IAuthSchemaService _authSchemaService;
        public AuthschemaController(IAuthSchemaService authSchemaService)
        {
            _authSchemaService = authSchemaService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ILoginUsuarioResponse> LoginUsuario([FromBody] LoginUsuarioRequest model)
        {
            string authorizationHeaderValue = HttpContext.Request.Headers["Authorization"].ToString();

            return await _authSchemaService.LoginUsuario(model, authorizationHeaderValue)
                .ConfigureAwait(false);
        }

        [HttpPost]
        [Route("usuario/novaSenha")]
        public async Task<IUserResponse> NovaSenhaUsuario([FromBody] NewUserPasswordRequest model)
        {
            string authorizationHeaderValue = HttpContext.Request.Headers["Authorization"].ToString();

            return await _authSchemaService.NovaSenhaUsuario(model, authorizationHeaderValue)
                .ConfigureAwait(false);
        }
    }
}
