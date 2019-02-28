﻿using AspNet.WebApi.Exceptions.Mapper.Extensions;
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
            _serviceCollection.AddExceptionMapper(SetupExceptionMapper);
            _serviceProvider = _serviceCollection.BuildServiceProvider(true);
        }

        private void SetupExceptionMapper(ExceptionMapperOptions options)
        {
            options.Map<ArgumentException, BadRequestException>();
        }

        [Fact]
        public void AddExceptionMapper()
        {
            var exceptionMapper = _serviceProvider.GetRequiredService<IExceptionMapper>();

            Assert.NotNull(exceptionMapper);
        }

        [Fact]
        public void GetExceptionType()
        {
            var exceptionMapper = _serviceProvider.GetRequiredService<IExceptionMapper>();
            var mappedType = exceptionMapper.Get<ArgumentException>();

            Assert.Equal(typeof(BadRequestException), mappedType);
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
