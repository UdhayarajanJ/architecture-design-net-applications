using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using System.IO.Compression;

namespace infrastructure.Extension
{
    public static class ResponseCompressionService
    {

        public static void ConfigureCompression(this IServiceCollection services)
        {
            services.AddResponseCompression(x =>
            {
                x.EnableForHttps = true;
                x.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/json" });
                x.Providers.Add<BrotliCompressionProvider>();
                x.Providers.Add<GzipCompressionProvider>();
            });

            services.Configure<BrotliCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Fastest;
            });

            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.SmallestSize;
            });

        }

    }
}
