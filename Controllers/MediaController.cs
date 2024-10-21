using Media_API_project.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Media_API_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private readonly IMediaService _mediaService;

        public MediaController(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadMedia(IFormFile file)
        {
            var result = await _mediaService.UploadMediaAsync(file);
            return Ok(result);
        }

        [HttpGet("download/{id}")]
        public async Task<IActionResult> DownloadMedia(Guid id)
        {
            var result = await _mediaService.DownloadMediaAsync(id);
            if (result == null) return NotFound();

            var memory = new MemoryStream();
            using (var stream = new FileStream(result.FilePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }

            memory.Position = 0;
            return File(memory, GetContentType(result.FilePath), Path.GetFileName(result.FilePath));
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllMedia()
        {
            var result = await _mediaService.GetAllMediaAsync();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedia(Guid id)
        {
            await _mediaService.DeleteMediaAsync(id);
            return NoContent();
        }

        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".mp4", "video/mp4"},
                {".mp3", "audio/mpeg"},
                {".wav", "audio/wav"},
                {".avi", "video/x-msvideo"},
                {".png", "image/png"},  
                {".jpg", "image/jpeg"}, 
                {".jpeg", "image/jpeg"}, 
                {".gif", "image/gif"}, 
                {".pdf", "application/pdf"}, 
                {".txt", "text/plain"}, 
                {".doc", "application/msword"}, 
                {".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document"}
            };
        }


    }
}
