using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileUploadApp.File.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class FileController : ControllerBase
    {

        private readonly ILogger<IFilesManagement> _logger;
        private readonly IFilesManagement _fileManagement;

        public FileController(ILogger<IFilesManagement> logger, IFilesManagement fileManagement)
        {
            _logger = logger;
            _fileManagement = fileManagement;
        }

        [HttpGet("banndWords")]
        public async Task<IActionResult> GetBannedWordsAsync()
        {
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();

            watch.Start();
            IEnumerable<string> result = await _fileManagement.GetBannedWordsAsync();
            watch.Stop();

            return new OkObjectResult(new { banndWords = result });
        }

        [HttpPost("banndWords/{wordText}")]
        public async Task<IActionResult> InsertBannedWordAsync(string wordText)
        {

            await _fileManagement.InsertBannedWord(wordText);

            return Ok();

        }
    }
}
