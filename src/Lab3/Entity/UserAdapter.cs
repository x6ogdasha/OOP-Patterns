using System;
using Itmo.ObjectOrientedProgramming.Lab3.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entity;

public class UserAdapter : ISend, IReceive, IRead
{
    private readonly Message _message;
    private readonly User _user;

    public UserAdapter(User user, Message message)
    {
        _message = message;
        _user = user;
    }

    public void SendTo(IReceive recipient)
    {
        if (recipient is null) throw new ArgumentNullException(nameof(recipient));
        recipient.Receive(_message);
    }

    public void Receive(Message message)
    {
        _user.Receive(message);
    }

    public void Read()
    {
        _user.Read();
    }
}