using Microsoft.Extensions.DependencyInjection;
using System;

namespace AspNet.WebApi.Exceptions.Mapper.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddExceptionMapper(this IServiceCollection services) =>
            services.AddExceptionMapper(_ => { });

        public static IServiceCollection AddExceptionMapper(this IServiceCollection services, Action<ExceptionMapperOptions> setupAction)
        {
            var options = new ExceptionMapperOptions();

            setupAction(options);

            var mapper = new ExceptionMapper(options);

            services.AddSingleton<IExceptionMapper>(mapper);

            return services;
        }
    }
}
