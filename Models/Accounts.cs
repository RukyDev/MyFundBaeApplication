using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace BankApi.Models
{
    public class Accounts : Entity
    {
        [Required]
        public string AccountName { get; set; }
        [Required]
        public string AccountNumber { get; set; }
        public double CurrentBalance { get; set; }
        public ClassOfAccount AccountClass { get; set; }
        public double InterestRate { get; set; }
        public int CustomerId { get; set; }
    }
    //public class AccountClasss
    //{
    //    public string FLEX { get; set; }
    //    public string DELUXE { get; set; }
    //    public string VIVA { get; set; }
    //    public string PIGGY { get; set; }
    //    public string SUPA { get; set; }      
    //}
    public enum ClassOfAccount
    {
        FLEX =1,
        DELUXE = 2,
        VIVA = 3,
        PIGGY = 4,
        SUPA = 5,   
    }

}
