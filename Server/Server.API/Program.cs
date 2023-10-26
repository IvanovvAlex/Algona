using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Data.Interfaces;
using Server.Data.Interfaces.Repositories;
using Server.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// DB Context
builder.Services.AddDbContext<AlgonaDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<ITruckRepository, TruckRepository>();
    
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
    var dbContext = services.GetService<AlgonaDbContext>();
    await dbContext.Database.EnsureCreatedAsync();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
