using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public interface IProduct
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string Category { get; set; }
        int Count { get; set; }
        string PicAddress { get; set; }
        double Price { get; set; }

        public string GetProductInfo();
        string Picture();
    }
}
