using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.X86;

namespace DataAccess.Models
{
    public class Employee : IPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        [Column(TypeName = "decimal(11, 0)")]
        public decimal PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Department Department { get; set; }
        public double Salary { get; set; }
        public string PicAddress { get; set; }

        public static string GetEmployeeDetailString(string FirstName, 
            string LastName, 
            int Age, 
            string Email, 
            decimal PhoneNumber, 
            string Address, 
            string Department, 
            string Salary)
        {
            string EmployeeDetails = $"{FirstName} {LastName}" +
                    $"\nAge: {Age}" +
                    $"\nEmail: {Email}" +
                    $"\nPhone Number: {PhoneNumber}" +
                    $"\nAddress: {Address}" +
                    $"\nDepartment: {Department}" +
                    $"\nSalary: ${Salary}";
            
            return EmployeeDetails;
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
