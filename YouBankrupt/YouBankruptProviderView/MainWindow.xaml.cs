using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace YouBankruptCustomerView
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TransactionWithCustomerItem_Click(object sender, RoutedEventArgs e)
        {
            new FormTransactionWithCustomer().ShowDialog();
        }

        private void PaymentItem_Click(object sender, RoutedEventArgs e)
        {
            new FormPayment().ShowDialog();
        }

        private void CreditingItem_Click(object sender, RoutedEventArgs e)
        {
            new FormCrediting().ShowDialog();
        }

        private void ListItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Report_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
