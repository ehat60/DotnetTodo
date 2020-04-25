using Main;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;

public class CustomWebApplicationFactory
    : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(Program.SetupDependecies);
    }

    protected override IHostBuilder CreateHostBuilder()
    {
        return WebApi.Startup.CreateWebHostBuilder(null);
    }
}