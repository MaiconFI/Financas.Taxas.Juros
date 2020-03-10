using AutoMapper;
using Financas.Taxas.Juros.Api.Controllers.ApiV1;
using Financas.Taxas.Juros.Data.Context;
using Financas.Taxas.Juros.Domain.Queries.IoC;
using Financas.Taxas.Juros.Queries.Mappers;
using Financas.Taxas.Juros.Queries.TaxasDeJuros;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Financas.Taxas.Juros.Api
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseRouting();
            app.UseMvc()
                .UseApiVersioning();

            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint(
                            $"/swagger/{description.GroupName}/swagger.json",
                            description.GroupName.ToUpperInvariant());
                    }
                });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ITaxaDeJurosContext, TaxaDeJurosContext>(opt => opt.UseInMemoryDatabase(databaseName: "Taxa.Juros"));
            MigrateDatabase(services);

            services
                .AddMvc(m => { m.EnableEndpointRouting = false; })
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddApiVersioning(s =>
            {
                s.DefaultApiVersion = new ApiVersion(1, 0);
                s.ReportApiVersions = true;
                s.AssumeDefaultVersionWhenUnspecified = true;

                s.Conventions.Controller<TaxaDeJurosV1Controller>().HasApiVersion(new ApiVersion(1, 0));
                //s.Conventions.Controller<TaxaDeJurosV2Controller>().HasApiVersion(new ApiVersion(2, 0));
            });

            services.AddVersionedApiExplorer(options => options.GroupNameFormat = "'v'VVV");

            services.AddSwaggerGen(options =>
            {
                var provider = services.BuildServiceProvider()
                               .GetRequiredService<IApiVersionDescriptionProvider>();

                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(
                        description.GroupName,
                        new OpenApiInfo
                        {
                            Title = $"Taxa de Juros API {description.ApiVersion}",
                            Version = description.ApiVersion.ToString(),
                        });
                }
            });

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new TaxaDeJurosQueriesProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            IocDomainRepositories.Register(services);
            services.AddMediatR(typeof(TaxaDeJurosBasicaQueryHandler).GetTypeInfo().Assembly);
        }

        private void MigrateDatabase(IServiceCollection services)
        {
            using var serviceScope = services.BuildServiceProvider().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<ITaxaDeJurosContext>();

            context.Seed();
        }
    }
}