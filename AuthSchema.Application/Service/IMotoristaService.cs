using AuthSchema.Application.Model.Request;
using AuthSchema.Application.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSchema.Application.Service
{
    public interface IMotoristaService
    {
        Task<IConsultaVeiculoMotoristaResponse> ObterVeiculosMotorista(int id, string token);
        Task<IConsultaVeiculoMotoristaResponse> DeletarVeiculoMotorista(int idMotorista, int idVeiculo, string token);

        Task<IConsultaVeiculoMotoristaResponse> AtribuirVeiculoMotorista(ICadastraVeiculoMotoristaRequest model, string token);

        Task<IConsultaVeiculoMotoristaResponse> AlterarVeiculoPadraoMotorista(ICadastraVeiculoMotoristaRequest model, string token);

        Task<IConsultaMotoristaResponse> ObterMotoristas(string token); 

        Task<IConsultaMotoristaResponse> ObterMotoristaPorId(string token);

        Task<IMotoristaResponse> CadastrarMotorista (ICadastraMotoristaRequest model, string token);

        Task<IMotoristaResponse> EditarMotorista(IEditaMotoristaRequest model, string token);

        Task<IMotoristaResponse> InativarMotorista(int idUsuario,  string token);

        Task<IMotoristaResponse> AtivarMotorista(IAtivaMotoristaRequest model, string token);
    }
}
