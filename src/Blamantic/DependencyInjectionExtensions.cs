using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace BlamanticUI
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddBUI(this IServiceCollection services)
        {
            services.AddScoped<IDialogService, DialogService>();
            services.AddScoped<IToastService, ToastService>();
            return services;
        }
    }
}
