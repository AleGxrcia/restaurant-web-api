﻿using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using RestaurantApiV2.Infrastructure.Identity.Services;
using RestaurantWebApi.Core.Application.Dtos.Account;
using RestaurantWebApi.Core.Application.Interfaces.Services;
using RestaurantWebApi.Core.Domain.Settings;
using RestaurantWebApi.Infrastructure.Identity.Contexts;
using RestaurantWebApi.Infrastructure.Identity.Entities;

namespace RestaurantWebApi.Infrastructure.Identity
{
    public static class ServiceRegistration
    {
        public static void AddIdentityInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region Contexts
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<IdentityContext>(options => options.UseInMemoryDatabase("IdentityDb"));
            }
            else
            {
                services.AddDbContext<IdentityContext>(options =>
                {
                    options.EnableSensitiveDataLogging();
                    options.UseSqlServer(configuration.GetConnectionString("IdentityConnection"),
                    m => m.MigrationsAssembly(typeof(IdentityContext).Assembly.FullName));
                });
            }
            #endregion

            #region Identity
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();

            services.Configure<JWTSettings>(configuration.GetSection("JWTSettings"));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JWTSettings:Issuer"],
                    ValidAudience = configuration["JWTSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTSettings:Key"]))
                };
                options.Events = new JwtBearerEvents()
                {
                    OnAuthenticationFailed = x =>
                    {
                        x.NoResult();
                        x.Response.StatusCode = 500;
                        x.Response.ContentType = "text/plain";
                        return x.Response.WriteAsync(x.Exception.ToString());
                    },
                    OnChallenge = x =>
                    {
                        x.HandleResponse();
                        x.Response.StatusCode = 401;
                        x.Response.ContentType = "application/json";
                        var result = JsonConvert.SerializeObject(new JwtResponse
                        { HasError = true, Error = "You are not authorized" });
                        return x.Response.WriteAsync(result);
                    },
                    OnForbidden = x =>
                    {
                        x.Response.StatusCode = 403;
                        x.Response.ContentType = "application/json";
                        var result = JsonConvert.SerializeObject(new JwtResponse
                        { HasError = true, Error = "You are not authorized to access this resource" });
                        return x.Response.WriteAsync(result);
                    }

                };

            });
            #endregion

            #region Services
            services.AddTransient<IAccountService, AccountService>();
            #endregion
        }
    }
}
