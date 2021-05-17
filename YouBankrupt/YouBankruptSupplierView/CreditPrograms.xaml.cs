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

namespace YouBankruptSupplierView
{
    /// <summary>
    /// Логика взаимодействия для CreditPrograms.xaml
    /// </summary>
    public partial class CreditPrograms : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        public CreditPrograms()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            CreditProgram form = Container.Resolve<CreditProgram>();
            form.Show();
        }
    }
}
