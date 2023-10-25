using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Repositories;

public class Repository<T>
    where T : BaseComponent, IEquatable<T>
{
    private readonly List<T> _repository = new List<T>();

    public T? Read(string? component)
    {
        return _repository.FirstOrDefault(x => x is not null && x.Name == component);
    }

    public void Create(T component)
    {
        _repository.Add(component);
    }

    public void Delete(T component)
    {
        _repository.Remove(component);
    }
}