using Catalog.Domain.Interfaces;
using Catalog.Infrastructure;
using Catalog.Infrastructure.Repositories;
using Catalog.Services.Implementations;
using Catalog.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.WriteIndented = true);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder
        .SetIsOriginAllowed((host) => true)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
});


//Infrastructure
builder.Services.AddDbContext<CatalogContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CatalogContext"),
        sqlServerOptionsAction: sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
        });
},ServiceLifetime.Scoped  
//Showing explicitly that the DbContext is shared across the HTTP request scope (graph of objects started in the HTTP request)
);

builder.Services.AddScoped(typeof(ICatalogRepository<>), typeof(CatalogRepository<>));

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Filmoxi - Catalog HTTP API",
        Version = "v1",
        Description = "The Catalog Service HTTP API"
    });
    
});

//Services
builder.Services.AddScoped<IFilmService, FilmService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger()
            .UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/v1/swagger.json", "Catalog.API V1");
                c.DocExpansion(DocExpansion.None);
                c.RoutePrefix = string.Empty;
            });

app.UseRouting();
app.UseCors("CorsPolicy");

app.UseAuthentication();

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
    endpoints.MapControllers();
});

app.Run();
