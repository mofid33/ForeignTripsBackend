using Foreign_Trips.DbContexts;
using Foreign_Trips.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
                      });
});
builder.Services.AddControllers(options =>
    {
        options.ReturnHttpNotAcceptable = true;
    }).AddNewtonsoftJson(options => {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
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
    builder.Services.AddScoped<IAgentRepository, AgentRepository>();
    builder.Services.AddScoped<IAuthRepository, AuthRepository>();
    builder.Services.AddScoped<IRequestRepository, RequestRepository>();
    builder.Services.AddScoped<IInternationalAdminRepository, InternationalAdminRepository>();
    builder.Services.AddScoped<ITicketRepository, TicketRepository>();
    builder.Services.AddScoped<IReportRepository, ReportRepository>();
    builder.Services.AddScoped<IMainAdminRepository, MainAdminRepository>();
    builder.Services.AddScoped<ISupervisorRepository, SupervisorRepository>();
    builder.Services.AddScoped<IInternationalExpertRepository, InternationalExpertRepository>();
    builder.Services.AddScoped<IMessageRepository, MessageRepository>();

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
