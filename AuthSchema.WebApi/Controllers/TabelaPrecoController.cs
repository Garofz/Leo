using AuthSchema.Application.Model.Request;
using AuthSchema.Application.Model.Response;
using AuthSchema.Application.Service;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;

namespace AuthSchema.WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v1/roteirizador/Tabela/Preco")]
    public class TabelaPrecoController : Controller
    {
        private ITabelaPrecoService _service;
        public TabelaPrecoController(ITabelaPrecoService service)
        {
            _service = service;
        }
        [HttpGet]

        public async Task<IConsultaTabelaPrecoResponse> ObterTabelaPrecos()
        {
            string authorizationHeaderValue = HttpContext.Request.Headers["Authorization"].ToString();
            return await _service.ObterTabelaPrecos(authorizationHeaderValue)
                .ConfigureAwait(false);
        }

        [HttpGet]
        [Route("{id:int}")]

        public async Task<IConsultaTabelaPrecoResponse> ObterTabelaPrecoPorId(int id)
        {
            string authorizationHeaderValue = HttpContext.Request.Headers["Authorization"].ToString();
            return await _service.ObterTabelaPrecoPorId(id, authorizationHeaderValue)
                .ConfigureAwait(false);
        }

        [HttpPost]
        public async Task<ITabelaPrecoResponse> CadastrarTabelaPreco([FromBody] ICadastraTabelaPrecoRequest model)
        {
            string authorizationHeaderValue = HttpContext.Request.Headers["Authorization"].ToString();
            return await _service.CadastrarTabelaPreco(model, authorizationHeaderValue)
                .ConfigureAwait(false);
        }

        [HttpPost]
        public async Task<ITabelaPrecoResponse> EditarTabelaPreco([FromBody] IEditaTabelaPrecoRequest model)
        {
            string authorizationHeaderValue = HttpContext.Request.Headers["Authorization"].ToString();
            return await _service.EditarTabelaPreco(model, authorizationHeaderValue)
                .ConfigureAwait(false);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ITabelaPrecoResponse> InativarTabelaPreco(int id, [FromQuery] int idUsuario)
        {
            string authorizationHeaderValue = HttpContext.Request.Headers["Authorization"].ToString();
            return await _service.InativarTabelaPreco(id, idUsuario, authorizationHeaderValue)
                .ConfigureAwait(false);
        }

        [HttpPost]
        [Route("ativar:string")]

        public async Task<ITabelaPrecoResponse> AtivarTabelaPreco([FromBody] IAtivaTabelaPrecoRequest model)
        {
            string authorizationHeaderValue = HttpContext.Request.Headers["Authorization"].ToString();
            return await _service.AtivarTabelaPreco(model, authorizationHeaderValue)
                .ConfigureAwait(false);
        }


    }
}
