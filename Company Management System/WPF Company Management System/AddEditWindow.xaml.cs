using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
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
using static DataAccess.Models.IProduct;
using System.IO;
using Microsoft.Win32;
using WPF_Company_Management_System.Models;
using System.Text.RegularExpressions;

namespace WPF_Company_Management_System
{
    /// <summary>
    /// Interaction logic for AddEditWindow.xaml
    /// </summary>
    public partial class AddEditWindow : Window
    {
        enum operations
        {
            AddProduct,
            EditProduct,
            AddEmployee,
            EditEmployee,
            AddCustomer,
            EditCustomer,
        }

        private operations _operation = operations.AddProduct;
        private AppDBContext _passedContext;
        private Product CurrentProduct;
        private Employee CurrentEmployee;
        private Customer CurrentCustomer;
        private string PhotoFileName;
        private categories[] categories = (categories[])Enum.GetValues(typeof(categories));
        private Department[] departments = (Department[])Enum.GetValues(typeof(Department));

        public AddEditWindow(string panel, AppDBContext _context, Product product = null, Employee employee = null, Customer customer = null)
        {
            InitializeComponent();

            _passedContext = _context;
            if (product != null)
            {
                CurrentProduct = product;
            }
            if (employee != null)
            {
                CurrentEmployee = employee;
            }
            if (customer != null)
            {
                CurrentCustomer = customer;
            }

            if (panel.Split("_")[0] == "Add")
            {
                AddWindowInitializer(panel);
            }
            else if (panel.Split("_")[0] == "Edit")
            {
                EditWindowInitializer(panel);
            }
        }

        private void AddWindowInitializer(string PanelMode)
        {
            string AddPanel = PanelMode.Split("_")[1];
            if (AddPanel == "Product")
            {
                WindowTitle.Content = "Add Product";
                ProductDetails.Visibility = Visibility.Visible;
                EmplyeeDetails.Visibility = Visibility.Collapsed;
                CustomerDetails.Visibility = Visibility.Collapsed;
                ProductCategoryComboBox.ItemsSource = categories;
                _operation = operations.AddProduct;
            } else if (AddPanel == "Employee")
            {
                WindowTitle.Content = "Add Employee";
                ProductDetails.Visibility = Visibility.Collapsed;
                EmplyeeDetails.Visibility = Visibility.Visible;
                CustomerDetails.Visibility = Visibility.Collapsed;
                EmployeeDepartmentComboBox.ItemsSource = departments;
                _operation = operations.AddEmployee;
            } else if (AddPanel == "Customer")
            {
                WindowTitle.Content = "Add Customer";
                ProductDetails.Visibility = Visibility.Collapsed;
                EmplyeeDetails.Visibility = Visibility.Collapsed;
                CustomerDetails.Visibility = Visibility.Visible;
                _operation = operations.AddCustomer;
            }
        }

