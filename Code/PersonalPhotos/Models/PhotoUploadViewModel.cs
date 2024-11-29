namespace PersonalPhotos.Models;

public class PhotoUploadViewModel
{
    [Required(ErrorMessage = "Please enter a description.")]
    public string Description { get; set; } = default!;

    [Required(ErrorMessage = "Please choose a photo!")]
    public IFormFile File { get; set; } = default!;
}