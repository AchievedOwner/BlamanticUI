using Microsoft.Extensions.DependencyInjection;

namespace BlamanticUI
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddBlamanticUI(this IServiceCollection services)
        {
            services.AddScoped<IDialogService, DialogService>();
            services.AddScoped<IToastService, ToastService>();
            return services;
        }
    }
}
