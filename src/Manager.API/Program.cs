using Manager.Infra.Context;
using Manager.API.Configuration;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var serverVersion = new MySqlServerVersion(new Version(10, 4, 27));
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.addSwagger();
builder.Services.AddControllers();
builder.Services.AddAuthentication(builder);
builder.Services.ResolveDependecies(builder);

builder.Services.AddDbContext<ManagerContext>(options => 
        options.UseMySql(connectionString, serverVersion), 
    ServiceLifetime.Transient);

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
