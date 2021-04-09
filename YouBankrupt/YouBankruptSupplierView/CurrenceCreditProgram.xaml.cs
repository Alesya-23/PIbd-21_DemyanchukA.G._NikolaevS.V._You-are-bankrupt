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
using YouBankruptBusinessLogic.BusinessLogics;
using YouBankruptBusinessLogic.ViewModels;

namespace YouBankruptSupplierView
{
    /// <summary>
    /// Логика взаимодействия для CurrenceCreditProgram.xaml
    /// </summary>
    public partial class CurrenceCreditProgram : Window
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id
        {
            get { return Convert.ToInt32(NameCurrenceComboBox.SelectedValue); }
            set { NameCurrenceComboBox.SelectedValue = value; }
        }
        public string ComponentName { get { return NameCurrenceComboBox.Text; } }
       
        public CurrenceCreditProgram(CurrenceLogic  logic)
        {
            InitializeComponent();
            List<CurrenceViewModel> list = logic.Read(null);
            if (list != null)
            {
                NameCurrenceComboBox.DisplayMemberPath = "CurrenceName";
                NameCurrenceComboBox.ItemsSource = list;
                NameCurrenceComboBox.SelectedItem = null;
            }
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (NameCurrenceComboBox.SelectedValue == null)
            {
                MessageBox.Show("Выберите валюту", "Ошибка", MessageBoxButton.OK,
               MessageBoxImage.Error);
                return;
            }
            Close();
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}