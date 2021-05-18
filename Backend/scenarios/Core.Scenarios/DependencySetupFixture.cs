using FileUploadApp.File;
using FileUploadApp.Store;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Scenarios
{
    public class DependencySetupFixture
    {
        public DependencySetupFixture()
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddFilesInternalServices();
            serviceCollection.AddStoreInternalServices();
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        public ServiceProvider ServiceProvider { get; private set; }
    }
}
