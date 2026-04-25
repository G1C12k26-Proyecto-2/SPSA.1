using API.Config;
using API.Interfaces;
using API.Services;
using AppLogic;
using AppLogic.Interfaces;
using CloudinaryDotNet;



// Add services to the container.
var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<GoogleMapsOptions>(
    builder.Configuration.GetSection("GoogleMaps"));

builder.Services.AddHttpClient();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IUserManager, UserManager>();
builder.Services.AddSingleton<IAuthManager, AuthManager>();
builder.Services.AddSingleton<IEmailService, EmailService>();
builder.Services.AddHttpClient<GoogleMapsService>();
builder.Services.AddSingleton<IIngenieroManager, IngenieroManager>();

builder.Services.AddSingleton<IAuditoriaManager, AuditoriaManager>();
builder.Services.AddSingleton<IReportesManager,  ReportesManager>();
builder.Services.AddSingleton<IPagoManager,  PagoManager>();

// ========== CLOUDINARY ==========
var cloudinaryAccount = new Account(
    builder.Configuration["Cloudinary:CloudName"],
    builder.Configuration["Cloudinary:ApiKey"],
    builder.Configuration["Cloudinary:ApiSecret"]
);
var cloudinary = new Cloudinary(cloudinaryAccount);
builder.Services.AddSingleton(cloudinary);
builder.Services.AddSingleton<CloudinaryStorageService>();
builder.Services.AddSingleton<API.Interfaces.ICloudinaryStorageService>(p => p.GetRequiredService<CloudinaryStorageService>());
builder.Services.AddSingleton<AppLogic.Interfaces.ICloudinaryStorageService>(p => p.GetRequiredService<CloudinaryStorageService>());


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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.UseCors("DemoPolicy");

app.UseCors("DemoPolicy"); // 👈 también fix aquí, faltaba el nombre de la política
app.Run();
