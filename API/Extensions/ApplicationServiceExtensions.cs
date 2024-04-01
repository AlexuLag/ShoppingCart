using Application;
using Application.Product;
using Microsoft.EntityFrameworkCore;
using Persistence;

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


        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Select.Handler).Assembly));


        return services;

    }
}
