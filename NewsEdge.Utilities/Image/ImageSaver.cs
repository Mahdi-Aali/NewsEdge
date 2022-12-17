using Microsoft.AspNetCore.Http;

namespace NewsEdge.Utilities.Image;

public static class ImageSaver
{
    public static readonly string basePath = Path.Combine(Directory.GetCurrentDirectory(), "Images");
    public static async Task<bool> SaveAsync(this IFormFile img, string name, ImageSaverPath path)
    {
        string imagePath = path switch
        {
            ImageSaverPath.UserProfile => Path.Combine(basePath, "Users", "UserProfile", name),
            ImageSaverPath.NewsImage => Path.Combine(basePath, "News", name),
            _ => throw new NotImplementedException()
        };

        using (FileStream file = File.Create(imagePath))
        {
            try
            {
                await img.CopyToAsync(file);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    public static void RemoveCurrentImage(ImageSaverPath path, string imageName)
    {
        string imagePath = path switch
        {
            ImageSaverPath.UserProfile => Path.Combine(basePath, "Users", "UserProfile", imageName),
            ImageSaverPath.NewsImage => Path.Combine(basePath, "News", imageName),
            _ => throw new NotImplementedException()
        };
        if (File.Exists(imagePath))
        {
            File.Delete(imagePath);
        }
    }
}
