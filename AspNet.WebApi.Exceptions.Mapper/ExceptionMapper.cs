using System;
using System.Linq;
using AspNet.WebApi.Exceptions.Interfaces;

namespace AspNet.WebApi.Exceptions.Mapper
{
    /// <inheritdoc />
    public class ExceptionMapper : IExceptionMapper
    {
        private ExceptionMapperOptions _options;

        /// <inheritdoc />
        public ExceptionMapper() : this(new ExceptionMapperOptions()) { }

        /// <inheritdoc />
        public ExceptionMapper(ExceptionMapperOptions options)
        {
            _options = options;
        }

        /// <inheritdoc />
        public IApiException Get<T>(T exception) where T : Exception
        {
            var apiExceptionType = _options.Exceptions[typeof(T)];
            var apiException = (IApiException)Activator.CreateInstance(apiExceptionType, exception.Message, exception);

            return apiException;
        }
    }
}
