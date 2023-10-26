using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSchema.Infrastructure.Data.DTO
{
    public class AccessKeyDTO
    {
        public int IdAccessKey { get; set; }
        public string AccessKeyName { get; set; }
        public string AccessKey { get; set; }
        public bool Active { get; set; }
        public bool Blocked { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int ProductId { get; set; }
        public int UserID { get; set; }
    }
}
