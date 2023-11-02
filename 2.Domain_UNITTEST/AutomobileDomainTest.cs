using _2.Domain;
using _3.Data.Model;
using Moq;

namespace _2.Domain_UNITTEST;

public class AutomobileDomainTest
{
    [Fact]
    public void Create_ValidAutomobile_ReturnsTrue()
    {
        // Arrange
        var mockAutomobileData = new Mock<IAutomobileData>();
        var mockUserData = new Mock<IUserData>();
        var userId = 1;
        var automobile = new Automobile();

        var user = new User
        {
            Id = userId,
            Automobiles = new List<Automobile>()
        };

        mockUserData.Setup(repo => repo.GetById(userId)).Returns(user);
        mockUserData.Setup(repo => repo.Update(user, userId)).Verifiable();

        var automobileDomain = new AutomobileDomain(mockAutomobileData.Object, mockUserData.Object);

        // Act
        var actualResult = automobileDomain.Create(automobile, userId);

        // Assert
        Assert.True(actualResult);
        mockUserData.Verify(repo => repo.Update(user, userId), Times.Once());
    }
}