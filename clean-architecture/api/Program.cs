using infrastructure.Extension;
using infrastructure.Middleware;
using application;

var builder = WebApplication.CreateBuilder(args);


// Logger Integration

builder.Logging.ConfigureSeriLogService();

//Cross origin support
builder.Services.ConfigureCorsService();

//Response Compression
builder.Services.ConfigureCompression();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Infrastructure Dependencies
builder.Services.Configure_Infrastructure_Dependencies();

//Application Dependencies
builder.Services.Configure_Application_Dependencies();

var app = builder.Build();

app.UseResponseCompression();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Cors-Policy");

app.ConfigureStaticFileMiddleWare();

app.UseMiddleware<GlobalErrorHandler>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
