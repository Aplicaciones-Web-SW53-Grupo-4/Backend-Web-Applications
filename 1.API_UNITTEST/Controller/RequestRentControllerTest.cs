using _1.API.Controllers;
using _1.API.Request;
using _1.API.Response;
using _2.Domain;
using _3.Data;
using _3.Data.Model;
using AutoMapper;
using Moq;

namespace _1.API_UNITTEST;

public class RequestRentControllerTest
{
        [Fact]
        public void GetAllRequestRentByIdForOwner_ReturnsCollectionOfRequestRentOwnerResponse()
        {
            // Arrange
            string ownerId = "1";
            var mockRequestRentData = new Mock<IRequestRentData>();
            var mockRequestRentDomain = new Mock<IRequestRentDomain>();
            var mockMapper = new Mock<IMapper>();

            var controller = new RequestRentController(mockRequestRentData.Object, mockRequestRentDomain.Object, mockMapper.Object);

            var requestRentList = new List<RequestRent>
            {
                new RequestRent { /* Initialize properties as needed */ },
                new RequestRent { /* Initialize properties as needed */ },
            };
            mockRequestRentDomain.Setup(repo => repo.GetAllRequestRentByIdForOwner(ownerId)).ReturnsAsync(requestRentList);
            mockMapper.Setup(m => m.Map<List<RequestRentOwnerResponse>>(It.IsAny<List<RequestRent>>()))
                      .Returns((List<RequestRent> source) => source.Select(item => new RequestRentOwnerResponse()).ToList());

            // Act
            var result = controller.GetAllRequestRentByIdForOwner(ownerId);

            // Assert
            Assert.IsType<List<RequestRentOwnerResponse>>(result);
        }

        [Fact]
        public void GetAllRequestRentByIdForTenant_ReturnsListOfRequestRent()
        {
            // Arrange
            string tenantId = "1";
            var mockRequestRentData = new Mock<IRequestRentData>();
            var mockRequestRentDomain = new Mock<IRequestRentDomain>();
            var mockMapper = new Mock<IMapper>();

            var controller = new RequestRentController(mockRequestRentData.Object, mockRequestRentDomain.Object, mockMapper.Object);

            var requestRentList = new List<RequestRent>
            {
                new RequestRent { /* Initialize properties as needed */ },
                new RequestRent { /* Initialize properties as needed */ },
            };

            mockRequestRentDomain.Setup(repo => repo.GetAllRequestRentByIdForTenant(tenantId)).ReturnsAsync(requestRentList);

            // Act
            var result = controller.GetAllRequestRentByIdForTenant(tenantId);

            // Assert
            Assert.IsType<List<RequestRent>>(result);
        }

        [Fact]
        public void Post_ReturnsTrue()
        {
            // Arrange
            var mockRequestRentData = new Mock<IRequestRentData>();
            var mockRequestRentDomain = new Mock<IRequestRentDomain>();
            var mockMapper = new Mock<IMapper>();

            var controller = new RequestRentController(mockRequestRentData.Object, mockRequestRentDomain.Object, mockMapper.Object);

            var rentRequest = new RentRequest
            {
                // Initialize properties as needed
            };

            mockMapper.Setup(m => m.Map<RequestRent>(rentRequest)).Returns(new RequestRent());
            mockRequestRentDomain.Setup(repo => repo.CreateRequestRent(It.IsAny<RequestRent>())).Returns(true);

            // Act
            var result = controller.Post(rentRequest);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Put_ReturnsTrue()
        {
            // Arrange
            string requestId = "1";
            var mockRequestRentData = new Mock<IRequestRentData>();
            var mockRequestRentDomain = new Mock<IRequestRentDomain>();
            var mockMapper = new Mock<IMapper>();

            var controller = new RequestRentController(mockRequestRentData.Object, mockRequestRentDomain.Object, mockMapper.Object);

            var requestRent = new RequestRent
            {
                // Initialize properties as needed
            };

            mockRequestRentDomain.Setup(repo => repo.UpdateRequestRent(requestRent, requestId)).Returns(true);
    
            var updateRequestRentRequest = new UpdateRequestRentRequest
            {
                // Initialize properties as needed
            };
            // Act
            var result = controller.Put(requestId, updateRequestRentRequest);

            // Assert
            Assert.True(result);
        }
}