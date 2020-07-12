using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountManager.Application;
using AccountManager.Application.DTOs;
using AccountManager.Data.DbHandlers;
using AccountManager.Data.Models;
using Moq;
using Xunit;

namespace AccountManager.UnitTests
{
    public class UserServiceUnitTests
    {
        #region Tests

        [Theory]
        [MemberData(nameof(GetAllUsersUnitTestsDataGenerator))]
        public async Task GetAllUsersUnitTests(IEnumerable<User> usersList)
        {
            var mockUserDbHandler = new Mock<IUserDbHandler>();
            mockUserDbHandler.Setup(h => h.GetUsersAsync()).ReturnsAsync(usersList);

            var userService = new UserService(mockUserDbHandler.Object);

            var users = await userService.GetAllUsersAsync();

            Assert.Equal(usersList.Count(), users.Count());
        }

        [Theory]
        [MemberData(nameof(GetUserByEmailUnitTestsDataGenerator))]
        public async Task GetUserByEmailUnitTests(IUserDbHandler userDbHandler, string email, UserDto expectedUser)
        {
            var userService = new UserService(userDbHandler);

            var user = await userService.GetUserAsync(email);

            if (expectedUser == null)
            {
                Assert.Null(user);
            }
            else
            {
                Assert.Equal(email, user.Email);
                Assert.Equal(expectedUser.Id, user.Id);
            }
        }

        #endregion

        #region Data Generator

        public static IEnumerable<object[]> GetAllUsersUnitTestsDataGenerator()
        {
            yield return new object[]
                             {
                                 new List<User>()
                                     {
                                         new User() { Id = 1, Name = "N1", Email = "n@z.c" },
                                         new User() { Id = 2, Name = "M1", Email = "m@z.c" }
                                     }
                             };
            yield return new object[] { Enumerable.Empty<User>() };
        }

        public static IEnumerable<object[]> GetUserByEmailUnitTestsDataGenerator()
        {
            var mockUserDbHandler = new Mock<IUserDbHandler>();
            mockUserDbHandler.Setup(h => h.GetUsersAsync()).ReturnsAsync(
                new List<User>()
                    {
                        new User() { Id = 1, Name = "N1", Email = "n@z.c" },
                        new User() { Id = 2, Name = "M1", Email = "m@z.c" }
                    });

            yield return new object[] { mockUserDbHandler.Object, "p@z.c", null };
            yield return new object[]
                             {
                                 mockUserDbHandler.Object, "n@z.c", new UserDto() { Id = 1, Name = "N1", Email = "n@z.c" }
                             };

        }

        #endregion
    }
}