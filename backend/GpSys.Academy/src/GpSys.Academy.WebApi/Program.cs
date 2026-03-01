using GpSys.Academy.WebApi.Endpoints;
using GpSys.Academy.Application;
using GpSys.Academy.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapCourseEndpoints();

if (app.Environment.IsDevelopment())
{
  app.MapSeederEndpoints();
}

app.Run();