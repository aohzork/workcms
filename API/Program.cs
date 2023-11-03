using API.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Determine the environment
var environment = builder.Configuration.GetSection("Environment").Value ?? "Development";

// Read ConnectionStrings from appropriate appsettings file
var appSettingsFileName = $"appsettings.{environment}.json";
var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile(appSettingsFileName, optional: true, reloadOnChange: true)
    .Build();

var connectionStrings = new ConnectionStrings();
configuration.GetSection("ConnectionStrings").Bind(connectionStrings);

// Add DbContext with options
builder.Services.AddDbContext<CrmContext>(options =>
{
    // Use the appropriate connection string based on the environment
    if (environment.Equals("Development", StringComparison.OrdinalIgnoreCase))
    {
        options.UseSqlServer(connectionStrings.Development);
    }
    else
    {
        options.UseSqlServer(connectionStrings.Production);
    }
});

// Add services to the container.

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
