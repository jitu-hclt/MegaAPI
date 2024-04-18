using System.Text;
using System.Text.Json.Serialization;
using BLLayer.Services;
using MegaLTAPI1.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
BLLayer.Configure.ConfigureServices(builder.Services, builder.Configuration);

//builder.Services.AddScoped<IStudentService, StudentService>();
//builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IService, Service>();

//Add DbContext service
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
//});

// Add services to the container.

builder.Services.AddControllers(config =>
{
    //config.Filters.Add<MyActionFilterAttribute>();    
})
.AddJsonOptions(config =>
{
    config.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
//.AddJsonOptions(options =>
//{
//    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
//});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});



//Add response caching
builder.Services.AddResponseCaching();

builder.Services.AddAuthentication(defaultScheme:JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var validIssuer = builder.Configuration["JwtBearer:Issuer"];
        var validAudience = builder.Configuration["JwtBearer:Audience"];
        var key = builder.Configuration["JwtBearer:SecretKey"];

        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidIssuer = validIssuer,
            ValidAudience = validAudience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ClockSkew = TimeSpan.Zero,
            RequireExpirationTime=true
        };
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "MegaLTAPI - Staged 2", Version = "1.0" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Put your token text below and click on Authorize.",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });
        
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}


app.UseHttpsRedirection();

app.UseRouting();

BLLayer.TestDataGenerator.Generate(app.Services);

app.UseCors();

app.Use(async (context, next) =>
{
    context.Request.GetTypedHeaders().CacheControl = new Microsoft.Net.Http.Headers.CacheControlHeaderValue
    {
        Public = true
    };
    await next();
});

app.UseAuthentication();

app.UseAuthorization();

app.UseResponseCaching();

app.MapControllers();

app.Run();

