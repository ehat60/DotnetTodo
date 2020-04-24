using System;
using Application;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using WebApi;

namespace Main
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Startup.Start(args, SetupDependecies);
        }

        private static void SetupDependecies(WebHostBuilderContext hostContext, IServiceCollection services)
        {
            services.AddTransient<TodoListService, TodoListService>();
        }
    }
}
