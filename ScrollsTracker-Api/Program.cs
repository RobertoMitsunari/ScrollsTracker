using Microsoft.EntityFrameworkCore;
using ScrollsTracker.Api.Repository.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer("Server=localhost,1433;Database=scrolltracker;User Id=sa;Password=Roberto@123;TrustServerCertificate=True"));

builder.Services.AddControllers();
builder.Services.AddHttpClient<MangaService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();

app.Run();
