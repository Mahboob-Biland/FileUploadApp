using FileUploadApp.Store;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FileUploadApp.File.Api.Controllers
{
    [ApiController]
    [Route("api/files")]
    public class FileController : ControllerBase
    {

        private readonly ILogger<IFilesManagement> _logger;
        private readonly IFilesManagement _fileManagement;

        public FileController(ILogger<IFilesManagement> logger, IFilesManagement fileManagement)
        {
            _logger = logger;
            _fileManagement = fileManagement;
        }

        [HttpPost("uploadFile")]
        public async Task<IActionResult> UploadFileAsync()
        {
            HttpRequest request = HttpContext.Request;
            IFormFile postedFile = request.Form.Files[0];
            string pathToSave = Path.GetFullPath(Directory.GetCurrentDirectory() + "..\\..\\..\\..\\..\\Resources");
            if (postedFile.Length > 0)
            {
                if (!Directory.Exists(pathToSave))
                {
                    // Try to create the directory.
                    DirectoryInfo di = Directory.CreateDirectory(pathToSave);
                }
                string fileName = ContentDispositionHeaderValue.Parse(postedFile.ContentDisposition).FileName.Trim('"');
                string fullPath = Path.Combine(pathToSave, fileName);
                using (FileStream stream = new FileStream(fullPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                IEnumerable<string> bannedWordsList = await _fileManagement.InsertFileInfo(fullPath);

                return Ok(new { bannedWordsList });
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetFilesAsync()
        {

            IEnumerable<IFileInfoData> result = await _fileManagement.GetFileInfoAsync();

            return new OkObjectResult(new { fileInfo = result });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFile([FromRoute] int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }

                bool result = _fileManagement.DeleteFileInfo(id);

                if (result)
                {
                    return Ok(new { message = "Updated Successfully" });
                }
                else
                {
                    return BadRequest(new { message = "A problem occured while deleting file" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "A problem occured while deleting file. Error: " + ex.Message });
            }
        }
    }
}
