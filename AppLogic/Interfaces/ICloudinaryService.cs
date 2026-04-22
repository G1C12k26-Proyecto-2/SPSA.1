namespace AppLogic.Interfaces
{
    public interface ICloudinaryService
    {
        Task<string> UploadImageFromBase64Async(string base64Content, string fileName, string folder = "solicitudes");
    }
}