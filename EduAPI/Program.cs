using EduAPI.Middlewares;
using EduAPI.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.SetUpDatabases(builder.Configuration);
builder.Services.AddServices();
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.SetUpLogger();
builder.Services.AddAutoMapper(Assembly.Load("EduAPI.Services"));
builder.Services.SetUpSwagger();
builder.Services.SetUpCors();
builder.Services.SetUpAuthentication(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
app.UseCors();
app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
