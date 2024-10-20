using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Employee : IPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Department Department { get; set; }
        public double Salary { get; set; }
        public string PicAddress { get; set; }


        public string GetInfo()
        {
            
            string PersonInfo = $"{FirstName} {LastName}" +
                $"\nAge: {Age}" +
                $"\nPhone Num: {PhoneNumber}" +
                $"\nEmail: {Email}" +
                $"\nAddress: {Address}" +
                $"\nDepartment: {Department}" +
                $"\nSalary: {Salary}";

            return PersonInfo;
        }

        public string Picture()
        {
            return PicAddress;
        }
    }

    public enum Department
    {
        Sales,
        Marketing,
        Management,
        worker
    }
}
