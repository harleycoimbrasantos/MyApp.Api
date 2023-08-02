using MyApp.Services.Interfaces;

namespace MyApp.Services.Service
{
    public class FileManagementService : IFileManagementService
    {

        public async Task<bool> WriteFileAsync(string filePath, byte[] file)
        {
            if (string.IsNullOrEmpty(filePath))
                return false;

            _ = Directory.CreateDirectory(Path.GetDirectoryName(filePath));

            using (Stream stream = new FileStream(filePath, FileMode.Create))
            {
                await stream.WriteAsync(file.AsMemory(0, file.Length));
            }

            return File.Exists(filePath);
        }
    }
}
