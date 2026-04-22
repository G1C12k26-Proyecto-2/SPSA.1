using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using DTO;
using Microsoft.Extensions.Options;
using API.Interfaces; 

namespace API.Services
{
    public class CloudinaryService : ICloudinaryService 
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

        public async Task<string> UploadImageAsync(IFormFile file, string folder = "solicitudes")
        {
            if (file == null || file.Length == 0)
                return null;

            using var stream = file.OpenReadStream();

            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, stream),
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

        public async Task<bool> DeleteImageAsync(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);
            var result = await _cloudinary.DestroyAsync(deleteParams);
            return result.Result == "ok";
        }

        public string GetPublicIdFromUrl(string url)
        {
            if (string.IsNullOrEmpty(url)) return null;

            var parts = url.Split('/');
            var fileName = parts[^1];
            var publicIdWithExt = string.Join("/", parts.Skip(parts.Length - 2));

            var lastDot = publicIdWithExt.LastIndexOf('.');
            return lastDot > 0 ? publicIdWithExt[..lastDot] : publicIdWithExt;
        }
    }
}