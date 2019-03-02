using AspNet.WebApi.Exceptions.Interfaces;
using System;
using System.Collections.Concurrent;

namespace AspNet.WebApi.Exceptions.Mapper
{
    /// <summary>ExceptionMapper Options.</summary>
    public class ExceptionMapperOptions
    {
        /// <summary>Exception Map Dictionary.</summary>
        public readonly ConcurrentDictionary<Type, Type> Exceptions;

        /// <inheritdoc />
        public ExceptionMapperOptions() => Exceptions = new ConcurrentDictionary<Type, Type>();

        /// <summary>Register map for Exception and ApiException.</summary>
        /// <typeparam name="TException"><see cref="Exception" />.</typeparam>
        /// <typeparam name="TApiException"><see cref="ApiException" />.</typeparam>
        public void Map<TException, TApiException>() where TException : Exception where TApiException : IApiException
        {
            var exceptionType = typeof(TException);
            var apiExceptionType = typeof(TApiException);

            if (Exceptions.TryAdd(exceptionType, apiExceptionType))
            {
                return;
            }

            if (Exceptions.TryRemove(exceptionType, out _))
            {
                Exceptions.TryAdd(exceptionType, apiExceptionType);
            }
        }
    }
}
