using PYP_CustomMiddleware.Middlewares;

namespace PYP_CustomMiddleware.Extentions
{
    public static class CustomMiddlewareExstentions
    {
        public static IApplicationBuilder UseContent(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomMiddleware>();
        }
    }
}
