using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess;

public static class DataAccessServiceRegistration
{
    public static IServiceCollection AddDataAccessServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        string conString = configuration.GetConnectionString("BaseDb");
        services.AddDbContext<BaseDbContext>(opt => opt.UseMySql(conString, ServerVersion.AutoDetect(conString)));

        services.AddScoped<IUserDal, EfUserDal>();
        services.AddScoped<IOperationClaimDal, EfOperationClaimDal>();
        services.AddScoped<IUserOperationClaimDal, EfUserOperationClaimDal>();
        services.AddScoped<IRefreshTokenDal, EfRefreshTokenDal>();
        services.AddScoped<IProductDal, EfProductDal>();

        return services;
    }
}
