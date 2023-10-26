using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSchema.Infrastructure.Data.DTO.CardapioVirtual
{
    public class ClienteDTO
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Inscricao { get; set; }
        public int IdTipoPessoa { get; set; }
        public bool Ativo { get; set; }
        public string Logo { get; set; }
        public int UsuarioInclusao { get; set; }
        public DateTime DataInclusao { get; set; }
        public int UsuarioAlteracao { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}
