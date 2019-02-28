using System;
using System.Linq;
using AspNet.WebApi.Exceptions.Interfaces;

namespace AspNet.WebApi.Exceptions.Mapper
{
    public class ExceptionMapper : IExceptionMapper
    {
        private ExceptionMapperOptions _options;

        public ExceptionMapper() : this(new ExceptionMapperOptions()) { }

        public ExceptionMapper(ExceptionMapperOptions options)
        {
            _options = options;
        }

        /// <inheritdoc />
        public IApiException Get<T>()
        {
            var result = _options.Exceptions[typeof(T)];

            return (IApiException)result.DeclaringType;
        }
    }
}
