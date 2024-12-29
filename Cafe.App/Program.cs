using Cafe.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Security.App;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSharedServices();
builder.Services.AddSecurityServices();
builder.Services.AddDbContext<BaseContext<CafeContext>>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DBSettingConnection")));

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
