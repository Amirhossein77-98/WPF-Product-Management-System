using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Models;
using System.Windows.Media.Imaging;

namespace WPF_Company_Management_System.Models
{
    internal class FetchData
    {

        internal static IEnumerable<object> FetchProducts(AppDBContext _context)
        {
            var Products = _context.Products.Select(
                p => new
                {
                    p.Id,
                    p.Name,
                    p.Description,
                    p.Category,
                    p.Price,
                    p.Count

                }).ToList();
            return Products;
        }

        internal static IEnumerable<object> FetchEmployees(AppDBContext _context)
        {
            var Employees = _context.Employees.Select(
                e => new
                {
                    e.Id,
                    e.FirstName,
                    e.LastName,
                    e.Email,
                    e.Age,
                    e.PhoneNumber,
                    e.Address,
                    e.Department,
                    e.Salary
                }).ToList();
            return Employees;
        }

        internal static IEnumerable<object> FetchCustomers(AppDBContext _context)
        {
            var Customers = _context.Customers.Select(
                c => new
                {
                    c.Id,
                    c.FirstName,
                    c.LastName,
                    c.Email,
                    c.Age,
                    c.PhoneNumber,
                    c.Address,
                    c.BuyCount
                }).ToList();
            return Customers;
        }

        internal static BitmapImage FetchImage(string source, string ImageCategory)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();

            if (ImageCategory == "Product")
            {
                bitmap.UriSource = new Uri(source == "" ? "./Resources/ProductNone.jpg" : source, UriKind.RelativeOrAbsolute);
            }
            else if (ImageCategory == "Employee")
            {
                bitmap.UriSource = new Uri(source == "" ? "./Resources/NoImage.jpg" : source, UriKind.RelativeOrAbsolute);
            }
            else if (ImageCategory == "Customer")
            {
                bitmap.UriSource = new Uri(source == "" ? "./Resources/NoImage.jpg" : source, UriKind.RelativeOrAbsolute);
            }

            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.EndInit();

            return bitmap;
        }
    }
}
