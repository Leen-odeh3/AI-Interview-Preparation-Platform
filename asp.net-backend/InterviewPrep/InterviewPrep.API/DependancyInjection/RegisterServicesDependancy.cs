using InterviewPrep.Core.Entities;
using InterviewPrep.Core.Interfaces;
using InterviewPrep.Core.Services;
using InterviewPrep.Infrastructure.Database;
using InterviewPrep.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace InterviewPrep.API.DependancyInjection;
public static class RegisterServicesDependancy
{
    public static IServiceCollection addDependancy(this IServiceCollection service, IConfiguration config)
    {
        service.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        service.AddDbContext<AppDbContext>(options =>
           options.UseSqlServer(config.GetConnectionString("DefaultConnection"))
       );

        service.AddScoped<ITokenService, TokenService>();
        service.AddScoped<IAuthService, AuthService>();
        service.AddScoped<IInterviewService, InterviewService>();
		service.AddScoped<IInterviewQuestionsService, InterviewQuestionsService>();
		service.AddHttpClient();

		service.AddIdentity<User, IdentityRole>(options =>
        {
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
            options.Lockout.MaxFailedAccessAttempts = 3;
            options.Lockout.AllowedForNewUsers = true;
        }
            )
           .AddEntityFrameworkStores<AppDbContext>()
           .AddDefaultTokenProviders();

        service.Configure<JWT>(config.GetSection("JWT"));
        service.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
                .AddJwtBearer(o =>
                {
                    o.RequireHttpsMetadata = false;
                    o.SaveToken = false;
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = config["JWT:Issuer"],
                        ValidAudience = config["JWT:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Key"]))
                    };
                });
        service.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "InterviewPrep API", Version = "v1" });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                BearerFormat = "JWT",
                Scheme = "Bearer",
                Description = "Enter your JWT token in the format: Bearer {token}"
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
                        new string[] {}
                    }
                });
        });

        service.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        service.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            });
        });


        return service;

    }
}