﻿using System.Text;
using BookingPlatform.Application.Security;
using BookingPlatform.Infrastructure.DAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace BookingPlatform.Infrastructure.Auth;

internal static class Extensions
{
    private const string OptionsSectionName = "auth";
    
    public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
    {
        var options = configuration.GetOptions<AuthOptions>(OptionsSectionName);

        services
            .Configure<AuthOptions>(configuration.GetRequiredSection(OptionsSectionName))
            .AddSingleton<IAuthenticator, Authenticator>()
            .AddSingleton<ITokenStorage, HttpContextTokenStorage>()
            .AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                o.Audience = options.Audience;
                o.IncludeErrorDetails = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = options.Issuer,
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.SigningKey))
                };
            });

        services.AddAuthorization(authorization =>
        {
            authorization.AddPolicy("is-admin", policy =>
            {
                policy.RequireRole("admin");
            });
        });

        return services;
    }
}