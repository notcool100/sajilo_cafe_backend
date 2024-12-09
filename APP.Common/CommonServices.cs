using APP.COMMON;
using Microsoft.Extensions.DependencyInjection;

using System.ComponentModel.Design;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class CommonServiceCollection
    {
        public static IServiceCollection AddCommonServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
