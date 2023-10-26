using AuthSchema.Application.Model.Request;
using AuthSchema.Application.Model.Response;
using AuthSchema.Application.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace AuthSchema.WebApi.Controllers
{

    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v1/roteirizador/Pedido")]
    public class PedidoController : Controller
    {    

    private IPedidoService _service;

        public PedidoController(IPedidoService service) 
        {
            _service = service;
        }

        [HttpGet]
        
        public async Task<IConsultaPedidoResponse> ObterVeiculosPedido([FromQuery] DateTime dataInicio , [FromQuery] DateTime dataFim)
        {
            string authorizationHeaderValue = HttpContext.Request.Headers["Authorization"].ToString();
            return await _service.ObterPedidos(dataInicio, dataFim, authorizationHeaderValue)
                .ConfigureAwait(false);
        }

        [HttpGet]
        [Route("Enderecos")]

        public async Task<IConsultaEnderecoPedidoResponse> ObterEnderecosVeiculosPedido([FromQuery] string dataInicio, [FromQuery] string dataFim)
        {
            string authorizationHeaderValue = HttpContext.Request.Headers["Authorization"].ToString();
            return await _service.ObterEnderecosVeiculosPedido(dataInicio, dataFim, authorizationHeaderValue)
                .ConfigureAwait(false);
        }

        [HttpPost]
        [Route("Rota/Detalhes")]

        public async Task<IDetalheRotaResponse> ObterDetalheRota([FromBody] IDetalheRotaRequest model) 
        {
            string authorizationHeaderValue = HttpContext.Request.Headers["Authorization"].ToString();
            return await _service.ObterDetalheRota(model , authorizationHeaderValue)
                .ConfigureAwait(false);
        }

        //    [HttpPost]
        //    [Route("Planilha/Importar")]

        //    public async Task<IDetalheRotaResponse> ImportarPlanilhaPedidos([FromForm] File file)
        //    {
        //        string authorizationHeaderValue = HttpContext.Request.Headers["Authorization"].ToString();
        //        return await _service.ImportarPlanilhaPedidos(file ,authorizationHeaderValue)
        //           .ConfigureAwait(false);
        //    }

    }
}

