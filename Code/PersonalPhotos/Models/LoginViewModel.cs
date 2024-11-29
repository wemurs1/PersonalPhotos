namespace PersonalPhotos.Models;

public class LoginViewModel
{
    [Required(ErrorMessage = "Please provide the Email address")]
    [EmailAddress]
    public string Email { get; set; } = default!;

    [Required(ErrorMessage = "Please provide password")]
    public string Password { get; set; } = default!;

    public string ReturnUrl { get; set; } = default!;
}