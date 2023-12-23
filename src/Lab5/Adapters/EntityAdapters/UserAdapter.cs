using CoreData;
using CoreData.Common;
using CoreData.DatabasePorts;
using CoreData.Entity;

namespace Adapters.EntityAdapters;

public class UserAdapter : IUserPort
{
    private readonly IAccountRepositoryPort _accountRepository;
    private readonly IUserRepositoryPort _userRepository;
    private readonly IHistoryRepository _historyRepository;
    private User? _user;

    public UserAdapter(IUserRepositoryPort userRepository, IAccountRepositoryPort accountRepository, IHistoryRepository historyRepository)
    {
        _accountRepository = accountRepository;
        _userRepository = userRepository;
        _historyRepository = historyRepository;
    }

    public decimal? ShowBalance()
    {
        if (_user is null) return null;
        Account? account = _accountRepository.FindById(_user.Id);
        return account?.Money ?? 0;
    }

    public void WithdrawMoney(decimal money)
    {
        if (_user is null) return;
        Account? account = _accountRepository.FindById(_user.Id);
        if (account is not null && account.Money - money < 0) throw new NotEnoughMoneyException();

        if (account is not null)
        {
            account.Money -= money;
            _accountRepository.UpdateMoney(account.AccountId, account.Money);
            _historyRepository.AddOperation(account.AccountId, "-", account.Money);
        }
    }

    public void AddCash(decimal money)
    {
        if (_user is null) return;
        Account? account = _accountRepository.FindById(_user.Id);
        if (account is null) return;
        account.Money += money;
        _accountRepository.UpdateMoney(account.AccountId, account.Money);
        _historyRepository.AddOperation(account.AccountId, "+", account.Money);
    }

    public void ShowHistory()
    {
        if (_user is null) return;
        IList<MyTransaction> transactions = _historyRepository.GetTransactionHistory(_user.Id);

        foreach (MyTransaction transaction in transactions)
        {
            transaction.Show();
        }
    }

    public LoginResult Login(int id, int password)
    {
        User? user = _userRepository.FindById(id);
        if (user is null) return LoginResult.NotFound;
        _user = user;
        return LoginResult.Success;
    }
}