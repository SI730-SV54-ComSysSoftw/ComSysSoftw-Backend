using ComSysSoftw_Backend.Infraestructure;
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
                Id = 1,
                name = "Juan",
                Description = "Dueño de 1 perro",
                Pets = new List<Pet> { new Pet() { age = "1", name = "Pepe" } }
            };
            var mockUserInfraestructure = new Mock<IUserInfraestructure>();
            mockUserInfraestructure.Setup(t => t.Create(user)).ReturnsAsync(user);
            UserDomain userDomain = new UserDomain(mockUserInfraestructure.Object);

            // Act
            var returnValue = await userDomain.Save(user);

            // Assert
            Assert.Equal(1, returnValue.Id);
        }
    }
}