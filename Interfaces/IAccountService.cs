using BankApi.Interfaces.Dtos;
using BankApi.Models;
using System.Threading.Tasks;

namespace BankApi.Interfaces
{
    public interface IAccountService
    {
        Task<string> CreateAccount(AccountDto account);
        Accounts GetAllAccount();
        AccountDto UpdateAccount(AccountDto account);
        string DeleteAccount(AccountDto account);
        void UpdateAccountBalanceWithInterest(Accounts accounts);
        Accounts FundAccount(AccountToFundDto account);
        Accounts WithDrawFunds(AccountToFundDto account);
    }
}
