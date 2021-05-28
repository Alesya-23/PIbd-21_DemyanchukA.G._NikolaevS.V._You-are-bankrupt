using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
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
using YouBankruptBusinessLogic.BusinessLogics;
using YouBankruptBusinessLogic.ViewModels;

namespace YouBankruptSupplierView
{
    /// <summary>
    /// Логика взаимодействия для WindowCreditProgramTranzaction.xaml
    /// </summary>
    public partial class WindowCreditProgramTranzaction : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        public int TransactionId
        {
            get { return (int)(ComboBoxTranzaction.SelectedItem as TransactionViewModel).Id; }
            set { ComboBoxTranzaction.SelectedItem = SetValueTransaction(value); }
        }

        public int CreditProgramId
        {
            get { return (ComboBoxCreditProgram.SelectedItem as CreditProgramViewModel).Id; }
            set { ComboBoxCreditProgram.SelectedItem = SetValueCreditProgram(value); }
        }

        public int SupplierId { set { supplierId = value; } }

        private int? supplierId;

        private readonly TransactionLogic logicTransaction;

        private readonly CreditProgramLogic logicCreditProgram;

        public WindowCreditProgramTranzaction(TransactionLogic logicTransaction, CreditProgramLogic logicCreditProgram)
        {
            InitializeComponent();
            this.logicTransaction = logicTransaction;
            this.logicCreditProgram = logicCreditProgram;
        }

        private void WindowBindingReciept_Loaded(object sender, RoutedEventArgs e)
        {
            var listTransaction = logicTransaction.Read(null);
            if (logicTransaction != null)
            {
                ComboBoxTranzaction.ItemsSource = listTransaction;
            }
            var listCreditProgram = logicCreditProgram.Read(new CreditProgramBindingModel { SupplierId = supplierId });
            if (listCreditProgram != null)
            {
                ComboBoxCreditProgram.ItemsSource = listCreditProgram;
            }
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private TransactionViewModel SetValueTransaction(int value)
        {
            foreach (var item in ComboBoxTranzaction.Items)
            {
                if ((item as TransactionViewModel).Id == value)
                {
                    return item as TransactionViewModel;
                }
            }
            return null;
        }

        private CreditProgramViewModel SetValueCreditProgram(int value)
        {
            foreach (var item in ComboBoxCreditProgram.Items)
            {
                if ((item as CreditProgramViewModel).Id == value)
                {
                    return item as CreditProgramViewModel;
                }
            }
            return null;
        }

        private void ButtonBind_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxCreditProgram.SelectedValue == null)
            {
                MessageBox.Show("Выберите программу", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (ComboBoxTranzaction.SelectedValue == null)
            {
                MessageBox.Show("Выберите сделку", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                logicCreditProgram.Linking(new CreditProgramLinkingBindingModel
                {
                    CreditingProgramId = (int)(ComboBoxCreditProgram.SelectedItem as CreditProgramViewModel).Id,
                    TransactionId = (int)(ComboBoxTranzaction.SelectedItem as TransactionViewModel).Id
                });
                MessageBox.Show("Привязка прошла успешно", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = false;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
