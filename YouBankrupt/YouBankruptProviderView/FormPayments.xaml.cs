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
using YouBankruptBusinessLogic.ViewModels;

namespace YouBankruptProviderView
{
    /// <summary>
    /// Логика взаимодействия для FormPayment.xaml
    /// </summary>
    public partial class FormPayments : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        public int? Id { set { id = value; } }

        public int CustomerId { set { Id = value; } }

        private readonly PaymentLogic _logic;

        private int? id;

        private int? customerId;

        public FormPayments(PaymentLogic logic)
        {
            this._logic = logic;
            InitializeComponent();
        }

        private void FormPayments_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }


        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<FormPayment>();
            window.CustomerId = (int)id;
            if (window.ShowDialog().Value)
            {
              LoadData();
            }
        }

        private void LoadData()
        {
            try
            {
                var list = _logic.Read(new PaymentBindingModel { CustomerId = id });
                if (list != null)
                {
                    dataGrid.ItemsSource = list;
                    dataGrid.Columns[0].Visibility = Visibility.Hidden;
                    dataGrid.Columns[1].Visibility = Visibility.Hidden;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedCells.Count != 0)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    int id = (int)((PaymentViewModel)dataGrid.SelectedCells[0].Item).Id;
                    try
                    {
                        _logic.Delete(new PaymentBindingModel { Id = id });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    LoadData();
                }
            }
        }
    }
}
