namespace DataAccess.Models
{
    public class Product : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int Count { get; set; }
        public string PicAddress { get; set; }
        public double Price { get; set; }
        
        public static string GetProductDetailString(string Name, string Description, string Category, int Count, double Price)
        {
            string ProductInfo = $"{Name}" +
                        $"\nDescription: {Description}" +
                        $"\nRemaining: {Count}" +
                        $"\nPrice: {Price}" +
                        $"\nCategory: {Category}";
            return ProductInfo;
        }
    }

}
