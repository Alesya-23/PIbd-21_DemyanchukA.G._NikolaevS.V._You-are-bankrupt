using System;
using System.Collections.Generic;
using System.Windows;
using Unity;
using YouBankruptBusinessLogic.BindingModels;
using YouBankruptBusinessLogic.BusinessLogic;

namespace YouBankruptProviderView
{
    /// <summary>
    /// Логика взаимодействия для FormCrediting.xaml
    /// </summary>
    public partial class FormCreditings : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly CreditingLogic _logic;

        private int? id;

        public FormCreditings(CreditingLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<FormCrediting>();
            window.CustomerId = (int)id;
            if (window.ShowDialog().Value)
            {
                LoadData();
            }
        }

        private void FormCreditings_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = _logic.Read(new CreditingBindingModel { CustomerId = id });
                if (list != null)
                {
                    dataGrid.ItemsSource = list;
                    dataGrid.Columns[1].Visibility = Visibility.Hidden;
                    dataGrid.Columns[4].Visibility = Visibility.Hidden;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            } 
        }
    }
}
