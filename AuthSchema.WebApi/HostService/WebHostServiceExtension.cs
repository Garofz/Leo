using Microsoft.AspNetCore.Hosting;
using System.ServiceProcess;

namespace AuthSchema.WebApi.HostService
{
    public static class WebHostServiceExtension
    {
        public static void RunAsACustomService(this IWebHost host)
        {
            var webHostService = new CustomWebHostService(host);

            ServiceBase.Run(webHostService);
        }
    }
}
