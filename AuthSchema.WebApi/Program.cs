using AuthSchema.WebApi.HostService;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace AuthSchema.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, true)
                .AddEnvironmentVariables()
                .Build();


            var GoUpAsAService = config.GetValue<bool>("GoUpAsAService");

            if (GoUpAsAService)
            {
                var isService = !(Debugger.IsAttached || args.Contains("--console"));

                var pathToContentRoot = Directory.GetCurrentDirectory();

                if (isService)
                {
                    var pathToExe = Process.GetCurrentProcess().MainModule.FileName;

                    pathToContentRoot = Path.GetDirectoryName(pathToExe);
                }

                var build = WebHost.CreateDefaultBuilder(args)
                    .UseContentRoot(pathToContentRoot)
                    .ConfigureAppConfiguration(cfg =>
                    {
                        cfg.SetBasePath(pathToContentRoot);
                        cfg.AddJsonFile("appsettings.json", false, true);
                    })
                    .UseStartup<Startup>()
                    .UseKestrel(opt =>
                    {
                        IConfiguration requiredServices = opt.ApplicationServices.GetRequiredService<IConfiguration>();
                        IHostingEnvironment environment = opt.ApplicationServices.GetRequiredService<IHostingEnvironment>();

                        foreach (KeyValuePair<string, HostService.EndpointConfiguration> item in from x in requiredServices.GetSection("HttpServer:Endpoints").GetChildren().ToDictionary((IConfigurationSection section) => section.Key, delegate (IConfigurationSection section)
                            {
                                HostService.EndpointConfiguration endpointConfiguration = new HostService.EndpointConfiguration();
                                section.Bind(endpointConfiguration);
                                return endpointConfiguration;
                            })
                                                                                                 where x.Value.Enabled
                                                                                                 select x)
                        {
                            HostService.EndpointConfiguration config = item.Value;
                            int port = config.Port ?? ((config.Scheme == "https") ? 443 : 80);
                            List<IPAddress> list = new List<IPAddress>();
                            IPAddress address;
                            if (config.Host == "localhost" || config.Host == Environment.MachineName)
                            {
                                list.Add(IPAddress.IPv6Loopback);
                                list.Add(IPAddress.Loopback);
                            }
                            else if (IPAddress.TryParse(config.Host, out address))
                            {
                                list.Add(address);
                            }
                            else
                            {
                                list.Add(IPAddress.IPv6Any);
                            }
                            foreach (IPAddress item2 in list)
                            {
                                if(!environment.IsDevelopment())
                                    opt.Listen(item2, port);

                            }
                        };

                    })
                    .Build();
            
                if (isService)
                    build.RunAsACustomService();
                else
                    build.Run();
            }
            else
            {
                BuildWebHost(args).Run();
            }


        }

        public static IWebHost BuildWebHost(string[] args) => 
            WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                var env = hostingContext.HostingEnvironment;
                config.AddCommandLine(args);
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                config.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true);
                config.AddEnvironmentVariables();
            })
            .UseKestrel(_ => _.AddServerHeader = false)
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseIISIntegration()
            .UseStartup<Startup>()
            .Build();
    }
}
