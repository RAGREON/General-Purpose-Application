var builder = WebApplication.CreateBuilder();

string? connectionString = builder.Configuration.GetConnectionString("DefaultString");

builder.Services.AddDbContext<TeacherContext>(options =>
{
  options.UseNpgsql(connectionString);
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();