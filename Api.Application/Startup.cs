using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.CrossCutting.DependencyInjection;
using Api.CrossCutting.Mappings;
using Api.Data.Context;
using Api.Domain.Security;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace application
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            _environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment _environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           if(_environment.IsEnvironment("Testing"))
           {
              
               Environment.SetEnvironmentVariable("DB_CONNECTION", "Persist Security Info=True;Server=localhost;Port=3306;Database=dpAPI_Integration;Uid=root;Pwd=sandro777");
               Environment.SetEnvironmentVariable("DATABASE", "MYSQL");
               Environment.SetEnvironmentVariable("MIGRATION", "APLICAR");
               Environment.SetEnvironmentVariable("Audience", "ExemploAudience");
               Environment.SetEnvironmentVariable("Issuer", "ExemploIssuer");
               Environment.SetEnvironmentVariable("Seconds", "10800");
           }

            ConfigureService.ConfigureDependenciesService(services);
            ConfigureRepository.ConfigureDependenciesRepository(services);

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DtoToModelProfile());
                cfg.AddProfile(new EntityToDtoProfile());
                cfg.AddProfile(new ModelToEntityProfile());
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);

            //var tokenConfigurations = new TokenConfigurations();
            //new ConfigureFromConfigurationOptions<TokenConfigurations>(
              //  Configuration.GetSection("TokenConfigurations"))
                //    .Configure(tokenConfigurations);
                //services.AddSingleton(tokenConfigurations);

                services.AddAuthentication(authOptions =>
                
                {
                    authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                }).AddJwtBearer(bearerOptions =>
                {
                    var paramsValidation = bearerOptions.TokenValidationParameters;
                    paramsValidation.IssuerSigningKey = signingConfigurations.Key;
                    paramsValidation.ValidAudience = Environment.GetEnvironmentVariable("Audience");
                    paramsValidation.ValidIssuer = Environment.GetEnvironmentVariable("Issuer");
                    paramsValidation.ValidateIssuerSigningKey = true;
                    //paramsValidation.ValidateLifeTime = true;
                    paramsValidation.ClockSkew = TimeSpan.Zero;

                });

                services.AddAuthorization(auth =>
                {
                    auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                                    .RequireAuthenticatedUser().Build());
                });


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Title = "Curso de API com .NETCore3.1/.NET5.0 na prática", 
                    Version = "v1",
                    Description = "Arquitetura DDD",
                    TermsOfService = new Uri("http://www.mfrinfo.com.br"),
                    Contact = new OpenApiContact
                    {
                        Name = "Sandro Souza",
                        Email = "mfrinfo.com.br",
                        Url = new Uri("http://mfrinfo.com.br")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Termo de licensa de uso",
                        Url = new Uri("http://www.mfrinfo.com.br")
                    }
                
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Entre com o Token Jwt",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement{
                    {
                        new OpenApiSecurityScheme{
                            Reference = new OpenApiReference {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        }, new List<string>()
                    }
                });

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => {c.SwaggerEndpoint("/swagger/v1/swagger.json", "Curso de API com .NETCore3.1/.NET5.0 na prática");
            c.RoutePrefix = string.Empty;
            
            });
        

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            if(Environment.GetEnvironmentVariable("MIGRATION").ToLower() == "APLICAR".ToLower())
            {
                using (var service = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                                                            .CreateScope())

                {
                    using (var context = service.ServiceProvider.GetService<MyContext>())
                    {
                        context.Database.Migrate();
                    }
                }
            }
        }
    }
}
