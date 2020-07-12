using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public class AccountServiceUnitTests
    {
        #region Tests

        [Theory]
        [MemberData(nameof(GetAllAccountsUnitTestsDataGenerator))]
        public async Task GetAllAccountsUnitTests(IEnumerable<Account> list)
        {
            var mockAccountDbHandler = new Mock<IAccountDbHandler>();
            var mockUserDbHandler = new Mock<IUserDbHandler>();
            mockAccountDbHandler.Setup(h => h.GetAccountsAsync()).ReturnsAsync(list);

            var userService = new AccountService(mockAccountDbHandler.Object, mockUserDbHandler.Object);

            var users = await userService.GetAllAccounts();

            Assert.Equal(list.Count(), users.Count());
        }

        [Theory]
        [MemberData(nameof(GetUserAccountsUnitTestsDataGenerator))]
        public async Task GetUserAccountsUnitTests(
            Mock<IAccountDbHandler> mockAccountDbHandler,
            Mock<IUserDbHandler> mockUserDbHandler,
            int userId,
            IEnumerable<AccountDto> expectedAccounts)
        {
            var accountService = new AccountService(mockAccountDbHandler.Object, mockUserDbHandler.Object);

            var accounts = await accountService.GetUserAccounts(userId);
            
            Assert.Equal(expectedAccounts.Count(), accounts.Count());
            Assert.True(accounts.All(a => a.User.Id == userId));
        }

        [Theory]
        [MemberData(nameof(AddAccountUnitTestsDataGenerator))]
        public async Task AddAccountUnitTests(
            AddAccountRequest request,
            Type exceptionType)
        {
            var userDbHandler = new Mock<IUserDbHandler>();
            var accountDbHandler = new Mock<IAccountDbHandler>();

            userDbHandler.Setup(h => h.GetUsersAsync()).ReturnsAsync(
                new List<User>()
                    {
                        new User() { Id = 1, Name = "N1", Email = "n@z.c", Salary = 2000, Expenses = 100},
                        new User() { Id = 2, Name = "M1", Email = "m@z.c", Salary = 5000, Expenses = 4500}
                    });

            var accountService = new AccountService(accountDbHandler.Object, userDbHandler.Object);

            if (exceptionType == null)
            {
                await accountService.AddAccountAsync(request);
                accountDbHandler.Verify(a => a.AddAccountAsync(It.IsAny<Account>()), Times.Once);
            }
            else
            {
                await Assert.ThrowsAsync(exceptionType, () => accountService.AddAccountAsync(request));
                accountDbHandler.Verify(a => a.AddAccountAsync(It.IsAny<Account>()), Times.Never);
            }
        }
        #endregion

        #region Data Generator

        public static IEnumerable<object[]> GetAllAccountsUnitTestsDataGenerator()
        {
            yield return new object[]
                             {
                                 new List<Account>()
                                     {
                                         new Account() { Id = 11, UserId = 1 }, new Account() { Id = 12, UserId = 2 }
                                     }
                             };

            yield return new object[] { Enumerable.Empty<Account>() };
        }

        public static IEnumerable<object[]> GetUserAccountsUnitTestsDataGenerator()
        {
            var mockUserDbHandler = new Mock<IUserDbHandler>();

            mockUserDbHandler.Setup(h => h.GetUsersAsync()).ReturnsAsync(
                new List<User>()
                    {
                        new User() { Id = 1, Name = "N1", Email = "n@z.c" },
                        new User() { Id = 2, Name = "M1", Email = "m@z.c" }
                    });


            var mockAccountDbHandler = new Mock<IAccountDbHandler>();
            var dic = new Dictionary<int, IEnumerable<Account>>()
                          {
                              [1] = new List<Account>()
                                        {
                                            new Account()
                                                {
                                                    Id = 11,
                                                    UserId = 1,
                                                    User = new User() { Id = 1, Name = "N1", Email = "n@z.c" }
                                                }
                                        }
                          };

            mockAccountDbHandler.Setup(h => h.GetUserAccountsAsync(It.IsAny<int>())).Returns<int>(
                id => Task.FromResult(dic.ContainsKey(id) ? dic[id] : Enumerable.Empty<Account>()));

            yield return new object[]
                             {
                                 mockAccountDbHandler, mockUserDbHandler, 1,
                                 new List<AccountDto>()
                                     {
                                         new AccountDto()
                                             {
                                                 Id = 11, User = new UserDto() { Id = 1, Name = "N1", Email = "n@z.c" }
                                             }
                                     }
                             };

            yield return new object[] { mockAccountDbHandler, mockUserDbHandler, 3, Enumerable.Empty<AccountDto>() };
        }

        public static IEnumerable<object[]> AddAccountUnitTestsDataGenerator()
        {
            var requests = new List<AddAccountRequest>()
                               {
                                   new AddAccountRequest() { UserId = 1 },
                                   new AddAccountRequest() { UserId = 2 },
                                   new AddAccountRequest() { UserId = 3 }
                               };

            yield return new object[] { requests[0], null };
            yield return new object[] { requests[1], typeof(UserIsNotEligibleToCreateAccountException) };
            yield return new object[] { requests[2], typeof(UserNotFountException) };
        }

        #endregion
    }
}
