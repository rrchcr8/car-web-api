using Application;
using Microsoft.EntityFrameworkCore;
using Persistance;
using WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMyServices();
//builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddPersistance(builder.Configuration);
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsConfiguration",
                      builder =>
                      {
                          builder
                          .WithOrigins("http://localhost:4200")
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowAnyOrigin();
                          //.AllowCredentials();
                      });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
        c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json","car_api");
    });
}
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseCors("CorsConfiguration");

app.UseAuthorization();

app.MapControllers();

app.Run();
