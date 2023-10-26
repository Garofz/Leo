using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSchema.Infrastructure.Data.DTO.CardapioVirtual
{
    public class UserClienteDTO
    {
        public int IdUsusarioCliente { get;  set; }
        public int IdUsuario { get;  set; }
        public int IdCliente { get;  set; }
        public bool IndAcessoPrincipal { get;  set; }
        public bool IndPrimeiroAcesso { get;  set; }
        public int IdTipoAcesso { get;  set; }
        public DateTime? DataUltimoAcesso { get;  set; }
        public DateTime? DataInativacaoAcesso { get;  set; }
        public DateTime DataCadastro { get;  set; }
    }
}
