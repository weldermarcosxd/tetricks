using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Tetricks.Crud.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AdicionarAutenticacaoEAutorizacao(this IServiceCollection services, IConfiguration configuration)
    {
        var urlBaseDoKeycloak = configuration.ObterUrlBaseDoKeycloak();
        var realm = configuration.ObterRealm();
        services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.MetadataAddress = $"{urlBaseDoKeycloak}/realms/{realm}/.well-known/openid-configuration";
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    RoleClaimType = "groups",
                    NameClaimType = "preferred_username",
                    ValidAudience = "account",
                    ValidateIssuer = true
                };
            });

        services.AddAuthorization(o =>
        {
            o.DefaultPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
        });
    }

    public static void AdicionarSwaggerComAutenticacao(this IServiceCollection services, IConfiguration configuration)
    {
        var urlBaseDoKeycloak = configuration.ObterUrlBaseDoKeycloak();
        var realm = configuration.ObterRealm();
        services.AddSwaggerGen(options =>
        {
            var securityScheme = new OpenApiSecurityScheme
            {
                Name = "JWT Authentication",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                Reference = new OpenApiReference
                {
                    Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme
                }
            };

            options.AddSecurityDefinition(
                "Bearer",
                new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        Implicit = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri(
                                $"{urlBaseDoKeycloak}/realms/{realm}/protocol/openid-connect/auth"
                            )
                        }
                    }
                }
            );

            options.AddSecurityRequirement(
                new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" },
                        },
                        new List<string>()
                    }
                }
            );
        });
    }
}
