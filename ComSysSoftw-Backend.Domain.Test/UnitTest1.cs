using ComSysSoftw_Backend.Infraestructure.Interfaces;
using Infraestructure.Models;
using Moq;

namespace ComSysSoftw_Backend.Domain.Test
{
    public class UnitTest1
    {
        [Fact]
        public async Task Create_ValidUser_ReturnSuccess()
        {
            // Arrange
            User user = new User()
            {
                
                name = "Juan",
               
            };
            var mockUserInfraestructure = new Mock<IUserInfraestructure>();
            mockUserInfraestructure.Setup(t => t.Create(user)).ReturnsAsync(true);
            UserDomain userDomain = new UserDomain(mockUserInfraestructure.Object);

            // Act
            var returnValue = userDomain.Create(user);

            // Assert
            Assert.True(returnValue.Result);
        }
    }
}