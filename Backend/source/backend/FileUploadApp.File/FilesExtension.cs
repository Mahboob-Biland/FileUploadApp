using FileUploadApp.File.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace FileUploadApp.File
{
    public static class FilesExtension
    {
        public static IServiceCollection AddFilesInternalServices(this IServiceCollection services)
        {
            services.AddScoped<IFilesManagement, FileManagement>();
            services.AddScoped<IBannedWords, BannedWords>();
            return services;
        }
    }
}
