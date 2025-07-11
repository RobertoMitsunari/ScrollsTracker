using ScrollsTracker.Api.Config;
using ScrollsTracker.Application.Reference;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("ConnectionString do banco n�o encontrada");
}
builder.Services.AddConfigRepository(connectionString);


builder.Services.AddCorsConfig();
builder.Services.AddControllers();
builder.Services.AddConfigService();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => {
	cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
	cfg.RegisterServicesFromAssembly(typeof(ApplicationAssemblyReference).Assembly);
});

var app = builder.Build();

app.UseCors("PermitirFrontend");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();

app.Run();
