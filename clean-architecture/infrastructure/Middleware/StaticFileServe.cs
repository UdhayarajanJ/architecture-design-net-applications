using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;

namespace infrastructure.Middleware
{
    public static class StaticFileServe
    {
        public static IApplicationBuilder ConfigureStaticFileMiddleWare(this IApplicationBuilder app)
        {
            
            string rootPath = Path.Combine(Environment.CurrentDirectory, "Public");

            StaticFileOptions options = new StaticFileOptions();
            
            options.FileProvider = new PhysicalFileProvider(rootPath);
            options.RequestPath = "/Documents";
            options.ServeUnknownFileTypes = true;
            options.HttpsCompression = new Microsoft.AspNetCore.Http.Features.HttpsCompressionMode();

            app.UseStaticFiles(options);

            return app;

        }
    }
}
