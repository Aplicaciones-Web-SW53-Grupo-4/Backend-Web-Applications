using _2.Domain;
using _3.Data.Model;
using AutoMapper.Configuration.Annotations;
using NSubstitute;

namespace _2.Domain_UNITTEST;

public class UserDomainTest
{
    [Fact]
    public void Create_Valid_User_ResultTrue()
    {
        //Arrange
        User user = new User()
        {
            Name="Erick ",
            Lastname = "Ruiz",
            phone ="984344322",
        };

        var userdatamock = Substitute.For<IUserData>();
        userdatamock.GetByName(user.Name).Returns((User)null);
        userdatamock.Create(user).Returns(true);
        UserDomain userDomain = new UserDomain(userdatamock);
        
        //Act
        var actualResult = userDomain.Create(user);
        
        //Assert
        Assert.True(actualResult);
    }
}