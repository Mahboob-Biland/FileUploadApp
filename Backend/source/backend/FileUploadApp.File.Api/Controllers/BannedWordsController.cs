using FileUploadApp.Store;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileUploadApp.File.Api.Controllers
{
    [ApiController]
    [Route("api/bannedWords")]
    public class BannedWordsController : ControllerBase
    {

        private readonly ILogger<IBannedWords> _logger;
        private readonly IBannedWords _bannedWords;

        public BannedWordsController(ILogger<IBannedWords> logger, IBannedWords bannedWords)
        {
            _logger = logger;
            _bannedWords = bannedWords;
        }

        [HttpGet(Name = nameof(GetBannedWordsAsync))]
        public async Task<IActionResult> GetBannedWordsAsync()
        {
            IEnumerable<IBannedWordsData> result = await _bannedWords.GetBannedWordsAsync();

            return new OkObjectResult(new { banndWords = result });
        }

        [HttpPost(Name = nameof(InsertBannedWordAsync))]
        public async Task<IActionResult> InsertBannedWordAsync([FromBody] dynamic body)
        {
            try
            {
                dynamic postObject = JObject.Parse(body.ToString());
                dynamic bannedWord = postObject["bannedWord"];

                if (bannedWord == null)
                {
                    return BadRequest();
                }

                bool result = await _bannedWords.InsertBannedWord(bannedWord.ToString());

                if (result)
                {
                    return Ok(new { message = "Added Successfully" });
                }
                else
                {
                    return BadRequest(new { message = "A problem occured while adding new Banned Word" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = "A problem occured while adding new Banned Word" + ex.Message
                });
            }

        }

        [HttpPut(Name = nameof(UpdateBannedWordAsync))]
        public async Task<IActionResult> UpdateBannedWordAsync([FromBody] dynamic body)
        {
            try
            {
                dynamic postObject = JObject.Parse(body.ToString());
                dynamic bannedWord = postObject["bannedWord"];
                dynamic id = postObject["id"];
                if (bannedWord == null || id == null)
                {
                    return BadRequest();
                }

                bool result = await _bannedWords.UpdateBannedWord(new BannedWordsData() { Id = id, WordText = bannedWord });

                if (result)
                {
                    return Ok(new { message = "Updated Successfully" });
                }
                else
                {
                    return BadRequest(new { message = "A problem occured while updating banned word" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "A problem occured while updating banned word. Error: " + ex.Message });
            }
        }

        [HttpDelete("{id}", Name = nameof(DeleteBannedWordAsync))]
        public async Task<IActionResult> DeleteBannedWordAsync([FromRoute] int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }

                bool result = await _bannedWords.DeleteBannedWord(id);

                if (result)
                {
                    return Ok(new { message = "Deleted Successfully" });
                }
                else
                {
                    return BadRequest(new { message = "A problem occured while deleting banned word" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "A problem occured while deleting banned word. Error: " + ex.Message });
            }
        }
    }
}
