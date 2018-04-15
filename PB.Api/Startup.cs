﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PB.Core.Repositories;
using PB.Infrastucture.IoC.Modules;
using PB.Infrastucture.Mappers;
using PB.Infrastucture.Repositories;
using PB.Infrastucture.Services;

namespace PB.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterType<MemoryUserRepository>().As<IUserRepository>().SingleInstance();
            builder.RegisterType<MemoryPostRepository>().As<IPostRepository>().SingleInstance();
            builder.RegisterType<MemoryCategoryRepository>().As<ICategoryRepository>().SingleInstance();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterInstance(AutoMapperConfig.Initialize()).SingleInstance();
            builder.RegisterModule<CommandModule>();
            var container = builder.Build();

            return new AutofacServiceProvider(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
