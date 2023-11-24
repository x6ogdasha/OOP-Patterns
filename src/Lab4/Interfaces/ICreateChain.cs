using Itmo.ObjectOrientedProgramming.Lab4.Entity.Handlers;

namespace Itmo.ObjectOrientedProgramming.Lab4.Interfaces;

public interface ICreateChain
{
    public void Create(CommandHandler handler);
}