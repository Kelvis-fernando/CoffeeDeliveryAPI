using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UserCoffeeDeliveryAPI.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionStringMySql = builder.Configuration.GetConnectionString("UserConnection");
builder.Services.AddDbContext<UserDbContext>(options => options.UseMySql(
    connectionStringMySql,
    ServerVersion.Parse("10.4.22-MariaDB")
    ));

builder.Services.AddIdentity<IdentityUser<int>, IdentityRole<int>>().AddEntityFrameworkStores<UserDbContext>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
