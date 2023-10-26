using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSchema.Infrastructure.Data.DTO
{
    public class UserDTO
    {
        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string EmailUsuario { get; set; }
    }
}
