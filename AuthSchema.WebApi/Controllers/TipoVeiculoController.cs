using AuthSchema.Application.Model.Request;
using AuthSchema.Application.Model.Response;
using AuthSchema.Application.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AuthSchema.WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v1/roteirizador/Veiculo/Tipo")]
    public class TipoVeiculoController: Controller
    {
        private ITipoVeiculoService _service;

        TipoVeiculoController (ITipoVeiculoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IConsultaTipoVeiculoResponse> ObterTipoVeiculos()
        {
            string authorizationHeaderValue = HttpContext.Request.Headers["Authorization"].ToString();
            return await _service.ObterTipoVeiculos(authorizationHeaderValue)
                .ConfigureAwait(false);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IConsultaTipoVeiculoResponse> ObterTipoVeiculoPorId(int id)
        {
            string authorizationHeaderValue = HttpContext.Request.Headers["Authorization"].ToString();
            return await _service.ObterTipoVeiculoPorId(id, authorizationHeaderValue)
                .ConfigureAwait(false);
        }

        [HttpPost]
        public async Task<ITipoVeiculoResponse> CadastrarTipoVeiculo([FromBody] ICadastraTipoVeiculoRequest model)
        {
            string authorizationHeaderValue = HttpContext.Request.Headers["Authorization"].ToString();
            return await _service.CadastrarTipoVeiculo(model, authorizationHeaderValue)
                .ConfigureAwait(false);
        }

        [HttpPost]
        public async Task<ITipoVeiculoResponse> EditarTipoVeiculo(IEditaTipoVeiculoRequest model)
        {
            string authorizationHeaderValue = HttpContext.Request.Headers["Authorization"].ToString();
            return await _service.EditarTipoVeiculo(model,authorizationHeaderValue)
                .ConfigureAwait(false);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ITipoVeiculoResponse> InativarTipoVeiculo(int id, [FromQuery] int idUsuario)
        {
            string authorizationHeaderValue = HttpContext.Request.Headers["Authorization"].ToString();
            return await _service.InativarTipoVeiculo(id,idUsuario, authorizationHeaderValue)
                .ConfigureAwait(false);
        }

        [HttpPost]
        [Route("{ativar:string}")]

        public async Task<ITipoVeiculoResponse> AtivarTipoVeiculo([FromBody] IAtivaTipoVeiculoRequest model)
        {
            string authorizationHeaderValue = HttpContext.Request.Headers["Authorization"].ToString();
            return await _service.AtivarTipoVeiculo(model, authorizationHeaderValue)
                .ConfigureAwait(false);
        }
    }
}
