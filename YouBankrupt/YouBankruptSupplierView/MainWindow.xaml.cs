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

namespace YouBankruptSupplierView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreditProgramItemClick(object sender, RoutedEventArgs e)
        {
            CreditPrograms form = Container.Resolve<CreditPrograms>();
            form.Show();
        }

        private void CurrenceItemClick(object sender, RoutedEventArgs e)
        {
            Currences form = Container.Resolve<Currences>();
            form.Show();
        }

        private void PurcharenseCurrenceItemClick(object sender, RoutedEventArgs e)
        {
            PurchasesCurrences form = Container.Resolve<PurchasesCurrences>();
            form.Show();
        }

        private void GetListItemClick(object sender, RoutedEventArgs e)
        {

        }

        private void GetReportItemClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
