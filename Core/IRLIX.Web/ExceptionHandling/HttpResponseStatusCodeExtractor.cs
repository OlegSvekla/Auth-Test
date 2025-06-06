using System.Net;
using System.Reflection;
using ShuttleX.Core.Attributes;

namespace ShuttleX.Web.ExceptionHandling;

public interface IHttpResponseStatusCodeExtractor
{
    int Extract(Exception ex);
}

public class HttpResponseStatusCodeExtractor : IHttpResponseStatusCodeExtractor
{
    public int Extract(Exception ex)
    {
        var customErrorAttribute = ex.GetType().GetCustomAttribute<HttpResponseStatusCodeAttribute>();
        var result = customErrorAttribute != null
            ? customErrorAttribute.StatusCode
            : (int)HttpStatusCode.InternalServerError;
        return result;
    }
}