        private void EditWindowInitializer(string PanelMode)
        {
            string EditPanel = PanelMode.Split("_")[1];
            if (EditPanel == "Product")
            {
                WindowTitle.Content = "Edit Product";
                ProductDetails.Visibility = Visibility.Visible;
                EmplyeeDetails.Visibility = Visibility.Collapsed;
                CustomerDetails.Visibility = Visibility.Collapsed;
                _operation = operations.EditProduct;

                ProductCategoryComboBox.ItemsSource = categories;
                ProductNameTextBox.Text = CurrentProduct.Name;
                ProductDescriptionTextBox.Text = CurrentProduct.Description;
                ProductCategoryComboBox.ItemsSource = categories;
                ProductCategoryComboBox.Text = CurrentProduct.Category;
                ProductCountTextBox.Text = CurrentProduct.Count.ToString();
                ProductPriceTextBox.Text = CurrentProduct.Price.ToString();

                ProductChosenPhoto.Source = FetchData.FetchImage(CurrentProduct.PicAddress, "Product");
                ProductPhotoAddressLabel.Visibility = Visibility.Visible;
                ProductPhotoAddressLabel.Content = CurrentProduct.PicAddress;
            }
            else if (EditPanel == "Employee")
            {
                WindowTitle.Content = "Edit Employee";
                ProductDetails.Visibility = Visibility.Collapsed;
                EmplyeeDetails.Visibility = Visibility.Visible;
                CustomerDetails.Visibility = Visibility.Collapsed;
                _operation = operations.EditEmployee;
                
                EmployeeDepartmentComboBox.ItemsSource = departments;
                EmployeeFirstNameTextBox.Text = CurrentEmployee.FirstName;
                EmployeeLastNameTextBox.Text = CurrentEmployee.LastName;
                EmployeeAddressTextBox.Text = CurrentEmployee.Address; 
                EmployeeAgeTextBox.Text = CurrentEmployee.Age.ToString();
                EmployeeEmailTextBox.Text = CurrentEmployee.Email;
                EmployeePhoneNumberTextBox.Text = "0" + CurrentEmployee.PhoneNumber.ToString();
                EmployeeSalaryTextBox.Text = CurrentEmployee.Salary.ToString();
                EmployeeDepartmentComboBox.Text = CurrentEmployee.Department.ToString();

                EmployeeChosenImage.Source = FetchData.FetchImage(CurrentEmployee.PicAddress, "Employee");
                EmployeePhotoAddressLabel.Visibility = Visibility.Visible;
                EmployeePhotoAddressLabel.Content = CurrentEmployee.PicAddress;
            }
            else if (EditPanel == "Customer")
            {
                WindowTitle.Content = "Edit Customer";
                ProductDetails.Visibility = Visibility.Collapsed;
                EmplyeeDetails.Visibility = Visibility.Collapsed;
                CustomerDetails.Visibility = Visibility.Visible;
                _operation = operations.EditCustomer;
                
                CustomerFirstNameTextBox.Text = CurrentCustomer.FirstName;
                CustomerLastNameTextBox.Text = CurrentCustomer.LastName;
                CustomerAddressTextBox.Text = CurrentCustomer.Address;
                CustomerAgeTextBox.Text = CurrentCustomer.Age.ToString();
                CustomerEmailTextBox.Text = CurrentCustomer.Email;
                CustomerPhoneNumberTextBox.Text = "0" + CurrentCustomer.PhoneNumber.ToString();
                CustomerBuyCountTextBox.Text = CurrentCustomer.BuyCount.ToString();

                EmployeeChosenImage.Source = FetchData.FetchImage(CurrentCustomer.PicAddress, "Customer");
                EmployeePhotoAddressLabel.Visibility = Visibility.Visible;
                EmployeePhotoAddressLabel.Content = CurrentCustomer.PicAddress;
            }
        }


