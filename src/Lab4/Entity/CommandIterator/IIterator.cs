namespace Itmo.ObjectOrientedProgramming.Lab4.Entity.CommandIterator;

public interface IIterator
{
    public void GoNext();
    public void Reset();
    public string Current();
}