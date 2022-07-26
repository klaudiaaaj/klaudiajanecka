using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Extensions
{
    public static class GetRequestBody 
    {
        public static string GetRawBodyString(this HttpContext httpContext, Encoding encoding)
        {
            var body = "";
            if (httpContext.Request.ContentLength == null || !(httpContext.Request.ContentLength > 0) ||
                !httpContext.Request.Body.CanSeek) return body;
            httpContext.Request.Body.Seek(0, SeekOrigin.Begin);
            using (var reader = new StreamReader(httpContext.Request.Body, encoding, true, 1024, true))
            {
                body = reader.ReadToEnd();
            }
            httpContext.Request.Body.Position = 0;
            return body;
        }
        public static async Task<string> ReadRequestBodyAsync(HttpRequest request)
        {
            request.Body.Seek(0, SeekOrigin.Begin);
            using var reader = new StreamReader(request.Body);
            var bodyAsText = await reader.ReadToEndAsync();
            request.Body.Seek(0, SeekOrigin.Begin);

            return bodyAsText;
        }

        public static async Task<string> ReadResponseBodyAsync(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            using var reader = new StreamReader(response.Body);
            var bodyAsText = await reader.ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);

            return bodyAsText;
        }
    }
}
