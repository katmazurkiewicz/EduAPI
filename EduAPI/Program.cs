using AutoMapper;
using EduAPI.Data.Context;
using EduAPI.Data.DAL;
using EduAPI.Data.DAL.Interfaces;
using EduAPI.Middlewares;
using EduAPI.Services;
using EduAPI.Services.Interfaces;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSqlServer<EduContext>(builder.Configuration.GetConnectionString("EduDB"));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IMaterialService, MaterialService>();
builder.Services.AddScoped<ITypeService, TypeService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<ExceptionHandlerMiddleware>();
//builder.Services.AddScoped<Serilog.ILogger, Serilog.Lo>();
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddSeq();
    Log.Logger = new LoggerConfiguration()
    .WriteTo.Seq("http://localhost:5341")
    .CreateLogger();
});
builder.Services.AddAutoMapper(Assembly.Load("EduAPI.Services"));
builder.Services.AddSwaggerGen(c => { c.EnableAnnotations(); });
builder.Services.AddCors(o => o.AddDefaultPolicy(builder => {
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));

var app = builder.Build();
//Log.Logger = new LoggerConfiguration()
//    .WriteTo.Seq("http://localhost:5341")
//    .CreateLogger();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
app.UseCors();
app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
