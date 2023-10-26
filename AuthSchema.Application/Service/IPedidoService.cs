using AuthSchema.Application.Model.Request;
using AuthSchema.Application.Model.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSchema.Application.Service
{
    public interface IPedidoService
    {
        Task<IConsultaPedidoResponse> ObterPedidos(DateTime dataInicio, DateTime dataFim, string token);
        Task<IConsultaEnderecoPedidoResponse> ObterEnderecosVeiculosPedido(string dataFim ,string dataInicio,string token);
        Task<IDetalheRotaResponse> ObterDetalheRota(IDetalheRotaRequest model, string token);

        Task<IDetalheRotaResponse> ImportarPlanilhaPedidos(File file, string token);


    }
}
