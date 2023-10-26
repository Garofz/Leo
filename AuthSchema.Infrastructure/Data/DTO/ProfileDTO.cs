using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSchema.Infrastructure.Data.DTO
{
    public class ProfileDTO
    {
        public int IdPerfil { get; set; }
        public string Descricao { get; set; }
        public string Sigla { get; set; }
        public int Idproduto { get; set; }
    }
}
