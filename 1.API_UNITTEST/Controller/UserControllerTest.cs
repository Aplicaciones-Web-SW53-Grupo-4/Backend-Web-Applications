using _1.API.Controllers;
using _1.API.Request;
using _2.Domain;
using _3.Data.Model;
using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;

namespace _1.API_UNITTEST;

public class UserControllerTest
{
        [Fact]
        public void Register_ValidUser_ReturnsOkResult()
        {
            // Arrange
            var mockUserData = new Mock<IUserData>();
            var mockUserDomain = new Mock<IUserDomain>();
            var mockMapper = new Mock<IMapper>();
            var mockConfiguration = new Mock<IConfiguration>();

            var controller = new UserController(mockUserData.Object, mockUserDomain.Object, mockMapper.Object, mockConfiguration.Object);

            var userRegisterRequest = new UserRegisterRequest
            {
                // Initialize properties as needed
            };

            mockMapper.Setup(m => m.Map<UserRegisterRequest, User>(userRegisterRequest)).Returns(new User());
            mockUserDomain.Setup(repo => repo.Create(It.IsAny<User>())).Returns(true);

            // Act
            var result = controller.Register(userRegisterRequest);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Register_InvalidUser_ReturnsBadRequestResult()
        {
            // Arrange
            var mockUserData = new Mock<IUserData>();
            var mockUserDomain = new Mock<IUserDomain>();
            var mockMapper = new Mock<IMapper>();
            var mockConfiguration = new Mock<IConfiguration>();

            var controller = new UserController(mockUserData.Object, mockUserDomain.Object, mockMapper.Object, mockConfiguration.Object);

            var userRegisterRequest = new UserRegisterRequest
            {
                // Initialize properties as needed
            };

            // Simulate ModelState validation errors
            controller.ModelState.AddModelError("PropertyName", "Error message");

            // Act
            var result = controller.Register(userRegisterRequest);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void Login_ValidCredentials_ReturnsOkResultWithToken()
        {
            // Arrange
            var mockUserData = new Mock<IUserData>();
            var mockUserDomain = new Mock<IUserDomain>();
            var mockMapper = new Mock<IMapper>();
            var mockConfiguration = new Mock<IConfiguration>();

            var controller = new UserController(mockUserData.Object, mockUserDomain.Object, mockMapper.Object, mockConfiguration.Object);

            var userLoginRequest = new UserLoginRequest
            {
                Username = "testuser",
                Password = "password",
            };

            var user = new User
            {
                Id = "1",
                // Set other properties as needed
            };

            mockUserDomain.Setup(repo => repo.Authenticate(userLoginRequest.Username, userLoginRequest.Password, userLoginRequest.UserType)).Returns(user);
            mockConfiguration.Setup(c => c["Jwt:Key"]).Returns("YourSecretKey");
            mockConfiguration.Setup(c => c["Jwt:Issuer"]).Returns("YourIssuer");
            mockConfiguration.Setup(c => c["Jwt:Audience"]).Returns("YourAudience");
            mockConfiguration.Setup(c => c["Jwt:DurationInMinutes"]).Returns("60");

            // Act
            var result = controller.Login(userLoginRequest);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<int>(okResult.Value); // Assuming your token is an integer
        }

        [Fact]
        public void Login_InvalidCredentials_ReturnsUnauthorizedResult()
        {
            // Arrange
            var mockUserData = new Mock<IUserData>();
            var mockUserDomain = new Mock<IUserDomain>();
            var mockMapper = new Mock<IMapper>();
            var mockConfiguration = new Mock<IConfiguration>();

            var controller = new UserController(mockUserData.Object, mockUserDomain.Object, mockMapper.Object, mockConfiguration.Object);

            var userLoginRequest = new UserLoginRequest
            {
                Username = "testuser",
                Password = "password",
            };

            mockUserDomain.Setup(repo => repo.Authenticate(userLoginRequest.Username, userLoginRequest.Password,userLoginRequest.UserType)).Returns((User)null);

            // Act
            var result = controller.Login(userLoginRequest);

            // Assert
            Assert.IsType<UnauthorizedObjectResult>(result);
        }
}