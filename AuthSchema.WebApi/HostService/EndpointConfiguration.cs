namespace AuthSchema.WebApi.HostService
{
    public class EndpointConfiguration
    {
        public string Host { get; set; }
        public int? Port { get; set; }
        public string Scheme { get; set; }
        public bool Enabled{ get; set; }
    }
}
