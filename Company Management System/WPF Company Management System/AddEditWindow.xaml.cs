using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DataAccess;
using DataAccess.Models;

namespace WPF_Company_Management_System
{
    /// <summary>
    /// Interaction logic for AddEditWindow.xaml
    /// </summary>
    public partial class AddEditWindow : Window
    {
        operations _operation = operations.AddProduct;
        private AppDBContext _passedContext;

        public AddEditWindow(string panel, AppDBContext _context)
        {
            InitializeComponent();

            _passedContext = _context;

            if (panel == "AddProduct")
            {
                IProduct.categories[] categories = (IProduct.categories[])Enum.GetValues(typeof(IProduct.categories));
                WindowTitle.Content = "Add Product";
                ProductDetails.Visibility = Visibility.Visible;
                EmplyeeDetails.Visibility = Visibility.Collapsed;
                CustomerDetails.Visibility = Visibility.Collapsed;
                ProductCategoryComboBox.ItemsSource = categories;
                _operation = operations.AddProduct;
            } else if (panel == "AddEmployee")
            {
                WindowTitle.Content = "Add Employee";
                ProductDetails.Visibility = Visibility.Collapsed;
                EmplyeeDetails.Visibility = Visibility.Visible;
                CustomerDetails.Visibility = Visibility.Collapsed;
                _operation = operations.AddEmployee;
            } else if (panel == "AddCustomer")
            {
                WindowTitle.Content = "Add Customer";
                ProductDetails.Visibility = Visibility.Collapsed;
                EmplyeeDetails.Visibility = Visibility.Collapsed;
                CustomerDetails.Visibility = Visibility.Visible;
                _operation = operations.AddCustomer;
            } else if (panel == "EditProduct")
            {
                WindowTitle.Content = "Edit Product";
                ProductDetails.Visibility = Visibility.Visible;
                EmplyeeDetails.Visibility = Visibility.Collapsed;
                CustomerDetails.Visibility = Visibility.Collapsed;
                _operation = operations.EditProduct;
            } else if (panel == "EditEmployee")
            {
                WindowTitle.Content = "Edit Employee";
                ProductDetails.Visibility = Visibility.Collapsed;
                EmplyeeDetails.Visibility = Visibility.Visible;
                CustomerDetails.Visibility = Visibility.Collapsed;
                _operation = operations.EditEmployee;
            } else if (panel == "EditCustomer")
            {
                WindowTitle.Content = "Edit Customer";
                ProductDetails.Visibility = Visibility.Collapsed;
                EmplyeeDetails.Visibility = Visibility.Collapsed;
                CustomerDetails.Visibility = Visibility.Visible;
                _operation = operations.EditCustomer;
            }
        }

        enum operations { 
        AddProduct,
        EditProduct,
        AddEmployee,
        EditEmployee,
        AddCustomer,
        EditCustomer,
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_operation == operations.AddProduct)
            {
                string ProductName = ProductNameTextBox.Text;
                string ProductDescription = ProductDescriptionTextBox.Text;
                string ProductCategory = ProductCategoryComboBox.Text;
                int ProductCount = Convert.ToInt32(ProductCountTextBox.Text);
                double ProductPrice = Convert.ToDouble(ProductPriceTextBox.Text);

                var NewProduct = new Product
                {
                    Name = ProductName,
                    Description = ProductDescription,
                    Category = ProductCategory,
                    Count = ProductCount,
                    PicAddress = "",
                    Price = ProductPrice
                };
                _passedContext.Products.Add(NewProduct);
                _passedContext.SaveChanges();
                this.Close();

            }
            else if (_operation == operations.AddEmployee)
            {

            }
            else if (_operation == operations.AddCustomer)
            {

            }
            else if (_operation == operations.EditProduct)
            {

            }
            else if (_operation == operations.EditEmployee)
            {

            }
            else if (_operation == operations.EditCustomer)
            {

            }
        }
    }
}
