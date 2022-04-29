using CRUD.DB;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var constr = new SqliteConnection(new SqliteConnectionStringBuilder { DataSource = "MyDb.db" }.ToString());
builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlite(constr));
builder.Services.AddHostedService<DbUtilService>();
builder.Services.AddHostedService<TimedHostedService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

