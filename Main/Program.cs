﻿using System;
using Application;
using Core;
using DataAccess;
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

        public static void SetupDependecies(WebHostBuilderContext hostContext, IServiceCollection services)
        {
            services.AddTransient<TodoListService, TodoListService>();
            services.AddTransient<ITodoListRepository, InMemoryTodoListRepository>();
        }
    }

}
