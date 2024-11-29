namespace PersonalPhotos.Test;

public class LoginsTests
{
    private readonly LoginsController _loginsController;
    private readonly Mock<ILogins> _logins;
    private readonly Mock<IHttpContextAccessor> _contextAccessor;
    public LoginsTests()
    {
        _logins = new Mock<ILogins>();
        _contextAccessor = new Mock<IHttpContextAccessor>();

        _loginsController = new LoginsController(_logins.Object, _contextAccessor.Object);
    }

    [Fact]
    public void Index_GivenNoReturnUrl_ReturnLoginView()
    {
        var result = (_loginsController.Index() as ViewResult);
        // Assert.IsAssignableFrom<IActionResult>(result);
        Assert.NotNull(result);
        Assert.Equal("Login", result.ViewName, ignoreCase: true);
    }
}