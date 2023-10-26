using AuthSchema.Application.Model.Request;
using AuthSchema.Application.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSchema.Application.Service
{
    public class TipoVeiculoService : ITipoVeiculoService
    {
        string URL = "https://167.114.160.121:41002";
        public TipoVeiculoService()
        {

        }
        public Task<IConsultaTipoVeiculoResponse> ObterTipoVeiculos(string token)
        {
            throw new NotImplementedException();
        }

        public Task<IConsultaTipoVeiculoResponse> ObterTipoVeiculoPorId(int id, string token)
        {
            throw new NotImplementedException();
        }

        public Task<ITipoVeiculoResponse> CadastrarTipoVeiculo(ICadastraTipoVeiculoRequest model, string authorizationHeaderValue)
        {
            throw new NotImplementedException();
        }

        public Task<ITipoVeiculoResponse> EditarTipoVeiculo(IEditaTipoVeiculoRequest model, string authorizationHeaderValue)
        {
            throw new NotImplementedException();
        }

        public Task<ITipoVeiculoResponse> InativarTipoVeiculo(int id, int IdUSuario, string token)
        {
            throw new NotImplementedException();
        }
 
        public Task<ITipoVeiculoResponse> AtivarTipoVeiculo(IAtivaTipoVeiculoRequest model, string authorizationHeaderValue)
        {
            throw new NotImplementedException();
        }
        

    }
}
