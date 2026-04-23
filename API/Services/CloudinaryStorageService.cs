using API.DTO.CloudinaryDTOs;
using API.Interfaces;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace API.Services
{
    public class CloudinaryStorageService : ICloudinaryStorageService
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryStorageService(Cloudinary cloudinary)
        {
            _cloudinary = cloudinary;
        }

        public async Task<FileResponseDTO> UploadImageAsync(Stream fileStream, string fileName, string? folder = null)
        {
            return await UploadToCloudinary(fileStream, fileName, folder, true);
        }

        public async Task<FileResponseDTO> UploadFileAsync(Stream fileStream, string fileName, string? folder = null)
        {
            return await UploadToCloudinary(fileStream, fileName, folder, false);
        }

        private async Task<FileResponseDTO> UploadToCloudinary(Stream fileStream, string fileName, string? folder, bool isImage)
        {
            var response = new FileResponseDTO();

            if (fileStream == null || fileStream.Length == 0)
            {
                response.Success = false;
                response.Message = "No file stream provided";
                return response;
            }

            try
            {
                fileStream.Position = 0;

                if (isImage)
                {
                    var uploadParams = new ImageUploadParams
                    {
                        File = new FileDescription(fileName, fileStream),
                        Folder = folder ?? "general",
                        UseFilename = true,
                        UniqueFilename = true,
                        Overwrite = false
                    };

                    var uploadResult = await _cloudinary.UploadAsync(uploadParams);

                    if (uploadResult.Error != null)
                    {
                        response.Success = false;
                        response.Message = uploadResult.Error.Message;
                        return response;
                    }

                    response.PublicId = uploadResult.PublicId;
                    response.Url = uploadResult.Url?.ToString() ?? string.Empty;
//                    response.SecureUrl = uploadResult.SecureUrl?.ToString() ?? string.Empty;
//                    response.Format = uploadResult.Format ?? string.Empty;
//                    response.Size = uploadResult.Bytes.GetValueOrDefault(0); // Fixed
//                    response.Width = uploadResult.Width.GetValueOrDefault(0); // Fixed
//                    response.Height = uploadResult.Height.GetValueOrDefault(0); // Fixed
//                    response.CreatedAt = DateTime.UtcNow;
                    response.Success = true;
                }
                else
                {
                    var uploadParams = new RawUploadParams
                    {
                        File = new FileDescription(fileName, fileStream),
                        Folder = folder ?? "documents",
                        UseFilename = true,
                        UniqueFilename = true,
                        Overwrite = false
                    };

                    var uploadResult = await _cloudinary.UploadAsync(uploadParams);

                    if (uploadResult.Error != null)
                    {
                        response.Success = false;
                        response.Message = uploadResult.Error.Message;
                        return response;
                    }

                    response.PublicId = uploadResult.PublicId;
                    response.Url = uploadResult.Url?.ToString() ?? string.Empty;
//                    response.SecureUrl = uploadResult.SecureUrl?.ToString() ?? string.Empty;
//                    response.Format = Path.GetExtension(fileName).TrimStart('.');
//                    response.Size = uploadResult.Bytes.GetValueOrDefault(0); // Fixed
//                    response.CreatedAt = DateTime.UtcNow;
                    response.Success = true;
                }

                return response;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Error uploading file: {ex.Message}";
                return response;
            }
        }

        public async Task<bool> DeleteFileAsync(string publicId)
        {
            try
            {
                var deleteParams = new DeletionParams(publicId);
                var result = await _cloudinary.DestroyAsync(deleteParams);
                return result.Result == "ok";
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<FileResponseDTO>> UploadMultipleFilesAsync(List<(Stream Stream, string FileName)> files, string? folder = null)
        {
            var results = new List<FileResponseDTO>();

            foreach (var file in files)
            {
                var isImage = Path.GetExtension(file.FileName).ToLower() is ".jpg" or ".jpeg" or ".png" or ".gif" or ".bmp" or ".webp";
                var result = await UploadToCloudinary(file.Stream, file.FileName, folder, isImage);
                results.Add(result);
            }

            return results;
        }
    }
}