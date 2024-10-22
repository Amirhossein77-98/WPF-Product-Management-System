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
                ProductCategoryComboBox.ItemsSource = categories;
                _operation = operations.EditProduct;
                ProductNameTextBox.Text = CurrentProduct.Name;
                ProductDescriptionTextBox.Text = CurrentProduct.Description;
                ProductCategoryComboBox.ItemsSource = categories;
                ProductCategoryComboBox.Text = CurrentProduct.Category;
                ProductCountTextBox.Text = CurrentProduct.Count.ToString();
                ProductPriceTextBox.Text = CurrentProduct.Price.ToString();

                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri($"{CurrentProduct.PicAddress}", UriKind.RelativeOrAbsolute);
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                ProductChosenPhoto.Source = bitmapImage;
                ProductPhotoAddressLabel.Visibility = Visibility.Visible;
                ProductPhotoAddressLabel.Content = CurrentProduct.PicAddress;
            }
            else if (EditPanel == "Employee")
            {
                WindowTitle.Content = "Edit Employee";
                ProductDetails.Visibility = Visibility.Collapsed;
                EmplyeeDetails.Visibility = Visibility.Visible;
                CustomerDetails.Visibility = Visibility.Collapsed;
                EmployeeDepartmentComboBox.ItemsSource = departments;
                _operation = operations.EditEmployee;
                EmployeeFirstNameTextBox.Text = CurrentEmployee.FirstName;
                EmployeeLastNameTextBox.Text = CurrentEmployee.LastName;
                EmployeeAddressTextBox.Text = CurrentEmployee.Address; 
                EmployeeAgeTextBox.Text = CurrentEmployee.Age.ToString();
                EmployeeEmailTextBox.Text = CurrentEmployee.Email;
                EmployeePhoneNumberTextBox.Text = CurrentEmployee.PhoneNumber.ToString();
                EmployeeSalaryTextBox.Text = CurrentEmployee.Salary.ToString();
                EmployeeDepartmentComboBox.Text = CurrentEmployee.Department.ToString();

                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri($"{CurrentEmployee.PicAddress}", UriKind.RelativeOrAbsolute);
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                EmployeeChosenImage.Source = bitmapImage;
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
                CustomerPhoneNumberTextBox.Text = CurrentCustomer.PhoneNumber.ToString();
                CustomerBuyCountTextBox.Text = CurrentCustomer.BuyCount.ToString();

                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri($"{CurrentCustomer.PicAddress}", UriKind.RelativeOrAbsolute);
                bitmapImage.CacheOption= BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                EmployeeChosenImage.Source = bitmapImage;
                EmployeePhotoAddressLabel.Visibility = Visibility.Visible;
                EmployeePhotoAddressLabel.Content = CurrentCustomer.PicAddress;
            }
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
                    PicAddress = PhotoFileName == null ? "" : $".\\Resources\\ProductsImages\\{PhotoFileName}",
                    Price = ProductPrice
                };
                _passedContext.Products.Add(NewProduct);
                _passedContext.SaveChanges();
                this.Close();

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

                Employee NewEmployee = new Employee {
                    FirstName = EmployeeFirstName,
                    LastName = EmployeeLastName,
                    Salary = EmployeeSalary,
                    Age = EmployeeAge,
                    PhoneNumber = EmployeePhoneNumber,
                    Email = EmployeeEmail,
                    Address = EmployeeAddress,
                    Department = EmployeeDepartment,
                    PicAddress= EmployeePicAddress
                };

                _passedContext.Employees.Add(NewEmployee);
                _passedContext.SaveChanges();
                this.Close();
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
            else if (_operation == operations.EditProduct)
            {
                string ProductName = ProductNameTextBox.Text;
                string ProductDescription = ProductDescriptionTextBox.Text;
                string ProductCategory = ProductCategoryComboBox.Text;
                int ProductCount = Convert.ToInt32(ProductCountTextBox.Text);
                double ProductPrice = Convert.ToDouble(ProductPriceTextBox.Text);
                
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

        private void ProductPhotoButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";

            if (openFileDialog.ShowDialog() == true)
            {
                string SelectedFile = openFileDialog.FileName;
                string DestinationFolder = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources\\ProductsImages");

                if (!Directory.Exists(DestinationFolder))
                {
                    Directory.CreateDirectory(DestinationFolder);
                }

                string FileName = System.IO.Path.GetFileName(SelectedFile);
                string destinationPath = System.IO.Path.Combine(DestinationFolder, FileName);

                ProductPhotoAddressLabel.Visibility = Visibility.Visible;
                ProductPhotoAddressLabel.Content = SelectedFile;
                File.Copy(SelectedFile, destinationPath, true);
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri($".\\Resources\\ProductsImages\\{FileName}", UriKind.RelativeOrAbsolute);
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                ProductChosenPhoto.Source = bitmapImage;
                PhotoFileName = FileName;
            }
        }

        private void EmployeePhotoButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";

            if (openFileDialog.ShowDialog() == true)
            {
                string SelectedFile = openFileDialog.FileName;
                string DestinationFolder = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources\\EmployeesImages");

                if (!Directory.Exists(DestinationFolder))
                {
                    Directory.CreateDirectory(DestinationFolder);
                }

                string FileName = System.IO.Path.GetFileName(SelectedFile);
                string destinationPath = System.IO.Path.Combine(DestinationFolder, FileName);

                EmployeePhotoAddressLabel.Visibility = Visibility.Visible;
                EmployeePhotoAddressLabel.Content = SelectedFile;
                File.Copy(SelectedFile, destinationPath, true);

                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri($".\\Resources\\EmployeesImages\\{FileName}", UriKind.RelativeOrAbsolute);
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                EmployeeChosenImage.Source = bitmapImage;
                PhotoFileName = FileName;
            }
        }

        private void CustomerPhotoButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";

            if (openFileDialog.ShowDialog() == true)
            {
                string SelectedFile = openFileDialog.FileName;
                string DestinationFolder = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources\\CustomersImages");

                if (!Directory.Exists(DestinationFolder))
                {
                    Directory.CreateDirectory(DestinationFolder);
                }

                string FileName = System.IO.Path.GetFileName(SelectedFile);
                string destinationPath = System.IO.Path.Combine(DestinationFolder, FileName);

                CustomerPhotoAddressLabel.Visibility = Visibility.Visible;
                CustomerPhotoAddressLabel.Content = SelectedFile;
                File.Copy(SelectedFile, destinationPath, true);

                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri($".\\Resources\\CustomersImages\\{FileName}", UriKind.RelativeOrAbsolute);
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                CustomerChosenImage.Source = bitmapImage;
                PhotoFileName = FileName;

            }
        }
    }
}
