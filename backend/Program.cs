using backend.API.Config;
using backend.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;

//$env:ASPNETCORE_ENVIRONMENT="Development"

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(
    options => options.AddPolicy(name: "local-react",
    policy => policy.WithOrigins("http://localhost:3000")
                    .AllowAnyHeader()
                    .AllowAnyMethod()));

builder.Services.AddCors(
options => options.AddPolicy(name: "local-angular",
policy => policy.WithOrigins("http://localhost:4200")
.AllowAnyHeader()
.AllowAnyMethod()));

builder.Services.AddDependencies(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program).Assembly);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("local-angular");
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
