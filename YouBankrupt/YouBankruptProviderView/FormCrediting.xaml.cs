using System;
using System.Collections.Generic;
using System.Windows;
using Unity;
using YouBankruptBusinessLogic.BindingModels;
using YouBankruptBusinessLogic.BusinessLogic;
using YouBankruptBusinessLogic.ViewModels;

namespace YouBankruptProviderView
{
    /// <summary>
    /// Логика взаимодействия для FormCrediting.xaml
    /// </summary>
    public partial class FormCrediting : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        public int Id {  set { id = value; } }

        public int CustomerId { set { customerId = value; } }

        private readonly CreditingLogic _logicCredit;

        private readonly PaymentLogic _logicPayment;

        private int? id;

        private int? customerId;

        private Dictionary<int, int> CreditingPayments;

        public FormCrediting(CreditingLogic logicC, PaymentLogic logicP)
        {
            InitializeComponent();
            _logicCredit = logicC;
            _logicPayment = logicP;
        }

        private void FormCrediting_Loaded(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                CreditingViewModel view = _logicCredit.Read(new CreditingBindingModel { Id = id.Value })?[0];
                if (view != null)
                {
                    datePickerDateCrediting.Text = view.DateCredit.ToString();
                    datePickerDateCrediting.SelectedDate = view.DateCredit;
                    textBoxSum.Text = view.Sum.ToString();
                    CreditingPayments = view.CreditPayments;
                    LoadData();
                }
            }
            else
            {
                CreditingPayments = new Dictionary<int, int>();
            }
        }



        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<FormCreditingPayments>();
            if (window.ShowDialog().Value)
            {
                if (CreditingPayments.ContainsKey(window.Id))
                {
                    //CreditingPayments[window.Id] = window.Sum;
                }
                else
                {
                    CreditingPayments.Add(window.Id, window.Sum);
                }
                LoadData();
            }
        }

        private void LoadData()
        {
            try
            {
                if (CreditingPayments != null)
                {
                    dataGridPayments.Columns.Clear();
                    var list = new List<PaymentViewModel>();
                    foreach (var p in CreditingPayments)
                    {
                        list.Add(new PaymentViewModel()
                        {
                            Id = p.Key,
                            Sum = p.Value,
                            DatePayment = _logicPayment.Read(new PaymentBindingModel { Id = p.Key })?[0].DatePayment,
                        });
                    }
                    dataGridPayments.ItemsSource = list;
                    dataGridPayments.Columns[0].Visibility = Visibility.Hidden;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (CreditingPayments == null || CreditingPayments.Count == 0)
            {
                MessageBox.Show("Заполните выплаты", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                _logicCredit.CreateOrUpdate(new CreditingBindingModel
                {
                    Id = id,
                    Sum = Convert.ToInt32(textBoxSum.Text),
                    DateCredit = (DateTime)datePickerDateCrediting.SelectedDate,
                    CustomerId = customerId,
                    CreditPayments = CreditingPayments
                    
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
