namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Repositories;

public interface IReposiroty<T>
{
    public T? Read(T component);
    public void Create(T component);
    public void Delete(T component);
}