using Asp.Versioning;
using Serilog;
using System.Net;
using System.Threading.RateLimiting;

namespace EventBooking.API.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static ConfigureHostBuilder WithSerilog(this ConfigureHostBuilder host)
        {
            host.UseSerilog((context, loggerConfig) =>
            {
                loggerConfig.ReadFrom.Configuration(context.Configuration);
            });

            return host;
        }

        public static IServiceCollection WithRateLimiting(this IServiceCollection services)
        {
            services.AddRateLimiter(options =>
            {
                options.RejectionStatusCode = (int)HttpStatusCode.TooManyRequests;

                options.AddPolicy("fixed", httpContext =>
                {
                    return RateLimitPartition.GetFixedWindowLimiter(httpContext.Connection.RemoteIpAddress?.ToString(), partition =>
                    {
                        return new FixedWindowRateLimiterOptions
                        {
                            PermitLimit = 5,
                            Window = TimeSpan.FromSeconds(60)
                        };
                    });
                });
            });

            return services;
        }

        public static IServiceCollection WithApiVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(option =>
            {
                option.AssumeDefaultVersionWhenUnspecified = true;
                option.DefaultApiVersion = new ApiVersion(1);
                option.ReportApiVersions = true;
            }).AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            return services;
        }
    }
}
