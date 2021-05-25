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
using Unity;
using YouBankruptBusinessLogic.BindingModels;
using YouBankruptBusinessLogic.BusinessLogic;

namespace YouBankruptProviderView
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private int? id;

        private CustomerLogic _logic;

        public MainWindow(CustomerLogic logic)
        {
            InitializeComponent();
            this._logic = logic;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            var customer = _logic.Read(new CustomerBindingModel { Id = id })?[0];
            Lable_Customer.Content = "Заказчик: " + customer.Email + " ФИО: " + customer.CustomerFullName;
        }

        private void TransactionWithCustomerItem_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<FormTransactionWithCustomers>();
            window.Id = (int)id;
            window.ShowDialog();
        }

        private void PaymentItem_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<FormPayments>();
            window.Id = (int)id;
            window.ShowDialog();
        }

        private void CreditingItem_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<FormCreditings>();
            window.Id = (int)id;
            window.ShowDialog();
        }

        private void ListItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Report_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
