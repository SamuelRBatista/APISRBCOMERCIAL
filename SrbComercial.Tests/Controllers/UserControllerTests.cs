using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SrbComercialInfrastructure.Data;
using Xunit;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SrbComercial.Tests.Controllers
{
    public class UserControllerTests
    {
        private DataContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "TestUserDatabase") // Usando um banco em memória
                .Options;

            return new DataContext(options);
        }

        [Fact]
        public async Task Can_Create_User()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var userStore = new UserStore<IdentityUser>(context);
            var userManager = new UserManager<IdentityUser>(
                userStore, null, new PasswordHasher<IdentityUser>(),
                null, null, null, null, null, null);

            var user = new IdentityUser
            {
                UserName = "testuser",
                Email = "testuser@example.com"
            };

            // Act
            var result = await userManager.CreateAsync(user, "Test@123");

            // Assert
            Assert.True(result.Succeeded);
            Assert.NotNull(context.Users.SingleOrDefault(u => u.UserName == "testuser"));
        }

        [Fact]
        public async Task Can_Find_User_By_Email()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var userStore = new UserStore<IdentityUser>(context);
            var userManager = new UserManager<IdentityUser>(
                userStore, null, new PasswordHasher<IdentityUser>(),
                null, null, null, null, null, null);

            var user = new IdentityUser
            {
                UserName = "findmeuser",
                Email = "findme@example.com"
            };

            await userManager.CreateAsync(user, "Test@123");

            // Act
            var foundUser = await userManager.FindByEmailAsync("findme@example.com");

            // Assert
            Assert.NotNull(foundUser);
            Assert.Equal("findmeuser", foundUser.UserName);
        }
    }
}
