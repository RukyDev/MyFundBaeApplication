using Abp.UI;
using BankApi.Interfaces;
using BankApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerCreationController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        public CustomerCreationController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] SignUp signUp)
        {
            var result = await _accountRepository.SignUp(signUp);
            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }
            return Unauthorized();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            var result = await _accountRepository.Login(login);
            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }
            return Ok(result);
        }

        [HttpGet("GetUsers")]
        public List<ApplicationUser> GetAllUsers()
        {
            var result = _accountRepository.GetAlluser();
            if (result.Count == 0 || result.Count < 0)
            {
                throw new UserFriendlyException("Sorry No User has Been Profiled in The System");
            }
            return result;
        }
        [HttpPut("UpdateUser")]
        public async Task<string> UpdateUser(SignUp userData)
        {
            var result = await _accountRepository.UpdateUser(userData);
            if (result == null)
            {
                throw new UserFriendlyException("");
            }
            else
            {
                return result;              
            }
        }
    }
}
