using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthSchema.Application.Model.Response
{
    public class BadRequestErrorResponse
    {
        public BadRequestErrorResponse()
        {

        }

        public ErrorResponse Error { get; set; }
        public ControleResponse Controle { get; set; }
    }
}
