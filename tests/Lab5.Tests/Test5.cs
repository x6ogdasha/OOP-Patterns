using CoreData.DatabasePorts;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class Test5
{
    [Fact]
    public void Add()
    {
        IUserRepositoryPort userRepositoryPort = Substitute.For<IUserRepositoryPort>();
        IAccountRepositoryPort accountRepositoryPort = Substitute.For<IAccountRepositoryPort>();
        IHistoryRepository

    }
}