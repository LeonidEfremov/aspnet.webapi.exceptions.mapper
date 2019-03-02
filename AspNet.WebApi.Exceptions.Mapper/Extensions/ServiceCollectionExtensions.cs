using Microsoft.Extensions.DependencyInjection;
using System;

namespace AspNet.WebApi.Exceptions.Mapper.Extensions
{
    /// <summary>ServiceCollection extenions.</summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>Add ExceptionMapper to ServiceCollection.</summary>
        /// <param name="services">Current ServiceCollection.</param>
        public static IServiceCollection AddExceptionMapper(this IServiceCollection services) =>
            services.AddExceptionMapper(_ => { });

        /// <summary>Add ExceptionMapper to ServiceCollection with Options.</summary>
        /// <param name="services">Current ServiceCollection.</param>
        /// <param name="setupAction">Setup Options action.</param>
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
