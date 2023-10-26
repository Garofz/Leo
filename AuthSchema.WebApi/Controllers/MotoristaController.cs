using AuthSchema.Application.Model.Request;
using AuthSchema.Application.Model.Response;
using AuthSchema.Application.Service;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Writers;
using System.Threading.Tasks;

namespace AuthSchema.WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v1/roteirizador/motorista")]
    public class MotoristaController : Controller
    {
        private IMotoristaService _service;
        public MotoristaController(IMotoristaService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("veiculo/{id:int}")]
        public async Task<IConsultaVeiculoMotoristaResponse> ObterVeiculo([FromRoute] int id)
        {
            string authorizationHeaderValue = HttpContext.Request.Headers["Authorization"].ToString();

            return await _service.ObterVeiculosMotorista(id, authorizationHeaderValue)
                .ConfigureAwait(false);
        }

        [HttpDelete]
        [Route("veiculo")]
        public async Task<IConsultaVeiculoMotoristaResponse> DeletarVeiculoMotorista([FromQuery] int idMotorista, [FromQuery] int idVeiculo)
        {

            string authorizationHeaderValue = HttpContext.Request.Headers["Authorization"].ToString();
            return await _service.DeletarVeiculoMotorista(idMotorista, idVeiculo, authorizationHeaderValue)
                .ConfigureAwait(false);

        }

        [HttpGet]
        [Route("veiculo")]
        public async Task<IConsultaVeiculoMotoristaResponse> AtribuirVeiculoMotorista([FromBody] ICadastraVeiculoMotoristaRequest model)
        {
            string authorizationHeaderValue = HttpContext.Request.Headers["Authorization"].ToString();
            return await _service.AtribuirVeiculoMotorista(model, authorizationHeaderValue)
                .ConfigureAwait(false);
        }

        [HttpPost]
        [Route("veiculo/padrao")]
        public async Task<IConsultaVeiculoMotoristaResponse> AlterarVeiculoPadraoMotorista([FromBody] ICadastraVeiculoMotoristaRequest model)
        {
            string authorizationHeaderValue = HttpContext.Request.Headers["Authorization"].ToString();
            return await _service.AlterarVeiculoPadraoMotorista(model, authorizationHeaderValue)
                .ConfigureAwait(false);
        }

        [HttpGet]
        public async Task<IConsultaMotoristaResponse> ObterMotoristas()
        {
            string authorizationHeaderValue = HttpContext.Request.Headers["Authorization"].ToString();
            return await _service.ObterMotoristas(authorizationHeaderValue)
                .ConfigureAwait(false);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IConsultaMotoristaResponse> ObterMotoristaPorId([FromRoute] int id)
        {
            string authorizationHeaderValue = HttpContext.Request.Headers["Authorization"].ToString();
            return await _service.ObterMotoristaPorId(authorizationHeaderValue)
                .ConfigureAwait(false);
        }

        [HttpPost]
        public async Task<IMotoristaResponse> CadastrarMotorista([FromBody]ICadastraMotoristaRequest model)
        {
            string authorizationHeaderValue = HttpContext.Request.Headers["Authorization"].ToString();
            return await _service.CadastrarMotorista(model , authorizationHeaderValue)
                .ConfigureAwait(false);

        }

        [HttpPut]
        public async Task<IMotoristaResponse> EditarMotorista([FromBody] IEditaMotoristaRequest model)
        {
            string authorizationHeaderValue = HttpContext.Request.Headers["Authorization"].ToString();
            return await _service.EditarMotorista(model , authorizationHeaderValue)
                .ConfigureAwait(false);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IMotoristaResponse> InativarMotorista([FromRoute] int id, [FromQuery] int idUsuario)
        {
            string authorizationHeaderValue = HttpContext.Request.Headers["Authorization"].ToString();
            return await _service.InativarMotorista(idUsuario , authorizationHeaderValue).
                ConfigureAwait(false);  
        }

        [HttpPost]
        [Route("ativar")]
        public async Task<IMotoristaResponse>  AtivarMotorista([FromBody] IAtivaMotoristaRequest model)
        {
            string authorizationHeaderValue = HttpContext.Request.Headers["Authorization"].ToString();
            return await _service.AtivarMotorista(model , authorizationHeaderValue)
                .ConfigureAwait(false);
        }


    }
}