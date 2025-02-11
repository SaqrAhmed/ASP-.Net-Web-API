using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Test.Models;
using Test.Reposatries.Department_Reposatiry;
using Test.Reposatries.Employee_Reposatiry;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyContext>(Op =>
{
    Op.UseSqlServer(builder.Configuration.GetConnectionString("SQL"));
}
);

builder.Services.AddScoped<IEmployeeReposatiry, EmployeeReposatiry>();
builder.Services.AddScoped<IDepartmentReposatiry, DepartmentReposatiry>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
