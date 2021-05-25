
using System;
using System.Windows;
using Unity;
using YouBankruptBusinessLogic.BindingModels;
using YouBankruptBusinessLogic.BusinessLogic;

namespace YouBankruptProviderView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private readonly CustomerLogic _logic;

        public LogIn(CustomerLogic logic)
        {
            this._logic = logic;
            InitializeComponent();
        }

        private void Button_Click_LogIn(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_Email.Text))
            {
                MessageBox.Show("Заполните логин", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBox_Pass.Text))
            {
                MessageBox.Show("Заполните пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                var list = _logic.Read(new CustomerBindingModel
                {
                    Email = textBox_Email.Text,
                    Password = textBox_Pass.Text
                });
                if(list.Count > 0 && list != null)
                {
                    var window = Container.Resolve<MainWindow>();
                    window.Id = list[0].Id;
                    window.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Неверный логин/пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_Registration(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<Registration>();
            window.ShowDialog();
        }
    }
}
