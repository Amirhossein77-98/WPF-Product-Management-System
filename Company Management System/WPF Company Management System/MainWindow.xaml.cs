using System;
using System.Diagnostics;
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
using WPF_Company_Management_System.Models;

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

        // Home Section Logic
        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {
            HomePanel.Visibility = Visibility.Visible;
            ProductsPanel.Visibility = Visibility.Collapsed;
            EmployeesPanel.Visibility = Visibility.Collapsed;
            CustomersPanel.Visibility = Visibility.Collapsed;
        }

        // Product Section Logic
        private void ProductsBtn_Click(object sender, RoutedEventArgs e)
        {
            HomePanel.Visibility = Visibility.Collapsed;
            ProductsPanel.Visibility = Visibility.Visible;
            EmployeesPanel.Visibility = Visibility.Collapsed;
            CustomersPanel.Visibility = Visibility.Collapsed;
            ProductsDataGrid.ItemsSource = FetchData.FetchProducts(_context);
        }

        private void ProductsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var SelectedRow = ProductsDataGrid.SelectedItem;
            
            if (SelectedRow != null) 
            {
                int ProductId = (int)SelectedRow.GetType().GetProperty("Id").GetValue(SelectedRow, null);
                Product? product = _context.Products.FirstOrDefault(p => p.Id == ProductId);

                ProductsDetails.Text = Product.GetProductDetailString(product.Name, product.Description, product.Category, product.Count, product.Price);
                ProductsImage.Visibility = Visibility.Visible;
                ProductsImage.Source = FetchData.FetchImage(product.PicAddress, "Product");
            }
            else {
                ProductsDetails.Text = "Nothing Found!";
                ProductsImage.Source = null;
            }
        }

        private void ProductAddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEditWindow AddWindow = new AddEditWindow(panel: "Add_Product", _context: _context);
            AddWindow.ShowDialog();
            ProductsDataGrid.ItemsSource = FetchData.FetchProducts(_context);
        }

        private void ProductEditBtn_Click(object sender, RoutedEventArgs e)
        {
            var SelectedRow = ProductsDataGrid.SelectedItem;
            if (SelectedRow == null)
            {
                MessageBox.Show("Please choose a product!");
            } else
            {
                int ProductId = (int)SelectedRow.GetType().GetProperty("Id").GetValue(SelectedRow, null);
                Product product = _context.Products.FirstOrDefault(p => p.Id == ProductId);
                AddEditWindow EditWindow = new AddEditWindow(panel: "Edit_Product", _context: _context, product: product);
                EditWindow.ShowDialog();
                ProductsDataGrid.ItemsSource = FetchData.FetchProducts(_context);
            }
        }

        private void ProductDeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var SelectedRow = ProductsDataGrid.SelectedItem;

            if (SelectedRow != null)
            {
                int ProductId = (int)SelectedRow.GetType().GetProperty("Id").GetValue(SelectedRow, null);
                Product product = _context.Products.FirstOrDefault(p => p.Id == ProductId);
                
                MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete this {product.Name}?", "Delete Product?", MessageBoxButton.YesNoCancel);
                
                if (result == MessageBoxResult.Yes)
                {
                    _context.Products.Remove(product);
                    _context.SaveChanges();
                    ProductsDataGrid.ItemsSource = FetchData.FetchProducts(_context);
                    ProductsDetails.Text = "";
                    ProductsImage.Visibility = Visibility.Hidden;
                }
                else
                {
                    MessageBox.Show("I'm sure you made the best choice :)");
                }
            }
            else
            {
                MessageBox.Show("Please choose a product!");
            }
        }


        // Employee Section Logic
        private void EmployeesBtn_Click(object sender, RoutedEventArgs e)
        {
            HomePanel.Visibility = Visibility.Collapsed;
            ProductsPanel.Visibility = Visibility.Collapsed;
            EmployeesPanel.Visibility = Visibility.Visible;
            CustomersPanel.Visibility = Visibility.Collapsed;
            EmployeesDataGrid.ItemsSource = FetchData.FetchEmployees(_context);
        }

        private void EmployeesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var SelectedRow = EmployeesDataGrid.SelectedItem;

            if (SelectedRow != null)
            {
                int EmployeeId = (int)SelectedRow.GetType().GetProperty("Id").GetValue(SelectedRow, null);
                Employee employee = _context.Employees.FirstOrDefault(emp => emp.Id == EmployeeId);

                EmployeeDetailsTextBlock.Text = Employee.GetEmployeeDetailString
                    (employee.FirstName, 
                    employee.LastName,
                    employee.Age,
                    employee.Email,
                    employee.PhoneNumber,
                    employee.Address,
                    employee.Department.ToString(), 
                    employee.Salary.ToString());
                ProductsImage.Visibility = Visibility.Visible;
                EmployeeImage.Source = FetchData.FetchImage(employee.PicAddress, "Employee");
            }
            else
            {
                ProductsDetails.Text = "Nothing Found!";
                ProductsImage.Source = null;
            }

        }

        private void EmployeeAddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEditWindow AddEmployeeWindow = new AddEditWindow(panel: "Add_Employee", _context: _context);
            AddEmployeeWindow.ShowDialog();
            EmployeesDataGrid.ItemsSource = FetchData.FetchEmployees(_context);
        }

        private void EmployeeEditBtn_Click(object sender, RoutedEventArgs e)
        {
            var SelectdRow = EmployeesDataGrid.SelectedItem;
            if (SelectdRow == null)
            {
                MessageBox.Show("Please choose an employee first!");
            } else
            {
                int EmployeeId = (int)SelectdRow.GetType().GetProperty("Id").GetValue(SelectdRow, null);
                Employee employee = _context.Employees.FirstOrDefault(e => e.Id == EmployeeId);
                AddEditWindow EditEmployeeWindow = new AddEditWindow(panel: "Edit_Employee", _context: _context, employee: employee);
                EditEmployeeWindow.ShowDialog();
                EmployeesDataGrid.ItemsSource = FetchData.FetchEmployees(_context);
            }
        }

        private void EmployeeDeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var SelectedRow = EmployeesDataGrid.SelectedItem;
            
            if (SelectedRow != null)
            {
                int EmployeeId = (int)SelectedRow.GetType().GetProperty("Id").GetValue(SelectedRow, null);
                Employee employee = _context.Employees.FirstOrDefault(emp => emp.Id == EmployeeId);
                
                MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete {employee.FirstName} {employee.LastName}?", "Delete Employee?", MessageBoxButton.YesNoCancel);
                
                if (result == MessageBoxResult.Yes)
                {
                    _context.Employees.Remove(employee);
                    _context.SaveChanges();
                    EmployeesDataGrid.ItemsSource = FetchData.FetchEmployees(_context);
                    EmployeeDetailsTextBlock.Text = "";
                    EmployeeImage.Visibility = Visibility.Hidden;
                }
                else 
                {
                    MessageBox.Show("I think you made a better choice :)");
                }
            } else
            {
                MessageBox.Show("Please choose an employee first!");
            }

        }

        // Customer Section Logic
        private void CustomersBtn_Click(object sender, RoutedEventArgs e)
        {
            HomePanel.Visibility = Visibility.Collapsed;
            ProductsPanel.Visibility = Visibility.Collapsed;
            EmployeesPanel.Visibility = Visibility.Collapsed;
            CustomersPanel.Visibility = Visibility.Visible;
            CustomersDataGrid.ItemsSource = FetchData.FetchCustomers(_context);
        }

        private void CustomersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var SelectedRow = CustomersDataGrid.SelectedItem;
            if (SelectedRow != null) {
                int CustomerId = (int)SelectedRow.GetType().GetProperty("Id").GetValue(SelectedRow, null);
                Customer customer = _context.Customers.FirstOrDefault(customer => customer.Id == CustomerId);

                CustomerDetailsTextBlock.Text = Customer.GetEmployeeDetailString(customer.FirstName,customer.LastName,customer.Age,customer.BuyCount,customer.Email,customer.PhoneNumber,customer.Address);
                ProductsImage.Visibility = Visibility.Visible;
                CustomerImage.Source = FetchData.FetchImage(customer.PicAddress, "Customer");
            }
            else
            {
                ProductsDetails.Text = "Nothing Found!";
                ProductsImage.Source = null;
            }
        }

        private void AddNewCustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            AddEditWindow AddCustomerWindow = new AddEditWindow("Add_Customer", _context);
            AddCustomerWindow.ShowDialog();
            CustomersDataGrid.ItemsSource = FetchData.FetchCustomers(_context);
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
                CustomersDataGrid.ItemsSource = FetchData.FetchCustomers(_context);
            }
        }

        private void CustomerDeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var SelectedItem = CustomersDataGrid.SelectedItem;
            
            if (SelectedItem != null) {
                int CustomerId = (int)SelectedItem.GetType().GetProperty("Id").GetValue(SelectedItem, null);
                Customer customer = _context.Customers.FirstOrDefault(c => c.Id == CustomerId);
                
                MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete {customer.FirstName} {customer.LastName}?", "Are you Sure?", MessageBoxButton.YesNoCancel);

                if (result == MessageBoxResult.Yes) { 
                    _context.Customers.Remove(customer);
                    _context.SaveChanges();
                    CustomersDataGrid.ItemsSource = FetchData.FetchCustomers(_context);
                    CustomerDetailsTextBlock.Text = "";
                    CustomerImage.Visibility = Visibility.Hidden;
                } else
                {
                    MessageBox.Show("I'm sure you made the best choice :)");
                }
            }
            else
            {
                MessageBox.Show("Please choose a customer first!");
            }
        }
    }
}