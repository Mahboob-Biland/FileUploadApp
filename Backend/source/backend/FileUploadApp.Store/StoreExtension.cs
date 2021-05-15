using FileUploadApp.Store.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace FileUploadApp.Store
{
    public static class StoreExtension
    {
        public static IServiceCollection AddStoreInternalServices(this IServiceCollection services)
        {
            services.AddScoped<IFilesRepository, FilesRepository>();
            return services;
        }
    }
}
