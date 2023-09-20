using repo.application.Extensions;
using repo.application.Middlewares;
using repo.services;

var builder = WebApplication.CreateBuilder(args);

//Configure Logger
builder.Logging.ConfigureSeriLogService();

//Configure Health Check Service
builder.Services.ConfigureHealthCheckService();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.ConfigureDependencies();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Configure the Health Check Middlware
app.ConfigureHealthMiddleWare();

//Configure the Error Handler Middleware
app.UseMiddleware<GlobalErrorHandler>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
