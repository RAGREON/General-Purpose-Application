using Lab.Services;

var builder = WebApplication.CreateBuilder(args);

string? connectionString = builder.Configuration.GetConnectionString("LAB_CONN_STR");
Console.WriteLine(connectionString);

builder.Services.AddDbContext<LabContext>(options =>
{
  options.UseNpgsql(connectionString);
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ILabRepository, LabRepository>();
builder.Services.AddScoped<LabService>();

var app = builder.Build();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();