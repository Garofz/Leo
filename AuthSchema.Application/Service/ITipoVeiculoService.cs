using AuthSchema.Application.Model.Request;
using AuthSchema.Application.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSchema.Application.Service
{
    public interface ITipoVeiculoService
    {
        Task<IConsultaTipoVeiculoResponse> ObterTipoVeiculos(string token);
        Task<IConsultaTipoVeiculoResponse> ObterTipoVeiculoPorId(int id,string token);
        Task<ITipoVeiculoResponse> CadastrarTipoVeiculo(ICadastraTipoVeiculoRequest model, string authorizationHeaderValue);
        Task<ITipoVeiculoResponse> EditarTipoVeiculo(IEditaTipoVeiculoRequest model, string authorizationHeaderValue);
        Task<ITipoVeiculoResponse> InativarTipoVeiculo(int id, int IdUSuario, string token);
        Task<ITipoVeiculoResponse> AtivarTipoVeiculo(IAtivaTipoVeiculoRequest model, string authorizationHeaderValue);
    }
}
