namespace DataAccess.Models
{
    public interface IPerson
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        int Age { get; set; }
        decimal PhoneNumber { get; set; }
        string Email { get; set; }
        string Address { get; set; }
    }
}
