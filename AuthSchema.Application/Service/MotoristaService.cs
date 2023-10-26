using AuthSchema.Application.Model.Request;
using AuthSchema.Application.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSchema.Application.Service
{
    public class MotoristaService: IMotoristaService
    {
        string URL = "https://167.114.160.121:41002";
        public MotoristaService()
        {

        }

        public Task<IConsultaVeiculoMotoristaResponse> AlterarVeiculoPadraoMotorista(ICadastraVeiculoMotoristaRequest model, string token)
        {
            throw new NotImplementedException();
        }

        public Task<IMotoristaResponse> AtivarMotorista(IAtivaMotoristaRequest model, string token)
        {
            throw new NotImplementedException();
        }

        public Task<IConsultaVeiculoMotoristaResponse> AtribuirVeiculoMotorista(ICadastraVeiculoMotoristaRequest model, string token)
        {
            throw new NotImplementedException();
        }

        public Task<IMotoristaResponse> CadastrarMotorista(ICadastraMotoristaRequest model, string token)
        {
            throw new NotImplementedException();
        }

        public Task<IConsultaVeiculoMotoristaResponse> DeletarVeiculoMotorista(int idMotorista, int idVeiculo, string token)
        {
            throw new NotImplementedException();
        }

        public Task<IMotoristaResponse> EditarMotorista(IEditaMotoristaRequest model, string token)
        {
            throw new NotImplementedException();
        }

        public Task<IMotoristaResponse> InativarMotorista(int idUsuario, string token)
        {
            throw new NotImplementedException();
        }

        public Task<IConsultaMotoristaResponse> ObterMotoristaPorId(string token)
        {
            throw new NotImplementedException();
        }

        public Task<IConsultaMotoristaResponse> ObterMotoristas(string token)
        {
            throw new NotImplementedException();
        }

        public Task<IConsultaVeiculoMotoristaResponse> ObterVeiculosMotorista(int id, string token)
        {
            throw new NotImplementedException();
        }
    }

}
