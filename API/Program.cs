using BLL.Helpers;
using BLL.Services;
using DAL;
using DAL.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Core.Configurations;
using Core.Interfaces.Helpers;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using System.Text;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:5173", 
                              "https://localhost:7000", 
                              "http://localhost:5220")
                          .AllowAnyHeader()
                          //.AllowAnyMethod()
                          .AllowCredentials();
                      });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddDbContext<FinanceDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.Configure<AuthSettings>(builder.Configuration.GetSection("AuthSettings"));

builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();

builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));

builder.Services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
builder.Services.AddScoped(typeof(IUserService), typeof(UserService));

builder.Services.AddScoped<IAuthenticationTokenService, AuthenticationTokenService>();


//var appRepos = typeof(BaseRepository<>).Assembly.GetTypes().Where(s => s.Name.ToLower().EndsWith("repository") && s.IsClass).ToList();

//foreach (var appRepo in appRepos)
//    services.Add(new ServiceDescriptor(appRepo, appRepo, ServiceLifetime.Scoped));

//var appServices = typeof(IBaseService<>).Assembly.GetTypes().Where(s => s.Name.ToLower().EndsWith("service") && s.IsInterface).ToList();

//foreach (var appService in appServices)
//{
//    builder.Services.Add(new ServiceDescriptor(appService, appService, ServiceLifetime.Scoped));
//}

// Explicitly register the settings object by delegating to the IOptions object
//builder.Services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<Configurations>>().Value);


string secrt = configuration.GetSection("AuthSettings:TokenSecret").Value.ToString();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secrt)),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });

    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });

    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();
app.MapControllers();

app.Run();