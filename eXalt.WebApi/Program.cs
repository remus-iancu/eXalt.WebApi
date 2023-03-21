using eXalt.Domain;
using eXalt.DomainApi;
using Microsoft.EntityFrameworkCore;
using SqlLite.PersistanceLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ExaltContext>(options => { options.UseSqlite(builder.Configuration.GetConnectionString("DbConnection")).EnableDetailedErrors(); });
builder.Services.AddScoped<IRepository, ExaltRepository>();
builder.Services.AddScoped<IDomainProvider, DomainProvider>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseRouting();
app.MapControllers();

app.Run();
