using System;
using System.Windows;
using Unity;
using YouBankruptBusinessLogic.BindingModels;
using YouBankruptBusinessLogic.BusinessLogic;

namespace YouBankruptProviderView
{
    /// <summary>
    /// Логика взаимодействия для FormTransactionWithCustomer.xaml
    /// </summary>
    public partial class FormTransactionWithCustomers : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private int? id;

        private TransactionLogic _logic;

        public FormTransactionWithCustomers(TransactionLogic logic)
        {
            InitializeComponent();
            this._logic = logic;
        }

        private void FormTransactionWithCustomer_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = _logic.Read(new TransactionBindingModel { CustomerId = id });
                if (list != null)
                {
                    dataGrid.ItemsSource = list;
                    //dataGrid.Columns[1].Visibility = Visibility.Hidden;
                    //dataGrid.Columns[2].Visibility = Visibility.Hidden;
                    //dataGrid.Columns[4].Visibility = Visibility.Hidden;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<TransactionWithCustomer>();
            window.CustomerId = (int)id;
            if (window.ShowDialog().Value)
            {
                LoadData();
            }
        }
    }
}
