using Microsoft.EntityFrameworkCore;
using NorthwindReactApp.Infrastructure.Data;
using NorthwindReactApp.Infrastructure.Repository.IRepository;
using NorthwindReactApp.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);



//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
// Add the DbContext to the services
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
    b => b.MigrationsAssembly("NorthwindReactApp.Infrastructure")       // Adding the migration place. 
    ));


builder.Services.AddControllers();      // The service provider for the application. Gives access to all service providers created using DI
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Check database connection
await app.Services.CheckDbConnectionAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
