using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
<<<<<<< HEAD
=======
using dotnetapp.Core.Interface;
using dotnetapp.Core;
>>>>>>> Ecommerce-HariniVenkat07
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
using System.Text;
=======
>>>>>>> Ecommerce-HariniVenkat07
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using dotnetapp.Models;
<<<<<<< HEAD
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using dotnetapp.Core;
using dotnetapp.Context;
=======
using dotnetapp.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
>>>>>>> Ecommerce-HariniVenkat07

namespace dotnetapp
{
    public class Startup
    {
        string mypolicy = "mypolicy";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("myconnstring");
<<<<<<< HEAD
            services.AddEndpointsApiExplorer();
            services.AddDbContext<LensContext>(opt => opt.UseSqlServer(connectionString));
            services.AddScoped<SignUpCore>();
            services.AddCors(o => o.AddPolicy(name: mypolicy, bui => { bui.AllowAnyHeader(); bui.AllowAnyOrigin(); bui.AllowAnyMethod(); })) ;
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = Configuration["Jwt:Issuer"],
        ValidAudience = Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["Jwt:Key"]))
    };
});
=======
            services.AddDbContext<LensContext>(opt => opt.UseSqlServer(connectionString));
            services.AddScoped<ICart, CartCore>();
            services.AddCors(o => o.AddPolicy(name: mypolicy, bui => { bui.AllowAnyHeader(); bui.AllowAnyOrigin(); bui.AllowAnyMethod(); }));
>>>>>>> Ecommerce-HariniVenkat07

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "dotnetapp", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "dotnetapp v1"));
            }
<<<<<<< HEAD

            app.UseHttpsRedirection();
            app.UseCors(mypolicy);

            app.UseRouting();
            app.UseAuthentication();

            
=======
            app.UseCors(mypolicy);
            app.UseHttpsRedirection();

            app.UseRouting();

>>>>>>> Ecommerce-HariniVenkat07
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
