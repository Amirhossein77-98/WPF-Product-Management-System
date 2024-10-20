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

namespace WPF_Company_Management_System
{
    /// <summary>
    /// Interaction logic for AddEditWindow.xaml
    /// </summary>
    public partial class AddEditWindow : Window
    {
        public AddEditWindow(string panel)
        {
            InitializeComponent();

            if (panel == "AddProduct")
            {
                WindowTitle.Content = "Add Product";
                ProductDetails.Visibility = Visibility.Visible;
                EmplyeeDetails.Visibility = Visibility.Collapsed;
                CustomerDetails.Visibility = Visibility.Collapsed;
            } else if (panel == "AddEmployee")
            {
                WindowTitle.Content = "Add Employee";
                ProductDetails.Visibility = Visibility.Collapsed;
                EmplyeeDetails.Visibility = Visibility.Visible;
                CustomerDetails.Visibility = Visibility.Collapsed;
            } else if (panel == "AddCustomer")
            {
                WindowTitle.Content = "Add Customer";
                ProductDetails.Visibility = Visibility.Collapsed;
                EmplyeeDetails.Visibility = Visibility.Collapsed;
                CustomerDetails.Visibility = Visibility.Visible;
            }
        }
    }
}
