using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SksRezervasyon.Business.MapperProfiles;
using ElmahCore.Mvc;
using ElmahCore;
using SksRezervasyon.Business.Abstract;
using SksRezervasyon.WebAPI.Auth.Abstract;
using SksRezervasyon.Business.Concretes;
using SksRezervasyon.WebAPI.Auth;
using SksRezervasyon.DataAccess.Abstract;
using SksRezervasyon.DataAccess.Concretes;
using SksRezervasyon.Core.Repository;
using SksRezervasyon.Core.Repository.Models;
using SksRezervasyon.DataAccess.Repositories;
using Microsoft.AspNetCore.Http;

namespace SksRezervasyon.WebAPI
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
            services.AddCors(options =>
            options.AddDefaultPolicy(builder =>
            builder.AllowAnyHeader().AllowCredentials().AllowAnyMethod().WithOrigins("http://localhost:3000")));
            services.AddElmah<XmlFileErrorLog>(options =>
            {
                options.LogPath = @"C:\\ELMAH";
            });
            services.AddAuthentication(i =>
            {
                i.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                i.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                i.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                i.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(options =>
           {
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
                   ValidIssuer = Configuration["Jwt:Issuer"],
                   ValidAudience = Configuration["Jwt:Issuer"],
                   ClockSkew = TimeSpan.Zero,
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
               };
               options.SaveToken = true;
               options.Events = new JwtBearerEvents();
               options.Events.OnMessageReceived = context =>
               {

                   if (context.Request.Cookies.ContainsKey("X-Access-Token"))
                   {
                       context.Token = context.Request.Cookies["X-Access-Token"];
                   }

                   return Task.CompletedTask;
               };

           }).AddCookie(options =>
           {
               options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
               options.Cookie.IsEssential = true;
           });
            services.AddControllers();
            services.AddAutoMapper(typeof(OgrenciProfile));

            services.AddDbContext<SksRezervasyonDbContext>();
            services.AddScoped<IRepository<Ogrenci>, EFRepository<Ogrenci>>();
            services.AddScoped<IOgrenciRepository, OgrenciRepository>();
            services.AddScoped<IOgrenciBusiness, OgrenciBusiness>();

            services.AddScoped<IMapper, Mapper>();

            services.AddScoped<IKutuphaneBusiness, KutuphaneBusiness>();
            services.AddScoped<IKutuphaneRepository, KutuphaneRepository>();

            services.AddScoped<IMisafirhaneBusiness, MisafirhaneBusiness>();
            services.AddScoped<IMisafirhaneRepository, MisafirhaneRepository>();

            services.AddScoped<ITesiBusiness, TesiBusiness>();
            services.AddScoped<ITesiRepository, TesiRepository>();

            services.AddScoped<IYemekhaneBusiness, YemekhaneBusiness>();
            services.AddScoped<IYemekhaneRepository, YemekhaneRepository>();

            services.AddScoped<IJWToken, JWToken>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory, IJWToken jWToken)
        {
            loggerFactory.AddLog4Net();
            app.UseAuthentication();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors();
            app.UseAuthorization();

            app.UseElmah();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
