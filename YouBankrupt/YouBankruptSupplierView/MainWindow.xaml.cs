using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Unity;
using YouBankruptBusinessLogic.BindingModels;
using YouBankruptBusinessLogic.BusinessLogics;

namespace YouBankruptSupplierView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private int? id;

        private SupplierLogic logic;
        public MainWindow(SupplierLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void CreditProgramItemClick(object sender, RoutedEventArgs e)
        {
            WindowCreditPrograms form = Container.Resolve<WindowCreditPrograms>();
            form.Id = (int)id;
            form.Show();
        }

        private void CurrenceItemClick(object sender, RoutedEventArgs e)
        {
            WindowCurrences form = Container.Resolve<WindowCurrences>();
            form.Id = (int)id;
            form.Show();
        }

        private void PurcharenseCurrenceItemClick(object sender, RoutedEventArgs e)
        {
            WindowPurchasesCurrences form = Container.Resolve<WindowPurchasesCurrences>();
           form.Id = (int)id;
            form.Show();
        }

        private void GetListItemClick(object sender, RoutedEventArgs e)
        {

        }

        private void GetReportItemClick(object sender, RoutedEventArgs e)
        {

        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var supplier = logic.Read(new SupplierBindingModel { Id = id })?[0];
            labelSupplier.Content = "Клиент: " + supplier.SupplierFullName;
        }
    }
}
