using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public string GetProductInfo()
        {
            string ProductInfo = $"{Name}" +
                $"\nCategory: {Category}" +
                $"\nRemaining: {Count}" +
                $"\nPrice: {Price}";
            return ProductInfo;
        }

        public string Picture()
        {
            return PicAddress;
        }
    }
}
