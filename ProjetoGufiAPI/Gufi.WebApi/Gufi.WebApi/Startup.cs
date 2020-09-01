using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace Gufi.WebApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
services.AddControllers()
                .AddNewtonsoftJson(x =>
                {
                    x.SerializerSettings.ReferenceLoopHandling
                       = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    x.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                })

               // Define a vers�o do .NET Core
               .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);

            services
                // Define a forma de autentica��o
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = "JwtBearer";
                    options.DefaultChallengeScheme = "JwtBearer";
                })

                // Define os par�metros de valida��o do token
                .AddJwtBearer("JwtBearer", options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {

                        ValidateIssuer = true,


                        ValidateAudience = true,


                        ValidateLifetime = true,


                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Gufi-chave-autenticacao")),


                        ClockSkew = TimeSpan.FromMinutes(30),


                        ValidIssuer = "Gufi.WebApi",


                        ValidAudience = "Gufi.WebApi"
                    };
                });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
