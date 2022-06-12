using Abp.UI;
using BankApi.Data;
using BankApi.Interfaces;
using BankApi.Interfaces.Dtos;
using BankApi.Models;
using BankApi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BankApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountCreationController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public readonly AppDbContext _Context;

        public AccountCreationController(IAccountService accountService, AppDbContext context)
        {
            _accountService = accountService;
            _Context = context;
        }

        [HttpPost("CreatAccount")]
        public async Task<string> CreateAccount(AccountDto account)
        {
            if (account.AccountName == null)
            {
                throw new UserFriendlyException("Sorry Account Name Cannot Be Empty");
            }
            else
            {
                var result = await _accountService.CreateAccount(account);
                return result;
            }

        }
        [HttpGet("GetAllAccounts")]
        public Accounts  GetAllAccount()
        {
            var item = _accountService.GetAllAccount();
            if(item == null)
            {
                throw new UserFriendlyException("Sorry No Account Has Been Created");
            }
            else
            {
               
                return item;
            }

        }
        [HttpPut("UpdateAccount")]
        public IActionResult UpdateAccount(AccountDto account)
        {
            if (account == null)
            {
                throw new UserFriendlyException("Please Input Valid Record");
            }
            else
            {
              var result = _accountService.UpdateAccount(account);
                if (result == null)
                {
                    throw new UserFriendlyException("Update Was not successful");
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Account Updated Successfully"
                    });
                }                 
            }
        }

        [HttpPut("FundAccount")]
        public IActionResult FundAccount(AccountToFundDto account)
        {
            if (account == null)
            {
                throw new UserFriendlyException("Please Input Valid Record");
            }
            else
            {
                var result = _accountService.FundAccount(account);
                if (result == null)
                {
                    throw new UserFriendlyException("Error Occured while Funding Account");
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Account Funded Successfully"
                    });
                }
            }
        }

        [HttpPut("WithDrawFund")]
        public IActionResult WithDrawFund(AccountToFundDto account)
        {
            if (account == null)
            {
                throw new UserFriendlyException("Please Input Valid Record");
            }
            else
            {
                var result = _accountService.WithDrawFunds(account);
                if (result == null)
                {
                    throw new UserFriendlyException("Error Occured while Withdrawing Account");
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Transaction Successful"
                    });
                }
            }
        }
        [HttpDelete("DeletAccount/{AccountName}")]
        public IActionResult DeleteCustomer(AccountDto account)
        {
            if (true)
            {
                if (account == null)
                {
                    return NotFound(new
                    {
                        StatusCode = 404,
                        Message = "Account Not Found"
                    });

                }
                else
                {
                    var result = _accountService.DeleteAccount(account);
                    if (result == null)
                    {
                        throw new UserFriendlyException("Account Could Not Be Deleted");
                    }
                    else
                    {
                        return Ok(new
                        {
                            StatusCode = 200,
                            Message = "Account Deleted Successfully"
                        });
                    }
                  
                }
            }
        }

    }
}
