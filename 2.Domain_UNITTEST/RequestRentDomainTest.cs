using _2.Domain;
using _3.Data;
using _3.Data.Model;
using Moq;

namespace _2.Domain_UNITTEST;

public class RequestRentDomainTest
{
    [Fact]
    public void CreateRequestRent_ValidRequest_ReturnsTrue()
    {
        // Arrange
        var mockRequestRentData = new Mock<IRequestRentData>();
        var requestRent = new RequestRent(); 

        mockRequestRentData.Setup(repo => repo.CreateRequestRent(requestRent)).Returns(true);

        var requestRentDomain = new RequestRentDomain(mockRequestRentData.Object);

        // Act
        var actualResult = requestRentDomain.CreateRequestRent(requestRent);

        // Assert
        Assert.True(actualResult);
    }
}