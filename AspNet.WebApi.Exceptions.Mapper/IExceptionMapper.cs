using AspNet.WebApi.Exceptions.Interfaces;

namespace AspNet.WebApi.Exceptions.Mapper
{
    public interface IExceptionMapper
    {
        IApiException Get<T>();
    }
}