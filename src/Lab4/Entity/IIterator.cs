namespace Itmo.ObjectOrientedProgramming.Lab4.Entity;

public interface IIterator
{
    public void GoNext();
    public void Reset();
    public string Current();
}