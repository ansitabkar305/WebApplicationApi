using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File(
               path: "E:\\AbkarWorks\\AbK Notes\\Learing\\5 ASP.NET Core 5 Web API\\5 ASP.NET Core 5 Web API\\3. Project Setup and Configurations\\logs\\log-.txt",
              outputTemplate: "{TimeStamp:yyyy-mm-dd HH:MM:SS.fff zzz}[{Level:u3}]{message:lj}{New Line}{Exception}",
              rollingInterval:RollingInterval.Day,
              restrictedToMinimumLevel:LogEventLevel.Information).CreateLogger();
            //  try
            //{
            //    Log.Information("Application Is Starting");
            //    CreateHostBuilder(args).Build().Run();
            //}
            //catch (Exception ex)
            //{
            //    Log.Fatal(ex, "Application Failed To Start");
            //}
            //finally
            //{
            //    Log.CloseAndFlush();
            //}
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).UseSerilog().ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
