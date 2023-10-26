using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSchema.Infrastructure.Data.DTO
{
    public class UserProfileDTO
    {
        public int IdUsuarioPerfil { get; set; }
        public int IdPerfil { get; set; }
        public int IdUsuario { get; set; }
        public int DataCriacao { get; set; }
        public int UsuarioCriacao { get; set; }
    }
}
