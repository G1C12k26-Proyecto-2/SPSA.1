namespace API.DTO.CloudinaryDTOs
{
    public class UploadFileDTO
    {
        public string? FileName { get; set; }
        public string? Folder { get; set; } // Carpeta opcional en Cloudinary
    }
}