using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Data.Interfaces;
using Server.Data.Interfaces.Repositories;
using Server.Data.Repositories;
using Server.Domain.Interfaces;
using Server.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// DB Context
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AlgonaDbContext>(options => options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<ITruckRepository, TruckRepository>();
builder.Services.AddScoped<ISharedService, SharedService>();
    
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetService<AlgonaDbContext>()!;
    await dbContext.Database.EnsureCreatedAsync();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
