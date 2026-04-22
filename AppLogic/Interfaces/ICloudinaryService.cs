using Microsoft.AspNetCore.Http;

namespace AppLogic.Interfaces
{
    public interface ICloudinaryService
    {
        Task<string> UploadImageAsync(IFormFile file, string folder = "solicitudes");
        Task<string> UploadImageFromBase64Async(string base64Content, string fileName, string folder = "solicitudes");
        Task<bool> DeleteImageAsync(string publicId);
        string GetPublicIdFromUrl(string url);
    }
}