using Itmo.ObjectOrientedProgramming.Lab2.Entities.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class Client
{
    private Repository _currentRepository = new Repository();
    private CreateComponents _service;

    public Client()
    {
        _service = new CreateComponents(_currentRepository);
    }
}