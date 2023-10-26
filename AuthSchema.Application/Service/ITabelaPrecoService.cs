using AuthSchema.Application.Model.Request;
using AuthSchema.Application.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSchema.Application.Service
{
    public interface ITabelaPrecoService
    {
        Task<IConsultaTabelaPrecoResponse> ObterTabelaPrecos(string token);
        Task<IConsultaTabelaPrecoResponse> ObterTabelaPrecoPorId(int id, string token);
        Task<ITabelaPrecoResponse> CadastrarTabelaPreco(ICadastraTabelaPrecoRequest model, string token);
        Task<ITabelaPrecoResponse> EditarTabelaPreco(IEditaTabelaPrecoRequest model, string token);
        Task<ITabelaPrecoResponse> InativarTabelaPreco(int id, int IdUsuario, string token);
        Task<ITabelaPrecoResponse> AtivarTabelaPreco (IAtivaTabelaPrecoRequest model, string token);
    }
}
