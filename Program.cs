using System.Text;
using CatalogOnline_API.Interfaces.Repositories;
using CatalogOnline_API.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]!))
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddControllersWithViews();

builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDb"));

builder.Services.AddSingleton(serviceProvider =>
{
    var settings = serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    var client = new MongoClient(settings.ConnectionString);
    return client.GetDatabase(settings.DatabaseName);
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISchoolClassRepository, SchoolClassRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IScienceRepository, ScienceRepository>();
builder.Services.AddScoped<IGradeRepository, GradeRepository>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
 options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
 {
  Name = "Authorization",
  Type = SecuritySchemeType.ApiKey,
  Scheme = "Bearer",
  BearerFormat = "JWT",
  In = ParameterLocation.Header,
  Description = "Enter 'Bearer' followed by your token."
 });
 options.AddSecurityRequirement(new OpenApiSecurityRequirement
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
var app = builder.Build();

// Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CatalogOnline API v1");

});

app.UseRouting();

// Authentication
app.UseAuthentication();
app.UseAuthorization();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
