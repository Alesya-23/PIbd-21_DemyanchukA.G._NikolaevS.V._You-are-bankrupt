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
using YouBankruptBusinessLogic.BusinessLogics;
using YouBankruptBusinessLogic.ViewModels;

namespace YouBankruptSupplierView
{
    /// <summary>
    /// Логика взаимодействия для WindowPurcharence.xaml
    /// </summary>
    public partial class WindowAddPurcharence : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        public int Id
        {
            get { return (ComboBoxCurrences.SelectedItem as CurrenceViewModel).Id; }
            set { id = value; }
        }
        private int? id;
        public string CurrenceName { get { return (ComboBoxCurrences.SelectedItem as CurrenceViewModel).CurrenceName; } }
        public int Count { get { return Convert.ToInt32(textBoxCount.Text); } set { textBoxCount.Text = value.ToString(); } }

        public int SupplierId { set { supplierId = value; } }

        private int? supplierId;

        private readonly CurrenceLogic logic;

        public WindowAddPurcharence(CurrenceLogic logic)
        {
            InitializeComponent();
            this.logic = logic;

        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {

            if (ComboBoxCurrences.SelectedValue == null)
            {
                MessageBox.Show("Выберите процедуру", "Ошибка", MessageBoxButton.OK,
               MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Укажите кол-во закупки валюты", "Ошибка", MessageBoxButton.OK,
               MessageBoxImage.Error);
                return;
            }
            this.DialogResult = true;
            Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            Close();
        }

        private CurrenceViewModel SetValue(int value)
        {
            foreach (var item in ComboBoxCurrences.Items)
            {
                if ((item as CurrenceViewModel).Id == value)
                {
                    return item as CurrenceViewModel;
                }
            }
            return null;
        }

        private void WindowBindingCurrence_Loaded(object sender, RoutedEventArgs e)
        {
            var list = logic.Read(new CurrenceBindingModel
            {
                SupplierId = supplierId
            });
            if (list != null)
            {
                ComboBoxCurrences.ItemsSource = list;
            }
            if (id != null)
            {
                ComboBoxCurrences.SelectedItem = SetValue(id.Value);
                id = null;
            }
        }
    }
}
