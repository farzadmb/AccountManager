using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountManager.Application;
using AccountManager.Application.DTOs;
using AccountManager.Application.Exceptions;
using AccountManager.Application.Requests;
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
        public async Task GetUserByEmailUnitTests(Mock<IUserDbHandler> userDbHandler, string email, UserDto expectedUser)
        {
            var userService = new UserService(userDbHandler.Object);

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

        [Theory]
        [MemberData(nameof(AddUserUnitTestsDataGenerator))]
        public async Task AddUserUnitTests(
            AddUserRequest request,
            Type exceptionType)
        {
            var userDbHandler = new Mock<IUserDbHandler>();
            userDbHandler.Setup(h => h.GetUsersAsync()).ReturnsAsync(
                new List<User>()
                    {
                        new User() { Id = 1, Name = "N1", Email = "n@z.c" },
                        new User() { Id = 2, Name = "M1", Email = "m@z.c" }
                    });

            var userService = new UserService(userDbHandler.Object);

            if (exceptionType == null)
            {
                await userService.AddUserAsync(request);
                userDbHandler.Verify(h => h.AddUserAsync(It.IsAny<User>()), Times.Once);
            }
            else
            {
                await Assert.ThrowsAsync(exceptionType, () => userService.AddUserAsync(request));
                userDbHandler.Verify(h => h.AddUserAsync(It.IsAny<User>()), Times.Never);
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

            yield return new object[] { mockUserDbHandler, "p@z.c", null };
            yield return new object[]
                             {
                                 mockUserDbHandler, "n@z.c", new UserDto() { Id = 1, Name = "N1", Email = "n@z.c" }
                             };
        }

        public static IEnumerable<object[]> AddUserUnitTestsDataGenerator()
        {
            var requests = new List<AddUserRequest>()
                               {
                                   new AddUserRequest() { Name = "U0", Email = "u0@z.c", Salary = 1000, Expenses = 100 },
                                   new AddUserRequest() { Name = "N1", Email = "n@z.c", Salary = 1100, Expenses = 300 },
                                   new AddUserRequest() { Name = string.Empty, Email = "u2@z.c", Salary = 1000, Expenses = 100 },
                                   new AddUserRequest() { Name = "U3", Email = string.Empty, Salary = 1000, Expenses = 100 },
                                   new AddUserRequest() { Name = "U4", Email = "u4@z.c", Salary = -1, Expenses = 100 },
                                   new AddUserRequest() { Name = "U5", Email = "u5@z.c", Salary = 1000, Expenses = -1 },
                               };
            yield return new object[] { requests[0], null };
            yield return new object[] { requests[1], typeof(DuplicateEmailException) };
            yield return new object[] { requests[2], typeof(ArgumentNullException) };
            yield return new object[] { requests[3], typeof(ArgumentNullException) };
            yield return new object[] { requests[4], typeof(NegativeParameterException) };
            yield return new object[] { requests[5], typeof(NegativeParameterException) };
        }
        #endregion
    }
}