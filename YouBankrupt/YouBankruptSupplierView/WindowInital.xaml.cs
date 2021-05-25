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
    /// Логика взаимодействия для WindowInital.xaml
    /// </summary>
    public partial class WindowInital : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        public WindowInital()
        {
            InitializeComponent();
        }

        private void buttonAuthorization_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<WindowAutorization>();
            window.ShowDialog();
        }

        private void buttonRegistration_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<WindowRegistration>();
            window.ShowDialog();
        }
    }
}
