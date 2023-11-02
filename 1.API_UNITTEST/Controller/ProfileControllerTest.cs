using _1.API.Controllers;
using _1.API.Response;
using _2.Domain;
using _3.Data.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace _1.API_UNITTEST;

public class ProfileControllerTest
{
        [Fact]
        public void Get_ReturnsOkResult_WhenUserExists()
        {
            // Arrange
            int userId = 1;
            var mockUserData = new Mock<IUserData>();
            var mockUserDomain = new Mock<IUserDomain>();
            var mockMapper = new Mock<IMapper>();

            var user = new User
            {
                Id = userId,
                UserType = UserType.Arrendatario,
            };

            mockUserData.Setup(repo => repo.GetById(userId)).Returns(user);
            mockMapper.Setup(m => m.Map<ProfileResponseOwner>(user)).Returns(new ProfileResponseOwner());

            var controller = new ProfileController(mockUserData.Object, mockUserDomain.Object, mockMapper.Object);

            // Act
            var result = controller.Get(userId);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<ProfileResponseOwner>(okResult.Value);
        }

        
        [Fact]
        public void Get_ReturnsNotFound_WhenUserDoesNotExist()
        {
            // Arrange
            int userId = 1;
            var mockUserData = new Mock<IUserData>();
            var mockUserDomain = new Mock<IUserDomain>();
            var mockMapper = new Mock<IMapper>();

            mockUserData.Setup(repo => repo.GetById(userId)).Returns((User)null);

            var controller = new ProfileController(mockUserData.Object, mockUserDomain.Object, mockMapper.Object);

            // Act
            var result = controller.Get(userId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
}