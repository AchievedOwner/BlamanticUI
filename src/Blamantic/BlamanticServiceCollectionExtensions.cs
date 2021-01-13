using Microsoft.Extensions.DependencyInjection;

namespace BlamanticUI
{
    /// <summary>
    /// Represents the extensions of Blamantic-UI for instance of <see cref="IServiceCollection"/>.
    /// </summary>
    public static class BlamanticServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the blamantic UI service to <see cref="IServiceCollection"/> .
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection AddBlamanticUI(this IServiceCollection services)
        {
            services.AddScoped<IDialogService, DialogService>();
            services.AddScoped<IToastService, ToastService>();
            return services;
        }
    }
}
