using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public class Customer : IPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        [Column(TypeName = "decimal(11, 0)")]
        public decimal PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int BuyCount { get; set; }
        public string PicAddress { get; set; }

        public static string GetEmployeeDetailString(string FirstName, string LastName, int Age, int BuyCount, string Email, decimal PhoneNumber, string Address)
        {
            string EmployeeDetails = $"{FirstName} {LastName}" +
                    $"\nAge: {Age}" +
                    $"\nBuy Count: {BuyCount}" +
                    $"\nPhone Number: {PhoneNumber}" +
                    $"\nEmail: {Email}" +
                    $"\nAddress: {Address}";

            return EmployeeDetails;
        }
    }
}
