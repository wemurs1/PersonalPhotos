namespace PersonalPhotos.Test;

public class PhotosTests
{
    [Fact]
    public async Task Upload_GivenFileName_ReturnDisplayAction()
    {
        // Arrange
        var session = Mock.Of<ISession>();
        session.Set("User", Encoding.UTF8.GetBytes("a@b.com"));
        var context = Mock.Of<HttpContext>(x => x.Session == session);
        var accessor = Mock.Of<IHttpContextAccessor>(x => x.HttpContext == context);

        var fileStorage = Mock.Of<IFileStorage>();
        var keyGen = Mock.Of<IKeyGenerator>();
        var photoMetadata = Mock.Of<IPhotoMetaData>();

        var formFile = Mock.Of<IFormFile>();
        var model = Mock.Of<PhotoUploadViewModel>(x => x.File == formFile);

        var controller = new PhotosController(keyGen, accessor, photoMetadata, fileStorage);

        // Act
        var result = await controller.Upload(model) as RedirectToActionResult;

        // Assert
        Assert.Equal("Display", result!.ActionName, ignoreCase: true);
    }
}
