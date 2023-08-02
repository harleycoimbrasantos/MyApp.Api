namespace MyApp.Services.Interfaces
{
    public interface IFileManagementService
    {
        Task<bool> WriteFileAsync(string filePath, byte[] file);
    }
}
