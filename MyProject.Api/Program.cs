using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyProject.Core;
using MyProject.Infrastructure;
using MyProject.Infrastructure.Data;
using MyProject.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("Data"));
});

// Dependancies
builder.Services
    .AddInfrastructureDependencies()
    .AddServiceDependencies()
    .AddCoreDependencies()
    .AddRegisterModuleInfrastructureDependencies(builder.Configuration)
    .AddModuleCoreDependenciesLocalization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(options.Value);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
