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
    public partial class Registration : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly CustomerLogic _logic;

        private int? id;

        public Registration(CustomerLogic logic)
        {
            _logic = logic;
            InitializeComponent();
        }

        private void Button_Click_Registration(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_FullName.Text))
            {
                MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBox_Pass.Text))
            {
                MessageBox.Show("Заполните пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBox_Email.Text))
            {
                MessageBox.Show("Заполните адрес электронной почты", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                _logic.CreateOrUpdate(new CustomerBindingModel
                {
                    Id = id,
                    Password = textBox_Pass.Text,
                    Email = textBox_Email.Text,
                    CustomerFullName = textBox_FullName.Text
                });
                MessageBox.Show("Решистрация прошла успешно", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true;
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click_Cansel(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
