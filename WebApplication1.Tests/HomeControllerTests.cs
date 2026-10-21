using Microsoft.AspNetCore.Mvc;
using WebApplication1.Controllers;

namespace WebApplication1.Tests;

public class HomeControllerTests
{
    [Fact]
    public void About_ReturnsViewResult_WithDefaultViewAndNoModel()
    {
        var controller = new HomeController();

        var result = Assert.IsType<ViewResult>(controller.About());

        Assert.Null(result.ViewName);
        Assert.Null(result.Model);
    }
}
