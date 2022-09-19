using Microsoft.EntityFrameworkCore;
using TestTask.DataBase.Data;
using System.Configuration;
using MediatR;
using TestTask.CQRS.Features.Employees.Commands;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(AddOrEditEmployeeCommand).Assembly);


builder.Services.AddDbContext<TestTaskDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("TestTask.Web"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
