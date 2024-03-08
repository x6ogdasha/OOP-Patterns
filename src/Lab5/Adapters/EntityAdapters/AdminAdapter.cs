using CoreData;
using CoreData.DatabasePorts;
using CoreData.Entity;

namespace Adapters.EntityAdapters;

public class AdminAdapter : IAdminPort
{
    private readonly IAccountRepositoryPort _accountRepository;
    private readonly IUserRepositoryPort _userRepository;
    private readonly IHistoryRepository _historyRepository;
    private int _adminPassword;
    private bool _adminLogged;
    public AdminAdapter(IUserRepositoryPort userRepository, IAccountRepositoryPort accountRepository, IHistoryRepository historyRepository, int adminPassword)
    {
        _accountRepository = accountRepository;
        _userRepository = userRepository;
        _historyRepository = historyRepository;
        _adminPassword = adminPassword;
        _adminLogged = false;
    }

    public decimal ShowBalance(int id)
    {
        if (_adminLogged)
        {
            Account? account = _accountRepository.FindById(id);
            return account?.Money ?? 0;
        }

        return 0;
    }

    public void ShowHistory(int id)
    {
        if (_adminLogged)
        {
            IList<MyTransaction> transactions = _historyRepository.GetTransactionHistory(id);

            foreach (MyTransaction transaction in transactions)
            {
                transaction.Show();
            }
        }
    }

    public void CreateUser(string name, int password, UserRole role)
    {
        if (_adminLogged)
        {
            _userRepository.AddNewUser(name, role, password);
            int lastUserId = _userRepository.FindLastUserId();
            if (role is not UserRole.Admin) _accountRepository.CreateAccount(0, lastUserId);
        }
    }

    public void CheckForPermissions(int password)
    {
        if (password == _adminPassword) _adminLogged = true;
    }
}