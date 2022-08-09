using AutoMapper;
using EduAPI.Data.Context;
using EduAPI.Data.DAL;
using EduAPI.Data.DAL.Interfaces;
using EduAPI.Services;
using EduAPI.Services.Interfaces;
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
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(Assembly.Load("EduAPI.Services"));
//builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddSwaggerGen(c => { c.EnableAnnotations(); });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
