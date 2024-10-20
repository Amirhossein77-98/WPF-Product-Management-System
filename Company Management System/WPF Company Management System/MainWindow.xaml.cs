using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataAccess;
using DataAccess.Models;

namespace WPF_Company_Management_System
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private AppDBContext _context;
        public MainWindow()
        {
            InitializeComponent();
            _context = new AppDBContext();
            //InitialAddProduct();
        }


        //private void InitialAddProduct()
        //{
        //    var InitProduct = new Product
        //    {
        //        Name = "TV",
        //        Description = "Some TV With Some Features",
        //        Category = "Home Electronics",
        //        Count = 6,
        //        PicAddress = "",
        //        Price = 870
        //    };
        //    _context.Products.Add(InitProduct);
        //    _context.SaveChanges();
        //}

        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {
            HomePanel.Visibility = Visibility.Visible;
            ProductsPanel.Visibility = Visibility.Collapsed;
            EmployeesPanel.Visibility = Visibility.Collapsed;
            CustomersPanel.Visibility = Visibility.Collapsed;
        }

        private void ProductsBtn_Click(object sender, RoutedEventArgs e)
        {
            HomePanel.Visibility = Visibility.Collapsed;
            ProductsPanel.Visibility = Visibility.Visible;
            EmployeesPanel.Visibility = Visibility.Collapsed;
            CustomersPanel.Visibility = Visibility.Collapsed;

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
            ProductsDataGrid.ItemsSource = Products;


        }

        private void EmployeesBtn_Click(object sender, RoutedEventArgs e)
        {
            HomePanel.Visibility = Visibility.Collapsed;
            ProductsPanel.Visibility = Visibility.Collapsed;
            EmployeesPanel.Visibility = Visibility.Visible;
            CustomersPanel.Visibility = Visibility.Collapsed;
        }

        private void CustomersBtn_Click(object sender, RoutedEventArgs e)
        {
            HomePanel.Visibility = Visibility.Collapsed;
            ProductsPanel.Visibility = Visibility.Collapsed;
            EmployeesPanel.Visibility = Visibility.Collapsed;
            CustomersPanel.Visibility = Visibility.Visible;
        }

        private void ProductsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var SelectedRow = ProductsDataGrid.SelectedItem;
            //int ProductId = SelectedRow != null ? SelectedRow.Id : 0;

            
            if (SelectedRow != null) 
            {
                int ProductId = (int)SelectedRow.GetType().GetProperty("Id").GetValue(SelectedRow, null);
                Product? product = _context.Products.FirstOrDefault(p => p.Id == ProductId);
                
                string ProductInfo = $"{product.Name}" +
                    $"\nDescription: {product.Description}" +
                    $"\nRemaining: {product.Count}" +
                    $"\nPrice: {product.Price}" +
                    $"\nCategory: {product.Category}";
                ProductsDetails.Content = ProductInfo;

                
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(product.PicAddress == "" ? "./Resources/ProductsImages/ProductNone.jpg" : product.PicAddress, UriKind.RelativeOrAbsolute);
                    bitmap.EndInit();
                    ProductsImage.Source = bitmap;
                
            } else {
                ProductsDetails.Content = "Nothing Found!";
                ProductsImage.Source = null;
            }
        }

        private void ProductAddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEditWindow AddWindow = new AddEditWindow("AddProduct", _context);
            
            AddWindow.ShowDialog();

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
            ProductsDataGrid.ItemsSource = Products;
        }
    }
}