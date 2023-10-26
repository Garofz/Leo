using AuthSchema.Application.Model.Request;
using AuthSchema.Application.Model.Response;
using AuthSchema.Application.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace AuthSchema.WebApi.Controllers
{

    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v1/roteirizador/Veiculo")]
    public class VeiculoController : Controller
    {
        private IVeiculoService _service;
        public VeiculoController(IVeiculoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IConsultaVeiculoResponse> ObterVeiculos()
        {
            string authorizationHeaderValue = HttpContext.Request.Headers["Authorization"].ToString();
            return await _service.ObterVeiculos(authorizationHeaderValue)
                    .ConfigureAwait(false);
        }

        [HttpGet]
        [Route("{placa:string}")]
        public async Task<IConsultaVeiculoResponse> ObterVeiculoPorId(string id)
        {
            string authorizationHeaderValue = HttpContext.Request.Headers["Authorization"].ToString();
            return await _service.ObterVeiculoPorId(id, authorizationHeaderValue)
                .ConfigureAwait(false);
        }

        [HttpPost]
        public async Task<IVeiculoResponse> CadastrarVeiculo([FromBody] ICadastraVeiculoRequest model)
        {
            string authorizationHeaderValue = HttpContext.Request.Headers["Authorization"].ToString();
            return await _service.CadastrarVeiculo(model, authorizationHeaderValue)
                .ConfigureAwait(false);
        }

        [HttpPut]
        public async Task<IVeiculoResponse> EditarVeiculo([FromBody] IEditaVeiculoRequest model)
        {
            string authorizationHeaderValue = HttpContext.Request.Headers["Authorization"].ToString();
            return await _service.EditarVeiculo(model, authorizationHeaderValue)
                .ConfigureAwait(false);
        }

        [HttpDelete]
        [Route("{placa:string}")]
        public async Task<IVeiculoResponse> InativarVeiculo(string placa, [FromQuery] int IdUsuario)
        {
            string authorizationHeaderValue = HttpContext.Request.Headers["Authorization"].ToString();
            return await _service.InativarVeiculo(placa, IdUsuario, authorizationHeaderValue)
                .ConfigureAwait(false);
        }

        [HttpPost]
        [Route("{ativar:string}")]
        public async Task<IVeiculoResponse> AtivarVeiculo([FromBody] IAtivaVeiculoRequest model)
        {
            string authorizationHeaderValue = HttpContext.Request.Headers["Authorization"].ToString();
            return await _service.AtivarVeiculo(model, authorizationHeaderValue)  
                .ConfigureAwait(false);
        }
    }
}
