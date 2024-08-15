using Microsoft.EntityFrameworkCore;
using MyWebAPI.Databases;
using MyWebAPI.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options=>
{
	options.UseSqlite("Data Source=./Badaboy.db");
});
builder.Services.AddAutoMapper(typeof(MapProfile));
// tambahkan semua controller
builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// tambahkan mapping controller
app.MapControllers();

app.Run();

