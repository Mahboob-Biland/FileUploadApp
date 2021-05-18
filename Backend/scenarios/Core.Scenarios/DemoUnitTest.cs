using FileUploadApp.File;
using FileUploadApp.Store;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Core.Scenarios
{
    public class DemoUnitTest : IClassFixture<DependencySetupFixture>
    {
        private readonly ServiceProvider _serviceProvide;
        public DemoUnitTest(DependencySetupFixture dependencySetupFixture)
        {
            _serviceProvide = dependencySetupFixture.ServiceProvider;
        }

        [Fact]
        public async Task AddBannedWordTestAsync()
        {
            using (IServiceScope scope = _serviceProvide.CreateScope())
            {
                IBannedWords bannedWordWords = scope.ServiceProvider.GetService<IBannedWords>();
                string wordText = "TestBannedWord";
                bool result = await bannedWordWords.InsertBannedWord(wordText);

                Assert.True(result);
            }
        }

        [Fact]
        public async Task GetBannedWordTestAsync()
        {
            using (IServiceScope scope = _serviceProvide.CreateScope())
            {
                IBannedWords bannedWordRepo = scope.ServiceProvider.GetService<IBannedWords>();
                IEnumerable<IBannedWordsData> bannedWordsList = await bannedWordRepo.GetBannedWordsAsync();

                Assert.True(bannedWordsList.Count() > 0);
            }
        }

        [Fact]
        public async Task UpdateAndDeleteTestAsync()
        {
            using (IServiceScope scope = _serviceProvide.CreateScope())
            {
                IBannedWords bannedWordRepo = scope.ServiceProvider.GetService<IBannedWords>();
                IEnumerable<IBannedWordsData> bannedWordsList = await bannedWordRepo.GetBannedWordsAsync();

                string updateTest = "SomeNewText";
                IBannedWordsData firstWord = bannedWordsList.FirstOrDefault();
                firstWord.WordText = updateTest;
                await bannedWordRepo.UpdateBannedWord(firstWord);

                bannedWordsList = await bannedWordRepo.GetBannedWordsAsync();
                firstWord = bannedWordsList.FirstOrDefault();

                int wordCount = bannedWordsList.Count();

                Assert.True(firstWord.WordText == updateTest);

                await bannedWordRepo.DeleteBannedWord(firstWord.Id);

                Assert.True(bannedWordRepo.GetBannedWordsAsync().Result.Count() == wordCount - 1);
            }
        }
    }
}
