using Application;
using Microsoft.EntityFrameworkCore;
using Persistence;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace API;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddAplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddDbContext<DataContext>(opt =>
        {
            opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        });
        services.AddCors(opt =>
        {
            opt.AddPolicy("CorsPolicy", policy =>
            {
                policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000");
            });
        });


        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Application.Products.Select).Assembly));
        services.AddAutoMapper(typeof(MappingProfiles).Assembly);
        
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<Application.Products.Create>();

        return services;

    }
}
