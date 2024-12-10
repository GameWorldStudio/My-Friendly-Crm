using Microsoft.EntityFrameworkCore;
using My_Friendly_CRM.Datas;
using My_Friendly_CRM.Interfaces;
using My_Friendly_CRM.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyAllowSpecificOrigins",
                      builder =>
                      {
                          // Permet les requêtes CORS de n'importe quelle origine avec n'importe quel en-tête et méthode
                          builder.WithOrigins("*")
                                 .AllowAnyHeader()
                                 .AllowAnyMethod();
                      });
});

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbcontext>(opt =>
{
    string co = builder.Configuration[key: "BDD:MySqlAlwaysData"];
    opt.UseMySql(co, new MySqlServerVersion("10.4.25-MariaDB - MariaDB Server"));
});

builder.Services.AddScoped<IUsersServices, UsersServices>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi


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