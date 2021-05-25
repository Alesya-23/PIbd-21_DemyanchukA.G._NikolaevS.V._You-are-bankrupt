using System;
using System.Windows;
using Unity;
using YouBankruptBusinessLogic.BindingModels;
using YouBankruptBusinessLogic.BusinessLogic;
using YouBankruptBusinessLogic.BusinessLogics;
using YouBankruptBusinessLogic.ViewModels;

namespace YouBankruptProviderView
{
    /// <summary>
    /// Логика взаимодействия для TransactionWithCustomer.xaml
    /// </summary>
    public partial class TransactionWithCustomer : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        public int? Id { set { id = value; } }

        public int CustomerId { set { Id = value; } }

        private readonly TransactionLogic _logicTransaction;

        private readonly CreditProgramLogic _logicCreditProgram;

        private readonly CreditingLogic _creditingLogic;

        private int? id;

        private int? customerId;

        public TransactionWithCustomer(TransactionLogic logicT, CreditProgramLogic logicCP, CreditingLogic logicCR)
        {
            InitializeComponent();
            this._logicTransaction = logicT;
            this._logicCreditProgram = logicCP;
            this._creditingLogic = logicCR;
        }

        private void TransactionWithCustomer_Loaded(object sender, RoutedEventArgs e)
        {
            var listCreditProgram = _logicCreditProgram.Read(null);
            if (listCreditProgram != null)
            {
                comboBoxCreditProgram.ItemsSource = listCreditProgram;
                comboBoxCreditProgram.DisplayMemberPath = "CreditProgramName";
            }
            var listCrediting = _creditingLogic.Read(null);
            if(listCrediting != null)
            {
                comboBoxCrediting.ItemsSource = listCrediting;
                comboBoxCrediting.DisplayMemberPath = "Sum";
            }
        }

        private void btnSaeve_Click(object sender, RoutedEventArgs e)
        {
            /* if (comboBoxCreditProgram.SelectedValue == null)
             {
                 MessageBox.Show("Укажите кредитную программу", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                 return;
             }*/
            if(datePikerDateFrom.SelectedDate == null)
            {
                MessageBox.Show("Укажите дату начала сделки", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (datePikerDateTo.SelectedDate == null)
            {
                MessageBox.Show("Укажите дату окончания сделки", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                _logicTransaction.CreateOrUpdate(new TransactionBindingModel
                {
                    DateFrom = datePikerDateFrom.SelectedDate,
                    DateTo = datePikerDateTo.SelectedDate,
                    CreditProgramId = (comboBoxCreditProgram.SelectedItem as CreditProgramViewModel).Id,
                    CustomerId = id,
                    CreditingId = (comboBoxCrediting.SelectedItem as CreditingViewModel).Id,
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
