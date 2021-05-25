using System;
using System.Collections.Generic;
using System.Windows;
using Unity;
using YouBankruptBusinessLogic.BusinessLogic;
using YouBankruptBusinessLogic.ViewModels;

namespace YouBankruptProviderView
{
    /// <summary>
    /// Логика взаимодействия для FormCreditingPaymennts.xaml
    /// </summary>
    public partial class FormCreditingPayments : Window
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id
        {
            get { return (int)(comboBoxPayment.SelectedItem as PaymentViewModel).Id; }
            set { comboBoxPayment.SelectedValue = value; }
        }

        public int CustomerId { set { id = value; } }

        public int Sum { get { return ((PaymentViewModel)comboBoxPayment.SelectedItem).Sum; } }

        public DateTime DatePayment { get { return (DateTime)((PaymentViewModel)comboBoxPayment.SelectedItem).DatePayment; } }

        private int? id;

        public FormCreditingPayments(PaymentLogic logic)
        {
            InitializeComponent();
            List<PaymentViewModel> list = logic.Read(null);
            if(list != null)
            {
                comboBoxPayment.DisplayMemberPath = "Id";
                comboBoxPayment.ItemsSource = list;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxPayment.SelectedValue == null)
            {
                MessageBox.Show("Укажите выплату", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            DialogResult = true;
            Close();
        }

        private void btnCancle_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
