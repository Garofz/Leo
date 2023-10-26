using System.Collections.Generic;

namespace AuthSchema.Application.Model.Response
{
    public class ILoginUsuarioResponse
    {
        public int _Id { get; set; }
        public int Name { get; set; }
        public int Email { get; set; }
        public int MaskedEmail { get; set; }
        public List<IUserAgent> Agents { get; set; }
        public List<IUserProduct> Products { get; set; }
        public IUserProduct AccessToken { get; set; }
    }

    public class IUserAgent
    {
        public int MyProperty { get; set; }
    }

    public class IUserProduct
    {

    }

    public class IAccessToken
    {

    }
}
