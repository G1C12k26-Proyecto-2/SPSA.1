using DTO;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CloudinaryController : ControllerBase
    {
        private readonly ICloudinaryStorageService _cloudinaryService;

        public CloudinaryController(ICloudinaryStorageService cloudinaryService)
        {
            _cloudinaryService = cloudinaryService;
        }

        [HttpPost("upload-image")]
        public async Task<IActionResult> UploadImage(IFormFile file, [FromQuery] string? folder = null)
        {
            if (file == null || file.Length == 0)
                return BadRequest(new { message = "No file provided" });

            using var stream = file.OpenReadStream();
            var result = await _cloudinaryService.UploadImageAsync(stream, file.FileName, folder);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("upload-file")]
        public async Task<IActionResult> UploadFile(IFormFile file, [FromQuery] string? folder = null)
        {
            if (file == null || file.Length == 0)
                return BadRequest(new { message = "No file provided" });

            using var stream = file.OpenReadStream();
            var result = await _cloudinaryService.UploadFileAsync(stream, file.FileName, folder);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("upload-multiple")]
        public async Task<IActionResult> UploadMultipleFiles(List<IFormFile> files, [FromQuery] string? folder = null)
        {
            if (files == null || files.Count == 0)
                return BadRequest(new { message = "No files provided" });

            var fileList = new List<(Stream Stream, string FileName)>();
            foreach (var file in files)
            {
                var stream = new MemoryStream();
                await file.CopyToAsync(stream);
                stream.Position = 0;
                fileList.Add((stream, file.FileName));
            }

            var results = await _cloudinaryService.UploadMultipleFilesAsync(fileList, folder);

            return Ok(results);
        }

        [HttpDelete("delete/{publicId}")]
        public async Task<IActionResult> DeleteFile(string publicId)
        {
            var result = await _cloudinaryService.DeleteFileAsync(publicId);

            if (!result)
                return BadRequest(new { message = "Failed to delete file" });

            return Ok(new { message = "File deleted successfully", success = true });
        }
    }
}