        // Save Button
        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {

            // Add Operations
            if (_operation == operations.AddProduct)
            {
                string ProductName = ProductNameTextBox.Text;
                string ProductDescription = ProductDescriptionTextBox.Text;
                string ProductCategory = ProductCategoryComboBox.Text;
                int ProductCount = Convert.ToInt32(ProductCountTextBox.Text);
                double ProductPrice = Convert.ToDouble(ProductPriceTextBox.Text);

                if (string.IsNullOrEmpty(ProductName) || string.IsNullOrEmpty(ProductDescription)
                    || string.IsNullOrEmpty(ProductCategory) || string.IsNullOrEmpty(ProductCount.ToString())
                    || string.IsNullOrEmpty(ProductPrice.ToString()))
                {
                    MessageBox.Show("Please Fill All The Fields!!!");
                }
                else
                {
                    var NewProduct = new Product
                    {
                        Name = ProductName,
                        Description = ProductDescription,
                        Category = ProductCategory,
                        Count = ProductCount,
                        PicAddress = PhotoFileName == null ? "" : $".\\Resources\\ProductsImages\\{PhotoFileName}",
                        Price = ProductPrice
                    };

                    _passedContext.Products.Add(NewProduct);
                    _passedContext.SaveChanges();
                    this.Close();
                }


            }
            else if (_operation == operations.AddEmployee)
            {
                string EmployeeFirstName = EmployeeFirstNameTextBox.Text;
                string EmployeeLastName = EmployeeLastNameTextBox.Text;
                double EmployeeSalary = Convert.ToDouble(EmployeeSalaryTextBox.Text);
                int EmployeeAge = Convert.ToInt32(EmployeeAgeTextBox.Text);
                decimal EmployeePhoneNumber = Convert.ToDecimal(EmployeePhoneNumberTextBox.Text);
                string EmployeeEmail = EmployeeEmailTextBox.Text;
                string EmployeeAddress = EmployeeAddressTextBox.Text;
                Department DepartmentEnumValue;
                Enum.TryParse(EmployeeDepartmentComboBox.Text, out DepartmentEnumValue);
                Department EmployeeDepartment = DepartmentEnumValue;
                string EmployeePicAddress = PhotoFileName == null ? "" : $".\\Resources\\EmployeesImages\\{PhotoFileName}";

                if (string.IsNullOrEmpty(EmployeeFirstName) || string.IsNullOrEmpty(EmployeeLastName)
                    || string.IsNullOrEmpty(EmployeeEmail) || string.IsNullOrEmpty(EmployeeSalary.ToString())
                    || string.IsNullOrEmpty(EmployeePhoneNumber.ToString()) || string.IsNullOrEmpty(EmployeeAge.ToString())
                    || string.IsNullOrEmpty(EmployeeDepartment.ToString()))
                {
                    MessageBox.Show("Please Fill All The Fields!!!");
                }
                else
                {
                    Employee NewEmployee = new Employee
                    {
                        FirstName = EmployeeFirstName,
                        LastName = EmployeeLastName,
                        Salary = EmployeeSalary,
                        Age = EmployeeAge,
                        PhoneNumber = EmployeePhoneNumber,
                        Email = EmployeeEmail,
                        Address = EmployeeAddress,
                        Department = EmployeeDepartment,
                        PicAddress = EmployeePicAddress
                    };

                    _passedContext.Employees.Add(NewEmployee);
                    _passedContext.SaveChanges();
                    this.Close();
                };

            }
            else if (_operation == operations.AddCustomer)
            {
                string CustomerFirstName = CustomerFirstNameTextBox.Text;
                string CustomerLastName = CustomerLastNameTextBox.Text;
                string CustomerAddress = CustomerAddressTextBox.Text;
                int CustomerAge = Convert.ToInt32(CustomerAgeTextBox.Text);
                decimal CustomerPhoneNumber = Convert.ToDecimal(CustomerPhoneNumberTextBox.Text);
                int CustomerBuyCount = Convert.ToInt32(CustomerBuyCountTextBox.Text);
                string CustomerEmail = CustomerEmailTextBox.Text;
                string CustomerPicAddress = PhotoFileName == null ? "" : $".\\Resources\\CustomersImages\\{PhotoFileName}";

                if (string.IsNullOrEmpty(CustomerFirstName) || string.IsNullOrEmpty(CustomerLastName)
                    || string.IsNullOrEmpty(CustomerAddress) || string.IsNullOrEmpty(CustomerAge.ToString())
                    || string.IsNullOrEmpty(CustomerPhoneNumber.ToString()) || string.IsNullOrEmpty(CustomerBuyCount.ToString())
                    || string.IsNullOrEmpty(CustomerEmail))
                {
                    MessageBox.Show("Please Fill All The Fields!!!");
                }
                else
                {
                    Customer NewCustomer = new Customer
                    {
                        FirstName = CustomerFirstName,
                        LastName = CustomerLastName,
                        Age = CustomerAge,
                        PhoneNumber = CustomerPhoneNumber,
                        Email = CustomerEmail,
                        Address = CustomerAddress,
                        BuyCount = CustomerBuyCount,
                        PicAddress = CustomerPicAddress
                    };

                    _passedContext.Customers.Add(NewCustomer);
                    _passedContext.SaveChanges();
                    this.Close();
                }

            }

            // Edit Operations
            else if (_operation == operations.EditProduct)
            {
                string ProductName = ProductNameTextBox.Text;
                string ProductDescription = ProductDescriptionTextBox.Text;
                string ProductCategory = ProductCategoryComboBox.Text;
                int ProductCount = Convert.ToInt32(ProductCountTextBox.Text);
                double ProductPrice = Convert.ToDouble(ProductPriceTextBox.Text);
                
                if (string.IsNullOrEmpty(ProductName) || string.IsNullOrEmpty(ProductDescription)
                    || string.IsNullOrEmpty(ProductCategory) || string.IsNullOrEmpty(ProductCount.ToString())
                    || string.IsNullOrEmpty(ProductPrice.ToString()))
                {
                    MessageBox.Show("Please Fill All The Fields!!!");
                }
                else
                { 
                    Product product = _passedContext.Products.Where(p => p.Id == CurrentProduct.Id).FirstOrDefault();
                    product.Name = ProductName;
                    product.Name = ProductName;
                    product.Description = ProductDescription;
                    product.Category = ProductCategory;
                    product.Count = ProductCount;
                    product.PicAddress = PhotoFileName == null ? product.PicAddress : $".\\Resources\\ProductsImages\\{PhotoFileName}" ;
                    product.Price = ProductPrice;

                    _passedContext.SaveChanges();
                    this.Close();
                }

            }
            else if (_operation == operations.EditEmployee)
            {
                string EmployeeFirstName = EmployeeFirstNameTextBox.Text;
                string EmployeeLastName = EmployeeLastNameTextBox.Text;
                string EmployeeAddress = EmployeeAddressTextBox.Text;
                int EmployeeAge = Convert.ToInt32(EmployeeAgeTextBox.Text);
                string EmployeeEmail = EmployeeEmailTextBox.Text;
                decimal EmployeePhoneNumber = Convert.ToDecimal(EmployeePhoneNumberTextBox.Text);
                double EmployeeSalary = Convert.ToDouble(EmployeeSalaryTextBox.Text);
                Department EmployeeDepartmentValue;
                Enum.TryParse(EmployeeDepartmentComboBox.Text, out EmployeeDepartmentValue);
                Department EmployeeDepartment = EmployeeDepartmentValue;

                if (string.IsNullOrEmpty(EmployeeFirstName) || string.IsNullOrEmpty(EmployeeLastName)
                    || string.IsNullOrEmpty(EmployeeEmail) || string.IsNullOrEmpty(EmployeeSalary.ToString())
                    || string.IsNullOrEmpty(EmployeePhoneNumber.ToString()) || string.IsNullOrEmpty(EmployeeAge.ToString())
                    || string.IsNullOrEmpty(EmployeeDepartment.ToString()))
                {
                    MessageBox.Show("Please Fill All The Fields!!!");
                }
                else
                { 
                    Employee employee = _passedContext.Employees.Where(emp => emp.Id == CurrentEmployee.Id).FirstOrDefault();
                    employee.FirstName = EmployeeFirstName;
                    employee.LastName = EmployeeLastName;
                    employee.Address = EmployeeAddress;
                    employee.Email = EmployeeEmail;
                    employee.PhoneNumber = EmployeePhoneNumber;
                    employee.Salary = EmployeeSalary;
                    employee.Age = EmployeeAge;
                    employee.Department = EmployeeDepartment;
                    employee.PicAddress = PhotoFileName == null ? employee.PicAddress : $".\\Resources\\EmployeesImages\\{PhotoFileName}";
                
                    _passedContext.SaveChanges();
                    this.Close();
                }

            }
            else if (_operation == operations.EditCustomer)
            {
                string CustomerFirstName = CustomerFirstNameTextBox.Text;
                string CustomerLastName = CustomerLastNameTextBox.Text;
                string CustomerAddress = CustomerAddressTextBox.Text;
                int CustomerAge = Convert.ToInt32(CustomerAgeTextBox.Text);
                decimal CustomerPhoneNumber = Convert.ToDecimal(CustomerPhoneNumberTextBox.Text);
                int CustomerBuyCount = Convert.ToInt32(CustomerBuyCountTextBox.Text);
                string CustomerEmail = CustomerEmailTextBox.Text;
                string CustomerPicAddress = PhotoFileName == null ? "" : $".\\Resources\\CustomersImages\\{PhotoFileName}";

                if (string.IsNullOrEmpty(CustomerFirstName) || string.IsNullOrEmpty(CustomerLastName)
                    || string.IsNullOrEmpty(CustomerAddress) || string.IsNullOrEmpty(CustomerAge.ToString())
                    || string.IsNullOrEmpty(CustomerPhoneNumber.ToString()) || string.IsNullOrEmpty(CustomerBuyCount.ToString())
                    || string.IsNullOrEmpty(CustomerEmail))
                {
                    MessageBox.Show("Please Fill All The Fields!!!");
                }
                else
                {
                    Customer customer = _passedContext.Customers.Where(c => c.Id == CurrentCustomer.Id).FirstOrDefault();
                    customer.FirstName = CustomerFirstName;
                    customer.LastName = CustomerLastName;
                    customer.Address = CustomerAddress;
                    customer.Email = CustomerEmail;
                    customer.PhoneNumber = CustomerPhoneNumber;
                    customer.BuyCount = CustomerBuyCount;
                    customer.Age = CustomerAge;
                    customer.PicAddress = PhotoFileName == null ? customer.PicAddress : $".\\Resources\\CustomersImages\\{PhotoFileName}";

                    _passedContext.SaveChanges();
                    this.Close();
                }

            }
        }

