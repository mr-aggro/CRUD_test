using CRUD.DB;
using Microsoft.EntityFrameworkCore;

Timer _timer = new Timer(TimerCallback, null, 0, 60000);
void TimerCallback(Object o)
{
    // Display the date/time when this method got called.
    Console.WriteLine("In TimerCallback: " + DateTime.Now);
    using (var db = new MyDbContext())
    {
        db.Tanks.ForEachAsync(t => t.CurrentVolume = new Random().Next(t.MinVolume, t.MaxVolume));
        db.SaveChanges();
    }
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
using (var db = new MyDbContext())
{
    db.Database.EnsureCreated();
    db.Database.Migrate();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

