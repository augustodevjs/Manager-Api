﻿using Microsoft.OpenApi.Models;

namespace Manager.API.Configuration;

public static class SwaggerConfiguration
{
    public static void addSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Manager API",
                Version = "v1",
                Contact = new OpenApiContact
                {
                    Name = "João Augusto",
                    Email = "jaugusto.dev@gmail.com",
                    Url = new Uri("https://github.com/augustodevjs")
                },
            });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Por favor utilize Bearer <TOKEN>",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });
        });
    }
}