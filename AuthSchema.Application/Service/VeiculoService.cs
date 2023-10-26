using AuthSchema.Application.Model.Request;
using AuthSchema.Application.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSchema.Application.Service
{
    public class VeiculoService : IVeiculoService
    {
        string URL = "https://167.114.160.121:41002";
            
        public VeiculoService()
        {

        }

        public Task<IConsultaVeiculoResponse> ObterVeiculos(string token)
        {
            throw new NotImplementedException();
        }

        public Task<IConsultaVeiculoResponse> ObterVeiculoPorId(string id, string token)
        {
            throw new NotImplementedException();
        }

        public Task<IVeiculoResponse> CadastrarVeiculo(ICadastraVeiculoRequest model, string token)
        {
            throw new NotImplementedException();

        }

        public Task<IVeiculoResponse> EditarVeiculo(IEditaVeiculoRequest model, string token)
        {
            throw new NotImplementedException();
        }

        public Task<IVeiculoResponse> InativarVeiculo(string placa, int idUsuario, string token)
        {
            throw new NotImplementedException();
        }

        public Task<IVeiculoResponse> AtivarVeiculo(IAtivaVeiculoRequest model, string token)
        {
            throw new NotImplementedException();
        }


    }
}
