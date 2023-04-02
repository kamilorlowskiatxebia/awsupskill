using Upskill.Contracts.Definitions;
using Upskill.Contracts.Services;

namespace Upskill.AwsApi
{
    public static class DependencyStartup
    {
        public static void Init(IServiceCollection services)
        {
            services.AddTransient<IImageFilter, GreyscaleImageFilter>();
        }
    }
}
