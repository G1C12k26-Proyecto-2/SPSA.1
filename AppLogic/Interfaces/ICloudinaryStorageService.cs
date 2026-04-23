using API.DTO.CloudinaryDTOs;

namespace API.Interfaces
{
    public interface ICloudinaryStorageService
    {
        Task<FileResponseDTO> UploadImageAsync(Stream fileStream, string fileName, string? folder = null);
        Task<FileResponseDTO> UploadFileAsync(Stream fileStream, string fileName, string? folder = null);
        Task<bool> DeleteFileAsync(string publicId);
        Task<List<FileResponseDTO>> UploadMultipleFilesAsync(List<(Stream Stream, string FileName)> files, string? folder = null);
    }
}