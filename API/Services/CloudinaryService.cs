using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using DTO;
using Microsoft.Extensions.Options;
using AppLogic.Interfaces;  // ← Cambiar a AppLogic.Interfaces

namespace API.Services
{
    public class CloudinaryService : ICloudinaryService  // ← ICloudinaryService de AppLogic
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryService(IOptions<CloudinarySettings> config)
        {
            var account = new Account(
                config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.ApiSecret
            );
            _cloudinary = new Cloudinary(account);
            _cloudinary.Api.Secure = true;
        }

        public async Task<string> UploadImageFromBase64Async(string base64Content, string fileName, string folder = "solicitudes")
        {
            if (string.IsNullOrEmpty(base64Content))
                return null;

            var bytes = Convert.FromBase64String(base64Content);
            using var stream = new MemoryStream(bytes);

            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(fileName, stream),
                Folder = folder,
                UseFilename = true,
                UniqueFilename = true,
                Overwrite = false
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            if (uploadResult.Error != null)
                throw new Exception($"Error al subir imagen: {uploadResult.Error.Message}");

            return uploadResult.SecureUrl.ToString();
        }
    }
}