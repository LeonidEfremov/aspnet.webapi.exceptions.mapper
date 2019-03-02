using System;
using AspNet.WebApi.Exceptions.Interfaces;

namespace AspNet.WebApi.Exceptions.Mapper
{
    /// <summary>Exception Mapper.</summary>
    public interface IExceptionMapper
    {
        /// <summary>Get <see cref="ApiException" /> instance for registered Exception.</summary>
        /// <param name="exception"><see cref="Exception" />.</param>
        /// <typeparam name="T"></typeparam>
        IApiException Get<T>(T exception) where T : Exception;
    }
}