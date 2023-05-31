using Foreign_Trips.DbContexts;
using Foreign_Trips.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
                      });
});
builder.Services.AddControllers(options =>
    {
        options.ReturnHttpNotAcceptable = true;
    })
        .AddXmlDataContractSerializerFormatters();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AgentDbContext>(option =>
    {
        
        option.UseSqlServer(
            builder.Configuration["ConnectionStrings:SqlConnection"]
            );
    });
    builder.Services.AddSwaggerGen();
    builder.Services.AddScoped<IAgentRepository, AgentRepository>();
    builder.Services.AddScoped<IAuthRepository, AuthRepository>();
    builder.Services.AddScoped<IRequestRepository, RequestRepository>();
    builder.Services.AddScoped<IRequestStatusRepository, RequestStatusRepository>();
    builder.Services.AddScoped<IRequestTravelRepository, RrequestTravelRepository>();
    builder.Services.AddScoped<IAdminRepository, AdminRepository>();

    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
        .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
        {

            options.TokenValidationParameters = new()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                ValidIssuer = builder.Configuration["AppSettings:Issuer"],
                ValidAudience = builder.Configuration["AppSettings:Audience"],

                IssuerSigningKey = new SymmetricSecurityKey(
                  Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:SecretForKey"]))
            };
        }
        );
    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseRouting();
    app.UseCors(MyAllowSpecificOrigins);
    app.UseAuthorization();
    app.UseAuthorization();
    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });

    app.Run();