        // Handling Photos
        private (string SelectedFile, string FileName, string DestinationPath)? PhotoDialog(string Category)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";

            if (openFileDialog.ShowDialog() == true)
            {
                string SelectedFile = openFileDialog.FileName;
                string DestinationFolder = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources");

                if (Category == "Product") { DestinationFolder += "\\ProductsImages"; }
                if (Category == "Employee") { DestinationFolder += "\\EmployeesImages"; }
                if (Category == "Customer") { DestinationFolder += "\\CustomersImages"; }

                if (!Directory.Exists(DestinationFolder))
                {
                    Directory.CreateDirectory(DestinationFolder);
                }

                string FileName = System.IO.Path.GetFileName(SelectedFile);
                string DestinationPath = System.IO.Path.Combine(DestinationFolder, FileName);
                File.Copy(SelectedFile, DestinationPath, true);

                return (SelectedFile, FileName, DestinationPath);
            }

            return null;
        }


        private void ProductPhotoButton_Click(object sender, RoutedEventArgs e)
        {

            var PhotoDetails = PhotoDialog("Product");
            if (PhotoDetails.HasValue)
            {
                var (SelectedFile, FileName, DestinationPath) = PhotoDetails.Value;
                ProductPhotoAddressLabel.Visibility = Visibility.Visible;
                ProductPhotoAddressLabel.Content = SelectedFile;
                ProductChosenPhoto.Source = FetchData.FetchImage($".\\Resources\\ProductsImages\\{FileName}", "Product");
                PhotoFileName = FileName;
            }
        }

