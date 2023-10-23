using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.BaseClasses;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Repositories;

public class Repo : BaseComponent, IReposiroty<BaseComponent>
{
    private readonly Dictionary<string, List<BaseComponent>> _repository = new();

    public BaseComponent? Read(BaseComponent component)
    {
        KeyValuePair<string, List<BaseComponent>> foundItem = _repository.FirstOrDefault(x => x.Key == nameof(component) && x.Value.Contains(component));
        return foundItem.Value?.FirstOrDefault(c => c == component);
    }

    public void Update(BaseComponent component)
    {
        KeyValuePair<string, List<BaseComponent>> foundItem = _repository.FirstOrDefault(x => x.Key == nameof(component) && x.Value.Contains(component));
        foundItem.Value?.Add(component);
    }

    public void Delete(BaseComponent component)
    {
        KeyValuePair<string, List<BaseComponent>> foundItem = _repository.FirstOrDefault(x => x.Key == nameof(component) && x.Value.Contains(component));
        foundItem.Value?.Remove(component);
    }
}