using TestCihaziUretimPlanlama.Infrastructure.Extensions;
using TestCihaziUretimPlanlama.Application.Extensions;
using TestCihaziUretimPlanlama.API.Middleware;
using FluentValidation;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Circular reference'larý ignore et
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });

// FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Test Cihazý Üretim Planlama API",
        Version = "v1",
        Description = "Test cihazý üretim planlama sistemi API dokümantasyonu",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Ýsmail Öztürk",
            Email = "iozturk@bihl-wiedemann.de"
        }
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        c.IncludeXmlComments(xmlPath);
    }
});

// Infrastructure Services
builder.Services.AddInfrastructureServices(builder.Configuration);

// Application Services
builder.Services.AddApplicationServices();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseStaticFiles();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test Cihazý Üretim Planlama API V1");
        c.RoutePrefix = string.Empty;
        c.DocumentTitle = "Test Cihazý Üretim Planlama API";
    });
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

app.Run();