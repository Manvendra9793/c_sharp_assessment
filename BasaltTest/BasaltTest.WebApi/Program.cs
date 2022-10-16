using BasaltTest.Application;
using BasaltTest.Persitence;
using Microsoft.Extensions.Configuration;

namespace BasaltTest.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var startup = new Startup(builder.Configuration);
            startup.ConfigureServices(builder.Services);

            var app = builder.Build();
            startup.Configure(app, builder.Environment);
        }
    }
}