using Microsoft.EntityFrameworkCore;
using ProfileProject.Api.Middlewares;
using ProfileProject.Application.Services.Profile;
using ProfileProject.DataAccess.Common.Implementations;
using ProfileProject.DataAccess.Persistence;
using ProfileProject.DataAccess.Persistence.Interceptors;
using ProfileProject.DataAccess.Profile;
using ProfileProject.Domain.Common.Interfaces;
using ProfileProject.Domain.Entities.Profile;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    opt.UseSqlServer("Data Source=.\\SQL2022;Initial Catalog=ProfileDb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30");//builder.Configuration.GetConnectionString("SqlConnectionString"));
});

builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IProfileService, ProfileService>();

builder.Services.AddScoped<AuditableEntitySaveChangeInterceptors>();
builder.Services.AddTransient<IDateTime, DateTimeService>();
builder.Services.AddScoped<GlobalExceptionHandlingMiddleware>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
    app.UseSwagger();
}

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
