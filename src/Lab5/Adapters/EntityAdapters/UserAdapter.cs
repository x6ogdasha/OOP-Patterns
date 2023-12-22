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
    private User _user;

    public UserAdapter(IUserRepositoryPort userRepository, IAccountRepositoryPort accountRepository, IHistoryRepository historyRepository, User user)
    {
        _accountRepository = accountRepository;
        _userRepository = userRepository;
        _historyRepository = historyRepository;
        _user = user;
    }

    public decimal ShowBalance()
    {
        Account? account = _accountRepository.FindById(_user.AccountId);
        return account?.Money ?? 0;
    }

    public void WithdrawMoney(decimal money)
    {
        Account? account = _accountRepository.FindById(_user.AccountId);
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
        Account? account = _accountRepository.FindById(_user.AccountId);
        if (account is null) return;
        account.Money += money;
        _accountRepository.UpdateMoney(account.AccountId, account.Money);
        _historyRepository.AddOperation(account.AccountId, "+", account.Money);
    }

    public void ShowHistory()
    {
        throw new NotImplementedException();
    }
}