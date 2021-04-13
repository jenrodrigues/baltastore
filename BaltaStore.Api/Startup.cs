using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Infra.StoreContext.Repositories;
using BaltaStore.Domain.StoreContext.Services;
using BaltaStore.Infra.StoreContext.Services;
using BaltaStore.Infra.DataContexts;
using BaltaStore.Domain.StoreContext.Handlers;
using Microsoft.OpenApi.Models;
using Elmah.Io.AspNetCore;
using Microsoft.Extensions.Configuration;
using BaltaStore.Shared;

namespace BaltaStore.Api
{
    public class Startup
    {
        public static IConfiguration Configuration{get;set;}

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            //Metodos pra adicionar servicos a aplicacao
            //Autorizacao
            //Autenticacao
            
            services.AddApplicationInsightsTelemetry(Configuration);
            
            //MVC
            services.AddMvc();
            services.AddResponseCompression();
            services.AddScoped<BaltaDataContext, BaltaDataContext>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<CustomerHandler, CustomerHandler>();
            services.AddSwaggerGen(x=>
            {
                x.SwaggerDoc("v1", new OpenApiInfo{Title = "Balta Store", Version="v1"});
            });

            //Log
            services.AddElmahIo(o =>
            {
                o.ApiKey = "fb8079548a73482183b0cd6e6eb9aaa8";
                o.LogId = new Guid("2a7cf256-358a-48d6-8065-242553d6308e");
            });

            Settings.ConnectionString = $"{Configuration["connectionString"]}";
            //Etc
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Administrando variaveis de ambiente internas do .NET em diferentes ambientes
            //Development, Production, Staging, etc
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseResponseCompression();
            app.UseSwagger();//Documentacao da API gerada pelo Swagger na versao JSON
            app.UseSwaggerUI(c=>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BaltaStore - v1");
            });//Adicionando versao amigavel da UI (HTML/CSS/JS) da documentacao Swagger

            app.UseElmahIo();
        }
    }
}
