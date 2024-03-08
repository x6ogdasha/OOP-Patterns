using Adapters.EntityAdapters;
using CoreData;
using CoreData.DatabasePorts;
using CoreData.Entity;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class Test5
{
    [Fact]
    public void Add()
    {
        IUserRepositoryPort userRepository = Substitute.For<IUserRepositoryPort>();
        IAccountRepositoryPort accountRepository = Substitute.For<IAccountRepositoryPort>();
        IHistoryRepository historyRepository = Substitute.For<IHistoryRepository>();
        var user = new User("bb", 9, 123);
        var account = new Account(4, 100, 1);
        IUserPort userService = new UserAdapter(user, userRepository, accountRepository, historyRepository);
        userService.AddCash(100);
        accountRepository.Received(0).UpdateMoney(account.UserId, 200);
    }

    [Fact]
    public void WithdrawSuccess()
    {
        IUserRepositoryPort userRepository = Substitute.For<IUserRepositoryPort>();
        IAccountRepositoryPort accountRepository = Substitute.For<IAccountRepositoryPort>();
        IHistoryRepository historyRepository = Substitute.For<IHistoryRepository>();
        var user = new User("bb", 9, 123);
        var account = new Account(4, 100, 1);
        IUserPort userService = new UserAdapter(user, userRepository, accountRepository, historyRepository);
        userService.WithdrawMoney(50);
        accountRepository.Received(0).UpdateMoney(account.UserId, 50);
    }
}