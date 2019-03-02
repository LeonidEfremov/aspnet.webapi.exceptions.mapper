using AspNet.WebApi.Exceptions.Mapper.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace AspNet.WebApi.Exceptions.Mapper.Tests
{
    public class ExceptionMapperTests
    {
        private readonly IServiceCollection _serviceCollection = new ServiceCollection();
        private readonly IServiceProvider _serviceProvider;

        public ExceptionMapperTests()
        {
            _serviceCollection
                .AddExceptionMapper()
                .AddExceptionMapper(_ =>
                {
                    _.Map<System.ArgumentException, ApiException>();
                    _.Map<System.ArgumentException, BadRequestException>();
                    _.Map<System.NullReferenceException, ApiException>();
                });
            _serviceProvider = _serviceCollection.BuildServiceProvider(true);
        }

        [Fact]
        public void AddExceptionMapper()
        {
            var exceptionMapper = _serviceProvider.GetRequiredService<IExceptionMapper>();

            Assert.NotNull(exceptionMapper);
        }

        [Fact]
        public void GetApiException()
        {
            var exceptionMapper = _serviceProvider.GetRequiredService<IExceptionMapper>();
            var exception = new ArgumentException();
            var model = exceptionMapper.Get(exception);

            Assert.IsType<BadRequestException>(model);
        }
    }
}
