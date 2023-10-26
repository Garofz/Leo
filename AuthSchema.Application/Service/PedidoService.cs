using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSchema.Application.Service
{
    public class PedidoService : IPedidoService
    {
        string URL = "https://167.114.160.121:41002";
        public PedidoService()
        {
            
        }

        public Task<IDetalheRotaResponse> ImportarPlanilhaPedidos(File file, string token)
        {
            throw new NotImplementedException();
        }

        public Task<IDetalheRotaResponse> ObterDetalheRota(IDetalheRotaRequest model, string token)
        {
            throw new NotImplementedException();
        }

        public Task<IConsultaEnderecoPedidoResponse> ObterEnderecoPedidos(string dataFim, string dataInicio, string token)
        {
            throw new NotImplementedException();
        }

        public Task<IConsultaPedidoResponse> ObterPedidos(DateTime dataInicio, DateTime dataFim, string token)
        {
            throw new NotImplementedException();
        }
    }
}
