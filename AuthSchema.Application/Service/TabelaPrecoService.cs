

using System.Threading.Tasks;
using System;
using AuthSchema.Application.Model.Response;
using AuthSchema.Application.Model.Request;

namespace AuthSchema.Application.Service
{
    public class TabelaPrecoService : ITabelaPrecoService
    {
        string URL = "https://167.114.160.121:41002";

        public TabelaPrecoService()
        {

        }

        public Task<IConsultaTabelaPrecoResponse> ObterTabelaPrecos(string authorizationHeaderValue)
        {
            throw new NotImplementedException();
        }

        public Task<IConsultaTabelaPrecoResponse> ObterTabelaPrecoPorId(int id, string authorizationHeaderValue)
        {
            throw new NotImplementedException();
        }

        public Task<ITabelaPrecoResponse> CadastrarTabelaPreco(ICadastraTabelaPrecoRequest model , string authorizationHeaderValue)
        {
            throw new NotImplementedException();

        }

        public Task<ITabelaPrecoResponse> EditarTabelaPreco(IEditaTabelaPrecoRequest model, string authorizationHeaderValue)
        {
            throw new NotImplementedException();
        }

        public Task<ITabelaPrecoResponse> InativarTabelaPreco(int id, object idusUsuario, string authorizationHeaderValue)
        {
            throw new NotImplementedException();
        }

        public Task<ITabelaPrecoResponse> AtivarTabelaPreco(IAtivaTabelaPrecoRequest model, string authorizationHeaderValue)
        {
            throw new NotImplementedException();
        }

    }
}
