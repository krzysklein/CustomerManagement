using Microsoft.Extensions.DependencyInjection;

namespace CustomerManagement.Infrastructure.Cryptography
{
    public class ModuleConfiguration
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<
                Domain.Core.Services.ICryptographyService,
                CryptographyService>();
        }
    }
}
