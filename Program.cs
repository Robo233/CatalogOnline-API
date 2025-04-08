/// <summary>
/// Main program entry point for the CatalogOnline API application.
/// Configures services, middleware, and routing, then builds and runs the web application.
/// </summary>
using CatalogOnline_API.Interfaces.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDb"));

builder.Services.AddSingleton(serviceProvider =>
{
    /// <summary>
    /// Configures and returns the MongoDB database instance using settings from configuration.
    /// </summary>
    var settings = serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value;
    var client = new MongoClient(settings.ConnectionString);
    return client.GetDatabase(settings.DatabaseName);
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISchoolClassRepository, SchoolClassRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IScienceRepository, ScienceRepository>();
builder.Services.AddScoped<IGradeRepository, GradeRepository>();

/// <summary>
/// Configures Swagger for API documentation.
/// </summary>
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

/// <summary>
/// Enables Swagger middleware to serve generated Swagger as a JSON endpoint and UI.
/// </summary>
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CatalogOnline API v1");
});

app.UseRouting();

/// <summary>
/// Sets up authentication and authorization middleware.
/// </summary>
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
