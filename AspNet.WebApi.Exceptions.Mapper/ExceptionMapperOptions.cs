using AspNet.WebApi.Exceptions.Interfaces;
using System;
using System.Collections.Concurrent;

namespace AspNet.WebApi.Exceptions.Mapper
{
    public class ExceptionMapperOptions
    {
        public ConcurrentDictionary<Type, Type> Exceptions;

        public ExceptionMapperOptions()
        {
            Exceptions = new ConcurrentDictionary<Type, Type>();
        }

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
