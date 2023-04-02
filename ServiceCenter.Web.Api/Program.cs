using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ServiceCenter.Web.Api.Database;
using ServiceCenter.Web.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ServiceDbContext>();
builder.Services.AddDbContext<UsersContext>();

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("superSecretKey@345")),
        };
    });

builder.Services.AddCors(
        options => options.AddDefaultPolicy(
        builder => builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
    ));

AddServices(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

void AddServices(WebApplicationBuilder webApplicationBuilder)
{
    webApplicationBuilder.Services.AddTransient<IServiceRepository, ServiceRepository>();
    webApplicationBuilder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
    webApplicationBuilder.Services.AddTransient<IManagerRepository, ManagerRepository>();
    webApplicationBuilder.Services.AddTransient<IJobRepository, JobRepository>();
    webApplicationBuilder.Services.AddTransient<IVehicleRepository, VehicleRepository>();
}