namespace EduAPI.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void SetUpDatabases(this IServiceCollection services, IConfiguration configuration)
        {
            var eduDBconnectionString = configuration["ConnectionStrings:EduDB"];
            var authDBconnectionString = configuration["ConnectionStrings:AuthDB"];
            services.AddSqlServer<EduContext>(eduDBconnectionString);
            services.AddSqlServer<AuthContext>(authDBconnectionString);
        }
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IMaterialService, MaterialService>();
            services.AddScoped<ITypeService, TypeService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<ExceptionHandlerMiddleware>();
        }
        public static void SetUpLogger(this IServiceCollection services)
        {
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddSeq();
                Log.Logger = new LoggerConfiguration()
                .WriteTo.Seq("http://localhost:5341")
                .CreateLogger();
            });
        }
        public static void SetUpSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(o => {
                 o.EnableAnnotations();
                 o.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                 {
                     Description = "Authorization header using Bearer scheme",
                     In = ParameterLocation.Header,
                     Name = "Authorization",
                     Type = SecuritySchemeType.ApiKey
                 });
                 o.OperationFilter<SecurityRequirementsOperationFilter>();
             });
        }
        public static void SetUpCors (this IServiceCollection services)
        {
            services.AddCors(o => o.AddDefaultPolicy(builder => {
                 builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
             }));
        }
        public static void SetUpAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                    .GetBytes(configuration.GetSection("JWTsettings:Token").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }
    }
}
