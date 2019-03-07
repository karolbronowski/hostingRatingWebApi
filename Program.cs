using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace hostingRatingWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

       public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseKestrel((opt)=>
            {
                opt.Listen(IPAddress.IPv6Any,5000);
            })
            .UseIISIntegration()
            .ConfigureAppConfiguration((hostContext, config) =>
            {
                    config.Sources.Clear();
                    config.AddJsonFile("appsettings.json", optional: true);
            })
            .UseStartup<Startup>()
            .UseApplicationInsights()
            .Build();  

    }
}
