using System.Collections.Generic;

namespace PYP_CustomMiddleware.Middlewares
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public CustomMiddleware(IConfiguration configuration, RequestDelegate next)
        {
            _configuration = configuration;
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
           var CompanyDatas= _configuration.GetSection("CompanyInfo").GetChildren();
           Dictionary<string,string> parameters = new Dictionary<string, string>();
            foreach (var data in CompanyDatas)
            {
                parameters.Add(data.Key, data.Value);
            }
            context.Response.OnStarting(state =>
            {
                var httpContext = (HttpContext)state;
                foreach (var keyValue in parameters)
                {
                    httpContext.Response.Headers.Add(keyValue.Key, keyValue.Value);
                }
                return Task.CompletedTask;
            },context);
            await _next(context);
        }

       
    }
}
