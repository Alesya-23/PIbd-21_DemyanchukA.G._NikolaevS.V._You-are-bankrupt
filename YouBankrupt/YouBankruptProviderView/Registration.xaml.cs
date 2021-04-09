using System.Windows;


namespace YouBankruptCustomerView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Button_Click_Registration(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_Cansel(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