        private void EmployeePhotoButton_Click(object sender, RoutedEventArgs e)
        {
            var PhotoDetails = PhotoDialog("Employee");
            if (PhotoDetails.HasValue)
            {
                var (SelectedFile, FileName, DestinationPath) = PhotoDetails.Value;
                EmployeePhotoAddressLabel.Visibility = Visibility.Visible;
                EmployeePhotoAddressLabel.Content = SelectedFile;
                EmployeeChosenImage.Source = FetchData.FetchImage($".\\Resources\\EmployeesImages\\{FileName}", "Employee");
                PhotoFileName = FileName;
            }
        }

        private void CustomerPhotoButton_Click(object sender, RoutedEventArgs e)
        {
            var PhotoDetails = PhotoDialog("Customer");
            if (PhotoDetails.HasValue)
            {
                var (SelectedFile, FileName, DestinationPath) = PhotoDetails.Value;
                CustomerPhotoAddressLabel.Visibility = Visibility.Visible;
                CustomerPhotoAddressLabel.Content = SelectedFile;
                CustomerChosenImage.Source = FetchData.FetchImage($".\\Resources\\CustomersImages\\{FileName}", "Customer");
                PhotoFileName = FileName;
            }
        }

        // Validation
        private void EmailTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            string email = "";
            if (EmplyeeDetails.Visibility == Visibility.Visible) { email = EmployeeEmailTextBox.Text; };
            if (CustomerDetails.Visibility == Visibility.Visible) { email = CustomerEmailTextBox.Text; };
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            if (Regex.IsMatch(email, emailPattern))
            {
                if (EmplyeeDetails.Visibility == Visibility.Visible) {EmployeeEmailTextBox.Foreground = new SolidColorBrush(Colors.Green); };
                if (CustomerDetails.Visibility == Visibility.Visible) { CustomerEmailTextBox.Foreground = new SolidColorBrush(Colors.Green); };
                CustomerEmailValidationWarnLabel.Visibility = Visibility.Hidden;
            }
            else
            {
                if (EmplyeeDetails.Visibility == Visibility.Visible) { EmployeeEmailTextBox.Foreground = new SolidColorBrush(Colors.Red); };
                if (CustomerDetails.Visibility == Visibility.Visible) { CustomerEmailTextBox.Foreground = new SolidColorBrush(Colors.Red); };
                CustomerEmailValidationWarnLabel.Visibility = Visibility.Visible;
            }
        }

        private void SalaryTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (decimal.TryParse(EmployeeSalaryTextBox.Text, out decimal salary) && salary >= 0)
            {
                EmployeeSalaryTextBox.Foreground = new SolidColorBrush(Colors.Green);
                SalaryValidationWarnLabel.Visibility = Visibility.Hidden;
            }
            else
            {
                EmployeeSalaryTextBox.Foreground = new SolidColorBrush(Colors.Red);
                SalaryValidationWarnLabel.Visibility = Visibility.Visible;
            }
        }

        private void PhoneNumberTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string phoneNumber = "";
            if (EmplyeeDetails.Visibility == Visibility.Visible) { phoneNumber = EmployeePhoneNumberTextBox.Text; };
            if (CustomerDetails.Visibility == Visibility.Visible) { phoneNumber = CustomerPhoneNumberTextBox.Text; };
            string phonePattern = @"^\d{11}$"; // Adjust based on your country's phone number format

            if (Regex.IsMatch(phoneNumber, phonePattern))
            {
                if (EmplyeeDetails.Visibility == Visibility.Visible) { EmployeePhoneNumberTextBox.Foreground = new SolidColorBrush(Colors.Green); };
                if (CustomerDetails.Visibility == Visibility.Visible) { CustomerPhoneNumberTextBox.Foreground = new SolidColorBrush(Colors.Green); };
                PhoneNumberValidationWarnLabel.Visibility = Visibility.Hidden;
            }
            else
            {
                if (EmplyeeDetails.Visibility == Visibility.Visible) { EmployeePhoneNumberTextBox.Foreground = new SolidColorBrush(Colors.Red); };
                if (CustomerDetails.Visibility == Visibility.Visible) { CustomerPhoneNumberTextBox.Foreground = new SolidColorBrush(Colors.Red); };
                PhoneNumberValidationWarnLabel.Visibility = Visibility.Visible;
            }
        }

    }
}
