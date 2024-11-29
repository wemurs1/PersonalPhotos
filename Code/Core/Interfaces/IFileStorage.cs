namespace Core.Interfaces;

public interface IFileStorage
{
    Task StoreFile(IFormFile file, string key);
}