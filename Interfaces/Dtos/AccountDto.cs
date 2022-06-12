using System.ComponentModel.DataAnnotations;

namespace BankApi.Interfaces.Dtos
{
    public class AccountDto
    {
        internal bool success;

        [Required]
        public string AccountName { get; set; }
        [Required]
       // public string AccountNumber { get; set; }       
       // public int AccountClass { get; set; }       
        public int CustomerId { get; set; }
    }

    public class AccountToFundDto
    {
        public string AccountNumber { get; set; }
        public double Amount { get; set; }
    }
}
