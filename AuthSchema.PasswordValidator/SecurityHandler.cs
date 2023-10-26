using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AuthSchema.PasswordValidator
{
    public class SecurityHandler
    {
        public static bool VerificarSenha(string senhaFornecida, string hashSenhaArmazenado)
        {
            return BCrypt.Net.BCrypt.Verify(senhaFornecida, hashSenhaArmazenado);
        }

        public static string EncryptPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
