using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public string GetInfo()
        {
            string PersonInfo = $"{FirstName} {LastName}" +
                $"\nAge: {Age}" +
                $"\nPhone Num: {PhoneNumber}" +
                $"\nEmail: {Email}" +
                $"\nAddress: {Address}" +
                $"\nBuy Count: {BuyCount}";

            return PersonInfo;
        }
        public string Picture()
        {
            return PicAddress;
        }
    }
}
