using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ShopProjectWebAPI.Extensions
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection AddSwaggerSettings(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ShopProjectWebAPI",
                    Description = "API provides work with shop.",
                    Contact = new OpenApiContact
                    {
                        Name = "Bohdan Harabadzhyu",
                        Email = "bohdan.harabadzhyu@yandex.ru",
                        Url = new Uri("https://bohdan-harabadzhyu-homepage.vercel.app"),
                    }
                });

                var securitySchema = new OpenApiSecurityScheme
                {
                    Description = "JWT Auth Bearer Scheme",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };

                c.AddSecurityDefinition("Bearer", securitySchema);
                var securityRequirement = new OpenApiSecurityRequirement{{securitySchema, new[] {"Bearer"}}};
                c.AddSecurityRequirement(securityRequirement);
            });

            return services;
        }
        
    }
}