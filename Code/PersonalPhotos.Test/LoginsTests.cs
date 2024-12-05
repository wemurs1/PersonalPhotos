namespace PersonalPhotos.Test;

public class LoginsTests
{
    private readonly LoginsController _loginsController;
    private readonly Mock<ILogins> _logins;
    private readonly Mock<IHttpContextAccessor> _contextAccessor;
    public LoginsTests()
    {
        _logins = new Mock<ILogins>();
        var session = Mock.Of<ISession>();
        var httpContext = Mock.Of<HttpContext>(x => x.Session == session);
        _contextAccessor = new Mock<IHttpContextAccessor>();
        _contextAccessor.Setup(x => x.HttpContext).Returns(httpContext);

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

    [Fact]
    public async Task Login_GivenModelStateInvalid_ReturnLoginView()
    {
        _loginsController.ModelState.AddModelError("Test", "Test");
        var result = await _loginsController.Login(Mock.Of<LoginViewModel>()) as ViewResult;
        Assert.Equal("Login", result!.ViewName, ignoreCase: true);
    }

    [Fact]
    public async Task Login_GivenCorrectPassword_RedirectToDisplayAction()
    {
        const string password = "123";
        var modelview = Mock.Of<LoginViewModel>(x => x.Email == "a@b.com" && x.Password == password);
        var model = Mock.Of<User>(x => x.Password == password);

        _logins.Setup(x => x.GetUser(It.IsAny<string>())).ReturnsAsync(model);

        var result = await _loginsController.Login(modelview);
        Assert.IsType<RedirectToActionResult>(result);
    }
}
