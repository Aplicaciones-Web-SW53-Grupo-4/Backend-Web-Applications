using _1.API.Controllers;
using _1.API.Request;
using _1.API.Response;
using _2.Domain;
using _3.Data.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace _1.API_UNITTEST;

public class AutomobileControllerTest
{
    [Fact]
    public async Task Get_ReturnsListOfAutomobile()
    {
        // Arrange
        var mockAutomobileData = new Mock<IAutomobileData>();
        var mockAutomobileDomain = new Mock<IAutomobileDomain>();
        var mockUserData = new Mock<IUserData>();
        var mockMapper = new Mock<IMapper>();

        var controller = new AutomobileController(mockAutomobileData.Object, mockAutomobileDomain.Object,
            mockMapper.Object, mockUserData.Object);

        var automobileList = new List<Automobile>
        {
            new Automobile
            {
                /* Initialize properties as needed */
            },
            new Automobile
            {
                /* Initialize properties as needed */
            },
        };

        mockAutomobileData.Setup(repo => repo.GetAllAsync()).ReturnsAsync(automobileList);

        // Act
        var result = await controller.Get();

        // Assert
        Assert.IsType<List<Automobile>>(result);
    }

    [Fact]
    public void Get_WithFilters_ReturnsSearchAutomovilFilterResponse()
    {
        // Arrange
        var mockAutomobileData = new Mock<IAutomobileData>();
        var mockAutomobileDomain = new Mock<IAutomobileDomain>();
        var mockUserData = new Mock<IUserData>();
        var mockMapper = new Mock<IMapper>();

        var controller = new AutomobileController(mockAutomobileData.Object, mockAutomobileDomain.Object, mockMapper.Object, mockUserData.Object);

        var brand = "SomeBrand";
        var model = "SomeModel";

        var automobileList = new List<Automobile>
        {
            new Automobile { Brand = "SomeBrand", Model = "SomeModel" },
            new Automobile { Brand = "AnotherBrand", Model = "AnotherModel" },
        };
        
        mockAutomobileData.Setup(repo => repo.GetBySearch(brand, model)).ReturnsAsync(automobileList);
        
        mockMapper.Setup(m => m.Map<Task<List<SearchAutomovilFilterResponse>>>(It.IsAny<Task<List<Automobile>>>()))
            .ReturnsAsync((Task<List<Automobile>> source) => source.Result.Select(item => new SearchAutomovilFilterResponse()).ToList());

        // Act
        var result = controller.Get(brand, model);

        // Assert
        Assert.IsType<OkObjectResult>(result);
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.IsType<Task<List<SearchAutomovilFilterResponse>>>(okResult.Value);
    }
    

    [Fact]
    public void Post_ValidAutomobile_ReturnsOkResult()
    {
        // Arrange
        var mockAutomobileData = new Mock<IAutomobileData>();
        var mockAutomobileDomain = new Mock<IAutomobileDomain>();
        var mockUserData = new Mock<IUserData>();
        var mockMapper = new Mock<IMapper>();

        var controller = new AutomobileController(mockAutomobileData.Object, mockAutomobileDomain.Object,
            mockMapper.Object, mockUserData.Object);

        var automobileCreateRequest = new AutomobileCreateRequest
        {
            UserId = "1",
        };

        var user = new User
        {
            // Initialize user properties
        };

        mockUserData.Setup(repo => repo.GetById(automobileCreateRequest.UserId)).Returns(user);
        mockMapper.Setup(m => m.Map<AutomobileCreateRequest, Automobile>(automobileCreateRequest))
            .Returns(new Automobile());

        mockAutomobileDomain.Setup(repo => repo.Create(It.IsAny<Automobile>(), automobileCreateRequest.UserId))
            .Returns(true);

        // Act
        var result = controller.Post(automobileCreateRequest);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void Delete_ValidId_ReturnsOkResult()
    {
        // Arrange
        var mockAutomobileData = new Mock<IAutomobileData>();
        var mockAutomobileDomain = new Mock<IAutomobileDomain>();
        var mockUserData = new Mock<IUserData>();
        var mockMapper = new Mock<IMapper>();

        var controller = new AutomobileController(mockAutomobileData.Object, mockAutomobileDomain.Object,
            mockMapper.Object, mockUserData.Object);

        var automobileId = "1";

        mockAutomobileData.Setup(repo => repo.Delete(automobileId)).Returns(true);

        // Act
        var result = controller.Delete(automobileId);

        // Assert
        Assert.IsType<OkObjectResult>(result);
    }
}
