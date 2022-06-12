using Abp.UI;
using BankApi.Interfaces;
using BankApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
//using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.CommonModels;

namespace BankApi.Service
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IAccountService _accountService;
        public AccountRepository(UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager,
            IConfiguration Configuration,
            IAccountService accountService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = Configuration;
            _accountService = accountService;
        }

        public async Task<IdentityResult> SignUp(SignUp signUp)
        {
            var user = new ApplicationUser
            {
                FirstName = signUp.FirstName,
                LastName = signUp.LastName,
                Email = signUp.Email,
                UserName = signUp.Email,
               // AccountNumber = _accountService.CreateAccount()
            };

            return await _userManager.CreateAsync(user, signUp.PassWord);
        }

        public async Task<string> Login(Login login)
        {
            var result = await _signInManager.PasswordSignInAsync(login.Email, login.PassWord, false, false);
            if (!result.Succeeded)
            {
                return null;
            }
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, login.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var authSignInKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:validIssuer"],
                audience: _configuration["JWT:validIssuer"],
                expires: DateTime.Now.AddDays(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSignInKey, SecurityAlgorithms.HmacSha256Signature)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);


        }
        public List<ApplicationUser> GetAlluser()
        {
            var usr = _userManager.Users.ToList();
            if (usr == null)
            {
                throw new ArgumentNullException(nameof(usr));
            }
            return usr;

        }
        public async Task<string> UpdateUser(SignUp userData)
        {
            if (userData == null)
            {
                throw new UserFriendlyException("Please Input Valid Record");
            }
            else
            {
                var getData = _userManager.Users.FirstOrDefault(c => c.Email == userData.Email);
                if (getData == null)
                {
                    throw new UserFriendlyException("Record Not Found");
                }
                else
                {
                  var item =  _userManager.UpdateAsync(getData).ToString();
                    return item;
                }            
            }
        }
        public void DeleteUser(SignUp userData)
        {
            var getData = _userManager.Users.FirstOrDefault(c => c.Email == userData.Email);
            if (getData == null)
            {
                throw new UserFriendlyException("Record Not Found");
            }
            else
            {
                var item = _userManager.DeleteAsync(getData);                
            }          
        }
    }
}
