using Itmo.ObjectOrientedProgramming.Lab3.Common;
using Itmo.ObjectOrientedProgramming.Lab3.Entity;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using NSubstitute;
using Xunit;
using Message = Itmo.ObjectOrientedProgramming.Lab3.Entity.Message;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;
public class Test3
{
    [Fact]
    public void UnreadStatus()
    {
        var message = new Message("1", "hello", 0);
        var user = new User();
        var recipientUser = new RecipientUser(message);
        var userProxy = new RecipientUserProxy(recipientUser);
        userProxy.SendTo(user);
        Assert.Equal(Status.Unread, user.MessageStatus);
    }

    [Fact]
    public void ChangeStatus()
    {
        var message = new Message("1", "hello", 0);
        var user = new User();
        var recipientUser = new RecipientUser(message);
        var userProxy = new RecipientUserProxy(recipientUser);
        userProxy.SendTo(user);
        user.Read();
        Assert.Equal(Status.Read, user.MessageStatus);
    }

    [Fact]
    public void WrongChangeStatus()
    {
        var message = new Message("1", "hello", 0);
        var user = new User();
        var recipientUser = new RecipientUser(message);
        var userProxy = new RecipientUserProxy(recipientUser);
        userProxy.SendTo(user);
        user.Read();
        Assert.Throws<AlreadyReadException>(() => user.Read());
    }

    [Fact]
    public void LowPriority()
    {
        Logger mockLogger = Substitute.For<Logger>();
        var message = new Message("1", "hello", 3);
        var user = new User();
        var recipientUser = new RecipientUser(message);
        var userProxy = new RecipientUserProxy(recipientUser, mockLogger);
        userProxy.SendTo(user);
        mockLogger.Received(1).Log("Фильтр не пройден сообщение не ушло");
    }

    [Fact]
    public void CheckReceive()
    {
        Logger mockLogger = Substitute.For<Logger>();
        var message = new Message("1", "hello", 0);
        var user = new User(mockLogger);
        var recipientUser = new RecipientUser(message);
        var userProxy = new RecipientUserProxy(recipientUser, mockLogger);
        userProxy.SendTo(user);
        mockLogger.Received(1).Log("Фильтр пройден сообщение ушло");
    }

    [Fact]
    public void CheckReceiveMessenger()
    {
        Logger mockLogger = Substitute.For<Logger>();
        var message = new Message("1", "hello", 0);
        var messenger = new Messenger(mockLogger);
        var recipientUser = new RecipientMessenger(message);
        var userProxy = new RecipientMessengerProxy(recipientUser, mockLogger);
        userProxy.SendTo(messenger);
        mockLogger.Received(1).Log("Сообщение получено мессенджером");
    }
}