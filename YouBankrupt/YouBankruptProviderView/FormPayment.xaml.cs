using System;
using System.Windows;
using Unity;
using YouBankruptBusinessLogic.BindingModels;
using YouBankruptBusinessLogic.BusinessLogic;

namespace YouBankruptProviderView
{
    /// <summary>
    /// Логика взаимодействия для FormPayment.xaml
    /// </summary>
    public partial class FormPayment : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        public int CustomerId { set { id = value; } }

        private int? id;

        private readonly PaymentLogic _logic;

        public FormPayment(PaymentLogic logic)
        {
            InitializeComponent();
            this._logic = logic;
        }

        private void FormPayment_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxSum.Text))
            {
                MessageBox.Show("Укажите сумму выплаты", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (pickDate.SelectedDate == null)
            {
                MessageBox.Show("Укажите дату выплаты", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            try
            {
                _logic.CreateOrUpdate(new PaymentBindingModel
                {
                    Id = null,
                    Sum = Convert.ToInt32(textBoxSum.Text),
                    DatePayment = pickDate.SelectedDate,
                    CustomerId = id,
                    CurrenceId = 1,
                    PurchasesCurrenceId = 1,
                });
                MessageBox.Show("Сохранение прошло успешно", "", MessageBoxButton.OK, MessageBoxImage.Information);
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
