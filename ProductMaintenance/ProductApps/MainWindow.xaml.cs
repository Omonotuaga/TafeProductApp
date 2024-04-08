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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProductApps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Product cProduct;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            double priceTextBox1, quantityTextBox1, totalPrice1, totalPrice2, totalPrice3;
            try
            {
                cProduct = new Product(Convert.ToDecimal(priceTextBox.Text), Convert.ToInt16(quantityTextBox.Text));
                cProduct.calTotalPayment();
                totalPayment.Text = Convert.ToString(cProduct.TotalPayment);
            }
            catch (FormatException)
            {
                MessageBox.Show("Enter data again", "Data Entry Error");
            }

            priceTextBox1 = double.Parse(priceTextBox.Text);
            quantityTextBox1 = double.Parse(quantityTextBox.Text);

            totalPrice1 = priceTextBox1 * quantityTextBox1;
            totalPayment.Text = totalPrice1.ToString("C");

            //“Added the delivery charge $25”.
            totalPrice2 = totalPrice1 + 25;
            totalChargeTextBox.Text = totalPrice2.ToString("C");

            totalPrice3 = totalPrice2 + 5;
            totalWrappingTextBox.Text = totalPrice3.ToString("C");

        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            productTextBox.Text = "";
            priceTextBox.Text = "";
            quantityTextBox.Text = "";
            totalPayment.Text = "";
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
