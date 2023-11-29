using Microsoft.EntityFrameworkCore;
using Todo.Domain.Handlers;
using Todo.Domain.Infra.Context;
using Todo.Domain.Infra.Repositories;
using Todo.Domain.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMemoryCache();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("DataBase"));


// Dependency Injection
builder.Services.AddTransient<ITodoRepository, TodoRepository>();
builder.Services.AddTransient<TodoHandler, TodoHandler>();

builder.Services
   .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
   .AddJwtBearer(options =>
   {
       options.Authority = "https://securetoken.google.com/NOME-DO-PROJETO-NO-FIREBASE";
       options.TokenValidationParameters = new TokenValidationParameters
       {
           ValidateIssuer = true,
           ValidIssuer = "https://securetoken.google.com/NOME-DO-PROJETO-NO-FIREBASE",
           ValidateAudience = true,
           ValidAudience = "NOME-DO-PROJETO-NO-FIREBASE",
           ValidateLifetime = true
       };
   });
        

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
