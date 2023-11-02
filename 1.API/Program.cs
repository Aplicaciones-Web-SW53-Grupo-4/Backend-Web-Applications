
using System.Reflection;
using System.Text;
using _1.API.Mapper;
using _2.Domain;
using _3.Data;
using _3.Data.Context;
using _3.Data.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
        });
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options=>{
    options.SwaggerDoc("v1",new OpenApiInfo
    {
        Version = "v1",
        Title = "Aumovile-Unit",
        Description = "AN ASP.NET Core Web API for managing todo items",
        
    });
    //using System.Reflexion
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,xmlFilename));
});





//Inyeccion dependencias
builder.Services.AddScoped<IUserData, UserMsqlData>();
builder.Services.AddScoped<IUserDomain, UserDomain>();
builder.Services.AddScoped<IAutomobileData, AutomobileMsqlData>();
builder.Services.AddScoped<IAutomobileDomain, AutomobileDomain>();
builder.Services.AddScoped<IRequestRentData, RequestRentMsqlData>();
builder.Services.AddScoped<IRequestRentDomain, RequestRentDomain>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt.Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))

    };
});
//Pomelo MySQL Conexion
var connectionString = builder.Configuration.GetConnectionString("AutomovileUnitDB");
builder.Services.AddDbContext<AutomovileUnitBD>(
    dbContextOptions =>
    {
        dbContextOptions.UseMySql(connectionString,
            ServerVersion.AutoDetect(connectionString),
            options => options.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: System.TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null)
        );
    });

//Automapper
builder.Services.AddAutoMapper(
 
    typeof(ModelToAPI),
    typeof(APIToModel)
);

var app = builder.Build();
using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AutomovileUnitBD>())
{
    context.Database.EnsureCreated();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Aumovile-Unit API v1");
    });
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();