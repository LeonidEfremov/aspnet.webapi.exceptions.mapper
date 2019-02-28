﻿using System;
using AspNet.WebApi.Exceptions.Interfaces;

namespace AspNet.WebApi.Exceptions.Mapper
{
    public interface IExceptionMapper
    {
        Type Get<T>();

        IApiException Get<T>(T exception) where T : Exception;
    }
}