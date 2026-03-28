using AppLogic;
using AppLogic.Interfaces;
using API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IUserManager, UserManager>();
builder.Services.AddSingleton<IAuthManager, AuthManager>();
builder.Services.AddSingleton<IEmailService, EmailService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "DemoPolicy",
        policy =>
        {
            policy.AllowAnyOrigin(); //mypage.com, www.mypage.com, localhost:3000, etc
            policy.AllowAnyMethod(); //post, get, put, delete, etc
            policy.AllowAnyHeader(); //application/json, aplication/xml, etc
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
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

app.UseCors();

app.Run();
