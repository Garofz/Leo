using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthSchema.Application.Model.Response
{
    public class ErrorResponse
    {
        public string Message { get; protected set; }

        public ErrorResponse(string message)
        {
            Message = message;
        }
    }
}
