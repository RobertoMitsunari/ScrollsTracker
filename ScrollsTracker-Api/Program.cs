using ScrollsTracker.Api.Config;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("ConnectionString do banco não encontrada");
}
builder.Services.AddConfigRepository(connectionString);


builder.Services.AddCorsConfig();
builder.Services.AddControllers();
builder.Services.AddConfigService();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("PermitirFrontend");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();

app.Run();
