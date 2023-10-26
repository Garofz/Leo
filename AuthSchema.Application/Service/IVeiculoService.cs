using AuthSchema.Application.Model.Request;
using AuthSchema.Application.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSchema.Application.Service
{
    public interface IVeiculoService
    {

        Task<IConsultaVeiculoResponse> ObterVeiculos(string token);
        Task<IConsultaVeiculoResponse> ObterVeiculoPorId(string id, string token);
        Task<IVeiculoResponse> CadastrarVeiculo(ICadastraVeiculoRequest model, string token);
        Task<IVeiculoResponse> EditarVeiculo(IEditaVeiculoRequest model, string token);
        Task<IVeiculoResponse> InativarVeiculo(string placa, int idUsuario, string token);
        Task<IVeiculoResponse> AtivarVeiculo(IAtivaVeiculoRequest model, string token);
    }
}
