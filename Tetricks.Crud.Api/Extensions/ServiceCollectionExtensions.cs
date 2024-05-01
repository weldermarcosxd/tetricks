using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Tetricks.Crud.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AdicionarAutenticacaoEAutorizacao(this IServiceCollection services, IConfiguration configuration)
    {
        var authority = configuration.ObterUrlAutorityDoKeycloak();
        var clientSecret = configuration.ObterClientSecretDoKeycloak();
        var audiencia = configuration.ObterAudienciaDoKeycloak();

        services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = true;
                options.Audience = audiencia;
                options.Authority = authority;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,

                    ValidIssuer = authority,
                    ValidAudience = audiencia,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = string.IsNullOrEmpty(clientSecret)
                        ? null
                        : new SymmetricSecurityKey(Encoding.UTF8.GetBytes(clientSecret))
                };
            });

        services.AddAuthorization();
    }

    public static void AdicionarSwaggerComAutenticacao(this IServiceCollection services, IConfiguration configuration)
    {
        var authority = configuration.ObterUrlAutorityDoKeycloak();
        services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition(
                "OAuth2",
                new OpenApiSecurityScheme
                {
                    BearerFormat = "JWT",
                    Type = SecuritySchemeType.OAuth2,
                    In = ParameterLocation.Header,
                    Scheme = "Bearer",
                    Flows = new OpenApiOAuthFlows
                    {
                        AuthorizationCode = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri($"{authority}/protocol/openid-connect/auth"),
                            TokenUrl = new Uri($"{authority}/protocol/openid-connect/token"),
                            Scopes = new Dictionary<string, string> { { "profile", "Profile scope description" } },
                        }
                    },
                    Description = "Balea Server OpenId Security Scheme"
                }
            );

            options.AddSecurityRequirement(
                new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "OAuth2" }
                        },
                        Array.Empty<string>()
                    }
                }
            );
        });
    }
}
