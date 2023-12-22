using CoreData;
using CoreData.DatabasePorts;
using CoreData.Entity;

namespace Adapters.EntityAdapters;

public class AdminAdapter : IAdminPort
{
    private readonly IAccountRepositoryPort _accountRepository;
    private readonly IUserRepositoryPort _userRepository;
    private readonly IHistoryRepository _historyRepository;

    public AdminAdapter(IUserRepositoryPort userRepository, IAccountRepositoryPort accountRepository, IHistoryRepository historyRepository)
    {
        _accountRepository = accountRepository;
        _userRepository = userRepository;
        _historyRepository = historyRepository;
    }

    public decimal ShowBalance(User user)
    {
        if (user is not null)
        {
            Account? account = _accountRepository.FindById(user.AccountId);
            return account?.Money ?? 0;
        }

        return 0;
    }

    public void ShowHistory(User user)
    {
        throw new NotImplementedException();
    }

    public void CreateUser(string name, int password, UserRole role)
    {
        _userRepository.AddNewUser(name, role, password);
        int lastUserId = _userRepository.FindLastUserId();
        _accountRepository.CreateAccount(0, lastUserId);
    }
}