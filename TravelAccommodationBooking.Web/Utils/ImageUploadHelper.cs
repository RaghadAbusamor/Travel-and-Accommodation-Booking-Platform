
using TravelAccommodationBooking.BLL.DTO.Image;
using TravelAccommodationBooking.Model.Entities.Hotel;
using TravelAccommodationBooking.Model.Enums.Image;

namespace TravelAccommodationBooking.Web.Utils;

public static class ImageUploadHelper
{
    public static async Task<ImageCreationDto> CreateImageCreationDto(Guid entityId, IFormFile file, ImageCategory type)
    {
        using var memoryStream = new MemoryStream();
        await file.CopyToAsync(memoryStream);
        var base64Content = Convert.ToBase64String(memoryStream.ToArray());
        var imageFormat = GetImageFormat(file.ContentType);
        if (imageFormat == null)
            throw new NotSupportedException($"The {file.ContentType.Split('/')[1]} format is not supported");

        return new ImageCreationDto
        {
            EntityId = entityId,
            Base64Content = base64Content,
            Format = imageFormat.Value,
            Type = type
        };
    }

    private static ImageFormat? GetImageFormat(string contentType)
    {
        return contentType.ToLower() switch
        {
            "image/jpeg" => ImageFormat.Jpeg,
            "image/png" => ImageFormat.Png,
            _ => null
        };
    }
}