using API.Interfaces;
using API.Services;
using AppLogic;
using AppLogic.Interfaces;
using DTO;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.Configure<CloudinarySettings>(
    builder.Configuration.GetSection("CloudinarySettings")
);


builder.Services.AddEndpointsApiExplorer();

// Configurar Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "PSA API",
        Version = "v1",
        Description = "API del Sistema de Pago por Servicios Ambientales"
    });
});

// Registrar servicios
builder.Services.AddSingleton<IUserManager, UserManager>();
builder.Services.AddSingleton<IAuthManager, AuthManager>();
builder.Services.AddSingleton<AppLogic.Interfaces.IEmailService, EmailService>();
builder.Services.AddSingleton<IIngenieroManager, IngenieroManager>();
builder.Services.AddSingleton<AppLogic.Interfaces.ICloudinaryService, CloudinaryService>();



// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "DemoPolicy",
        policy =>
        {
            policy.AllowAnyOrigin();
            policy.AllowAnyMethod();
            policy.AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "PSA API v1");
        c.RoutePrefix = "swagger";
    });
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "PSA API v1");
        c.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors("DemoPolicy");

app.Run();