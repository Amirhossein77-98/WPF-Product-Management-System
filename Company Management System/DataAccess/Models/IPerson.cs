using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public interface IPerson
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        int Age { get; set; }
        int PhoneNumber { get; set; }
        string Email { get; set; }
        string Address { get; set; }

        string GetInfo();
        string Picture();
    }
}
