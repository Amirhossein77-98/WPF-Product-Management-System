namespace DataAccess.Models
{
    public enum categories
    {
        Electronics,
        Accessories,
        HomeSupply,
        Beauty,
        Health
    }

    public interface IProduct
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string Category { get; set; }
        int Count { get; set; }
        string PicAddress { get; set; }
        double Price { get; set; }
    }
}
