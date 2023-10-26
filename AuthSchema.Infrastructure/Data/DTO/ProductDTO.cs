using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSchema.Infrastructure.Data.DTO
{
    public class ProductDTO
    {
        public int IdProduto { get; set; }
        public string Descricao { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
    }
}
