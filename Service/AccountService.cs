using Abp.UI;
using BankApi.Data;
using BankApi.Interfaces;
using BankApi.Interfaces.Dtos;
using BankApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace BankApi.Service
{
    public class AccountService : IAccountService
    {
        private readonly AppDbContext _context;

        public AccountService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> CreateAccount(AccountDto account)
        {
            var item = new Accounts
            {
                AccountName = account.AccountName,
                AccountClass = ClassOfAccount.FLEX,
                AccountNumber = GenerateRandomNumber(2, 1000, 10),
                CustomerId = account.CustomerId,  
                CurrentBalance = 0,
            };
              var result = _context.Accounts.AddAsync(item).ToString();
            return result;
        }

        public Accounts GetAllAccount()
        {
            var item = _context.Accounts.Find();
            if (item == null)
            {
                throw new UserFriendlyException("No Account has been Profiled");
            }
            else
            {
                return item;
            }
        }

        public AccountDto UpdateAccount(AccountDto account)
        {
            var items = _context.Accounts.AsNoTracking().FirstOrDefault(c => c.AccountName == account.AccountName);
            if (items == null)
            {
                throw new UserFriendlyException("Sorry No Account Matching This Record Exist");
            }
            else
            {
                _context.Entry(items).State = EntityState.Modified;
                _context.SaveChanges();
                return account;
            }
        }
        public string DeleteAccount(AccountDto account)
        {
            var result = "";
            var items = _context.Accounts.AsNoTracking().FirstOrDefault(c => c.AccountName == account.AccountName);
            if (items == null)
            {
                throw new UserFriendlyException("Sorry No Account Matching This Record Exist");
            }
            else
            {
                _context.Accounts.Remove(items);
                _context.SaveChanges();
                result = "Account Deleted Successfully";
                return result;
            }
        }
        public void UpdateAccountBalanceWithInterest(Accounts accounts)
        {
            var account = _context.Accounts.FirstOrDefault(c => c.CustomerId == accounts.CustomerId);
            if (account == null)
            {
                throw new UserFriendlyException("No Record Found");
            }
            else
            {
                if (account.CurrentBalance >= 20000)
                {
                    if (account.AccountClass == ClassOfAccount.FLEX)
                    {
                        account.CurrentBalance *= 2.5;
                    }
                    if (account.AccountClass == ClassOfAccount.DELUXE)
                    {
                        account.CurrentBalance *= 3.5;
                    }
                    if (account.AccountClass == ClassOfAccount.VIVA)
                    {
                        account.CurrentBalance *= 6.0;
                    }
                    if (account.AccountClass == ClassOfAccount.PIGGY)
                    {
                        account.CurrentBalance *= 9.2;
                    }
                    if (account.AccountClass == ClassOfAccount.SUPA)
                    {
                        account.CurrentBalance *= 10;
                    }
                }
                else
                {
                    throw new UserFriendlyException("No Interest for Account Less Than 20,000");
                }
                _context.Update(account);
                _context.SaveChanges();
            }
        }
        public Accounts FundAccount(AccountToFundDto account)
        {
            var items = _context.Accounts.AsNoTracking().FirstOrDefault(c => c.AccountNumber == account.AccountNumber);
            if (items == null)
            {
                throw new UserFriendlyException("Sorry No Account Matching This Record Exist");
            }
            else
            {
                items.CurrentBalance = account.Amount;
                _context.Entry(items).State = EntityState.Modified;
                _context.SaveChanges();
                return items;
            }
        }
        public Accounts WithDrawFunds(AccountToFundDto account)
        {
            var items = _context.Accounts.AsNoTracking().FirstOrDefault(c => c.AccountNumber == account.AccountNumber);
            if (items == null)
            {
                throw new UserFriendlyException("Sorry No Account Matching This Record Exist");
            }
            else
            {
                items.CurrentBalance = account.Amount;
                _context.Entry(items).State = EntityState.Modified;
                _context.SaveChanges();
                return items;
            }
        }
        public static string GenerateRandomNumber(int min, int max, int placeNumber)
        {
            Random random = new Random();
            var num = random.Next(min, max);

            return num.ToString($"D{placeNumber}");
        }
    }
}
