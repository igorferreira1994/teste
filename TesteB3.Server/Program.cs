using TesteB3.Server.Domain.Interface;
using TesteB3.Server.Domain.Service;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ITituloService, TituloService>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(options => options.WithOrigins("https://localhost:4200").AllowAnyMethod().AllowAnyHeader());

app.MapFallbackToFile("/index.html");

app.Run();
