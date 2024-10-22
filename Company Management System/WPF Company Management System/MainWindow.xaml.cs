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
        }

        private IEnumerable<object> FetchProducts()
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

        private IEnumerable<object> FetchEmployees()
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

        private IEnumerable<object> FetchCustomers()
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
            ProductsDataGrid.ItemsSource = FetchProducts();
        }

        private void EmployeesBtn_Click(object sender, RoutedEventArgs e)
        {
            HomePanel.Visibility = Visibility.Collapsed;
            ProductsPanel.Visibility = Visibility.Collapsed;
            EmployeesPanel.Visibility = Visibility.Visible;
            CustomersPanel.Visibility = Visibility.Collapsed;
            EmployeesDataGrid.ItemsSource = FetchEmployees();
        }

        private void CustomersBtn_Click(object sender, RoutedEventArgs e)
        {
            HomePanel.Visibility = Visibility.Collapsed;
            ProductsPanel.Visibility = Visibility.Collapsed;
            EmployeesPanel.Visibility = Visibility.Collapsed;
            CustomersPanel.Visibility = Visibility.Visible;
            CustomersDataGrid.ItemsSource = FetchCustomers();
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
                ProductsDetails.Text = ProductInfo;

                
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(product.PicAddress == "" ? "./Resources/ProductsImages/ProductNone.jpg" : product.PicAddress, UriKind.RelativeOrAbsolute);
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.EndInit();
                    ProductsImage.Source = bitmap;
                    ProductsImage.Visibility = Visibility.Visible;
                
            } else {
                ProductsDetails.Text = "Nothing Found!";
                ProductsImage.Source = null;
            }
        }

        private void ProductAddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEditWindow AddWindow = new AddEditWindow(panel: "Add_Product", _context: _context);
            AddWindow.ShowDialog();
            ProductsDataGrid.ItemsSource = FetchProducts();
        }

        private void ProductEditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Please choose a product!");
            } else
            {
                int ProductId = (int)ProductsDataGrid.SelectedItem.GetType().GetProperty("Id").GetValue(ProductsDataGrid.SelectedItem, null);
                Product product = _context.Products.FirstOrDefault(p => p.Id == ProductId);
                AddEditWindow EditWindow = new AddEditWindow(panel: "Edit_Product", _context: _context, product: product);
                EditWindow.ShowDialog();
                ProductsDataGrid.ItemsSource = FetchProducts();
            }
        }

        private void ProductDeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Please choose a product!");
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this product?", "Delete Product?", MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Yes) {
                    int ProductId = (int)ProductsDataGrid.SelectedItem.GetType().GetProperty("Id").GetValue(ProductsDataGrid.SelectedItem, null);
                    Product product = _context.Products.FirstOrDefault(p => p.Id == ProductId);
                    _context.Products.Remove(product);
                    _context.SaveChanges();
                    ProductsDataGrid.ItemsSource = FetchProducts();
                    ProductsDetails.Text = "";
                    ProductsImage.Visibility = Visibility.Hidden;
                }
            }
        }

        private void EmployeeAddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEditWindow AddEmployeeWindow = new AddEditWindow(panel: "Add_Employee", _context: _context);
            AddEmployeeWindow.ShowDialog();
            EmployeesDataGrid.ItemsSource = FetchEmployees();
        }

        private void EmployeeEditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeesDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Please choose one employee to proceed!");
            } else
            {
                var SelectedRow = EmployeesDataGrid.SelectedItem;
                int EmployeeId = (int)SelectedRow.GetType().GetProperty("Id").GetValue(SelectedRow, null);
                Employee employee = _context.Employees.FirstOrDefault(e => e.Id == EmployeeId);

                AddEditWindow EditEmployeeWindow = new AddEditWindow(panel: "Edit_Employee", _context: _context, employee: employee);
                EditEmployeeWindow.ShowDialog();
                EmployeesDataGrid.ItemsSource = FetchEmployees();
            }
        }

        private void EmployeeDeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var SelectedRow = EmployeesDataGrid.SelectedItem;
            if (SelectedRow != null)
            {
                int EmployeeId = (int)SelectedRow.GetType().GetProperty("Id").GetValue(SelectedRow, null);
                string EmployeeFirstName = (string)SelectedRow.GetType().GetProperty("FirstName").GetValue(SelectedRow, null);
                string EmployeeLastName = (string)SelectedRow.GetType().GetProperty("LastName").GetValue(SelectedRow, null);
                MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete {EmployeeFirstName} {EmployeeLastName}?", "Delete Employee?" ,MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Yes)
                {
                    Employee employee = _context.Employees.FirstOrDefault(e => e.Id == EmployeeId);
                    _context.Employees.Remove(employee);
                    _context.SaveChanges();
                    EmployeesDataGrid.ItemsSource = FetchEmployees();
                    EmployeeDetailsTextBlock.Text = "";
                    EmployeeImage.Visibility = Visibility.Hidden;
                }
                else if (result == MessageBoxResult.No) {
                    MessageBox.Show("I think you made a better choice :)");
                }
            } else
            {
                MessageBox.Show("Please choose an employee first!");
            }

        }

        private void EmployeesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var SelectedRow = EmployeesDataGrid.SelectedItem;

            if (SelectedRow != null) {
                int EmployeeId = (int)SelectedRow.GetType().GetProperty("Id").GetValue(SelectedRow, null);
                Employee employee = _context.Employees.FirstOrDefault(emp => emp.Id == EmployeeId);

                string EmployeeDetails = $"{employee.FirstName} {employee.LastName}" +
                    $"\nAge: {employee.Age}" +
                    $"\nEmail: {employee.Email}" +
                    $"\nPhone Number: {employee.PhoneNumber}" +
                    $"\nAddress: {employee.Address}" +
                    $"\nDepartment: {employee.Department}" +
                    $"\nSalary: ${employee.Salary}";

                EmployeeDetailsTextBlock.Text = EmployeeDetails;

                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(employee.PicAddress == "" ? ".\\Resources\\ProductsImages\\ProductNone.jpg" : employee.PicAddress, UriKind.RelativeOrAbsolute);
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                EmployeeImage.Source = bitmapImage;
                ProductsImage.Visibility = Visibility.Visible;
            }

        }

        private void CustomersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var SelectedRow = CustomersDataGrid.SelectedItem;
            if (SelectedRow != null) {
                int CustomerId = (int)SelectedRow.GetType().GetProperty("Id").GetValue(SelectedRow, null);
                Customer customer = _context.Customers.FirstOrDefault(customer => customer.Id == CustomerId);

                string CustomerDetails = $"{customer.FirstName} {customer.LastName}" +
                    $"\nAge: {customer.Age}" +
                    $"\nBuy Count: {customer.BuyCount}" +
                    $"\nPhone Number: {customer.BuyCount}" +
                    $"\nEmail: {customer.Email}" +
                    $"\nAddress: {customer.Address}";

                CustomerDetailsTextBlock.Text = CustomerDetails;

                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(customer.PicAddress == "" ? ".\\Resources\\ProductsImages\\ProductNone.jpg" : customer.PicAddress, UriKind.RelativeOrAbsolute);
                bitmapImage.CacheOption= BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                CustomerImage.Source = bitmapImage;
                ProductsImage.Visibility = Visibility.Visible;
            }
        }

        private void AddNewCustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEditWindow AddCustomerWindow = new AddEditWindow("Add_Customer", _context);
            AddCustomerWindow.ShowDialog();
            CustomersDataGrid.ItemsSource = FetchCustomers();
        }

        private void CustomerEditBtn_Click(object sender, RoutedEventArgs e)
        {
            var SelectedItem = CustomersDataGrid.SelectedItem;
            if (SelectedItem == null)
            {
                MessageBox.Show("Please choose a customer first!");
            }
            else
            {
                int CustomerId = (int)SelectedItem.GetType().GetProperty("Id").GetValue(SelectedItem, null);
                Customer customer = _context.Customers.FirstOrDefault(c => c.Id == CustomerId);
                AddEditWindow EditCustomerWindow = new AddEditWindow("Edit_Customer", _context, customer: customer);
                EditCustomerWindow.ShowDialog();
                CustomersDataGrid.ItemsSource = FetchCustomers();
            }
        }

        private void CustomerDeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var SelectedItem = CustomersDataGrid.SelectedItem;
            
            if (SelectedItem == null) {
                MessageBox.Show("Please choose a customer first!");
            }
            else
            {
                int CustomerId = (int)SelectedItem.GetType().GetProperty("Id").GetValue(SelectedItem, null);
                Customer customer = _context.Customers.FirstOrDefault(c => c.Id == CustomerId);
                MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete {customer.FirstName} {customer.LastName}?", "Are you Sure?", MessageBoxButton.YesNoCancel);

                if (result == MessageBoxResult.Yes) { 
                    _context.Customers.Remove(customer);
                    _context.SaveChanges();
                    CustomersDataGrid.ItemsSource = FetchCustomers();
                    CustomerDetailsTextBlock.Text = "";
                    CustomerImage.Visibility = Visibility.Hidden;
                } else
                {
                    MessageBox.Show("I'm sure you made the best choice :)");
                }
            }
        }
    }
}