using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankApi.Models
{
    public class SignUp : Entity
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Compare("ConfirmPassword")]
        public string PassWord { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        public string StateOfOrigin { get; set; }
        public string Lga { get; set; }


    }
}
