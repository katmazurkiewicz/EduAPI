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
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(Assembly.Load("EduAPI.Services"));
builder.Services.AddSwaggerGen(c => { c.EnableAnnotations(); });
builder.Services.AddCors(o => o.AddDefaultPolicy(builder => {
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
