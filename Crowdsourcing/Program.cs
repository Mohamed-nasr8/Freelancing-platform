using Crowdsourcing.BL.Helper;

using Crowdsourcing.BL.Interface;

using Crowdsourcing.BL.Repository;

using Crowdsourcing.DL.Database;
using Crowdsourcing.DL.Entity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TestAPIJWT.Service;

namespace Crowdsourcing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers().AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            //        builder.Services.AddDbContext<CrowdsourcingContext>(options =>
            //options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), sqlServerOptions =>
            //    sqlServerOptions.EnableRetryOnFailure()));
            builder.Services.AddDbContext<CrowdsourcingContext>(opt =>
            opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<CrowdsourcingContext>()
            .AddDefaultTokenProviders();

            //builder.Services.AddScoped<UserManager<Freelancer>>();
            //builder.Services.AddScoped<SignInManager<Freelancer>>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IRepository<Service>, ServiceRepository>();
            builder.Services.AddScoped<IRepository<Freelancer>, FreelancerRepository>();
            builder.Services.AddScoped<IRepository<Language>, LanguageRepository>();
            builder.Services.AddScoped<IRepository<Education>, EducationRepository>();
            builder.Services.AddScoped<FreelancerRepository>();
            builder.Services.AddScoped<IRepository<Expereince>, ExperienceRepository>();
            builder.Services.AddScoped<IRepository<Rating>, RatingRepository>();
            builder.Services.AddScoped<IRepository<FreelancerSkill>, FreelancerSkillRepository>();
            builder.Services.AddScoped<IRepository<FreelancerService>,FreelancerServiceRepository>();
            builder.Services.AddScoped<IRepository<Proposal>, ProposalRepository>();
         
            builder.Services.AddSignalR();

            //builder.Services.AddScoped<IRepository<HasSkill>, HasSkillRepository>();
            builder.Services.AddScoped<UserManager<ApplicationUser>>();
            builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.SaveToken = false;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = builder.Configuration["JWT:Issuer"],
                    ValidAudience = builder.Configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
                };
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseAuthentication();
            app.UseAuthorization();
            

            app.MapControllers();

            app.Run();
        }
    }
}