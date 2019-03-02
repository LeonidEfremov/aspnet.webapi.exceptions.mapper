using AspNet.WebApi.Exceptions.Interfaces;
using System;
using System.Collections.Concurrent;

namespace AspNet.WebApi.Exceptions.Mapper
{
    /// <summary>ExceptionMapper Options.</summary>
    public class ExceptionMapperOptions
    {
        /// <summary>Exception Map Dictionary.</summary>
        private readonly ConcurrentDictionary<Type, Type> _exceptions;

        /// <inheritdoc />
        public ExceptionMapperOptions() => _exceptions = new ConcurrentDictionary<Type, Type>();

        /// <summary>Get IApiException by Exception.</summary>
        /// <typeparam name="T">Exception type.</typeparam>
        public Type Get<T>() where T : Exception => _exceptions[typeof(T)];

        /// <summary>Register map for Exception and ApiException.</summary>
        /// <typeparam name="TException"><see cref="Exception" />.</typeparam>
        /// <typeparam name="TApiException"><see cref="ApiException" />.</typeparam>
        public void Map<TException, TApiException>() where TException : Exception where TApiException : IApiException
        {
            var exceptionType = typeof(TException);
            var apiExceptionType = typeof(TApiException);

            if (_exceptions.TryAdd(exceptionType, apiExceptionType))
            {
                return;
            }

            if (_exceptions.TryRemove(exceptionType, out _))
            {
                _exceptions.TryAdd(exceptionType, apiExceptionType);
            }
        }
    }
}
