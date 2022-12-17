using Microsoft.AspNetCore.Http;

namespace NewsEdge.Utilities.Image;

public static class ImageValidator
{
    public static bool IsValid(this IFormFile img)
    {
        string extension = Path.GetExtension(img.FileName);
        return extension switch
        {
            ".png" => true,
            ".jpg" => true,
            _ => false
        };
    }
}
