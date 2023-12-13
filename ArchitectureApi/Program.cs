using System.Security.Cryptography;
using ArchitectureApi.Data;
using ArchitectureApi.Data.Repositories.Abstract;
using ArchitectureApi.Data.Repositories.Concrete;
using ArchitectureApi.Models;
using ArchitectureApi.Services;
using ArchitectureApi.Services.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

internal class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

        builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.Configure<HospitalSettings>(builder.Configuration.GetSection(nameof(HospitalSettings)));

        builder.Services.AddTransient<IDoctorRepository, DoctorRepository>();
        builder.Services.AddTransient<IPatientRepository, PatientRepository>();
        builder.Services.AddTransient<IVisitRepository, VisitRepository>();
        builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

        builder.Services.AddScoped<IVisitService, VisitService>();
        builder.Services.Decorate<IVisitService, VisitLogService>();

        builder.Services.AddScoped<IHospitalService>(HospitalService.Self);

        builder.Services.AddTransient<IPatientService, PatientService>();
        builder.Services.AddTransient<IDoctorService, DoctorService>();


        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", p =>
            {
                p.AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .WithOrigins("http://localhost:3000", "https://appname.azurestaticapps.net");
            });
        });

        builder.Services.AddSingleton(provider =>
        {
            var rsa = RSA.Create();
            return new RsaSecurityKey(rsa);
        });

        builder.Services.AddAuthentication(x =>
            {
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
#pragma warning disable ASP0000
                var rsa = builder.Services.BuildServiceProvider().GetRequiredService<RsaSecurityKey>();
#pragma warning restore ASP0000
        
                options.IncludeErrorDetails = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = rsa,
                    RequireSignedTokens = false,
                    RequireExpirationTime = false,
                    ValidateLifetime = false,
                    ValidateAudience = false,
                    ValidateIssuer = false, 
                    RequireAudience = false,
                };
            });

        builder.Services.AddDbContext<AppDbContext>(o => 
            o.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

        var app = builder.Build();

// Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseCors("AllowAll");

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}