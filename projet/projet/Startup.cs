using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace projet
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           
            // Configuration Token

            const string sec = "401abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";
        
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(jwtBearerOptions =>
             {
              jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()
                  {
                    
                    ValidateActor = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "instalite.fr",
                    ValidAudience = "instalite.fr",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(sec))
                   };
                });
            // 

            services.AddTransient<Profile.DataAccess>();

            // Test1
           //services.AddCors(); // pour CORS
            //services.AddMvc();
            // Ajoute la configuration de cors à tous les controlleurs
           // services.Configure<MvcOptions>(options =>
          //  {
          //      options.Filters.Add(new CorsAuthorizationFilterFactory("AllowSpecificOrigin"));
         //   });

            // Test2
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("http://localhost:8080")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
            services.AddMvc();
            services.Configure<MvcOptions>(options =>
            {
                options.Filters.Add(new CorsAuthorizationFilterFactory("AllowSpecificOrigin"));
            });

            //

           



           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Token
            app.UseAuthentication();
           
            // CORS
            // Test 1
            // .AllowAnyOrigin()
            /*
            app.UseCors(builder =>
                        builder.WithOrigins("http://localhost:8080")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                        );
            */

            // Test 2
            app.UseCors("AllowSpecificOrigin");

            app.UseMvc();

        }
    }
}
