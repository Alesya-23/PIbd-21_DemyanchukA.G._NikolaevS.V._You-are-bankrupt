using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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
    /// Логика взаимодействия для WindowListPurcharense.xaml
    /// </summary>
    public partial class WindowListPurcharense : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        private readonly ReportLogicSupplier report;

        public int Id
        {
            get { return (ComboBoxCurrences.SelectedItem as CurrenceViewModel).Id; }
            set { id = value; }
        }

        private int? id;
        public string CurrenceName { get { return (ComboBoxCurrences.SelectedItem as CurrenceViewModel).CurrenceName; } }
        public int SupplierId { set { supplierId = value; } }

        private int? supplierId;

        private readonly CurrenceLogic logic;

        public WindowListPurcharense(ReportLogicSupplier logicSupplier, CurrenceLogic currenceLogic)
        {
            InitializeComponent();
            report = logicSupplier;
            logic = currenceLogic;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {

            if (ComboBoxCurrences.SelectedValue == null)
            {
                MessageBox.Show("Выберите валюту", "Ошибка", MessageBoxButton.OK,
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

        private void buttonWord_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "docx|*.docx";
            if ((bool)dialog.ShowDialog())
            {
                try
                {
                    report.SavePurchaseListToWordFile(new ReportBindingModelSupplier { FileName = dialog.FileName, SupplierId = id }, CurrenceName, Id );
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            DialogResult = true;
            Close();
        }

        private void buttonExcel_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "xlsx|*.xlsx";
            if ((bool)dialog.ShowDialog())
            {
                try
                {
                    report.SavePurchaseListToExcelFile(new ReportBindingModelSupplier { FileName = dialog.FileName, SupplierId = id }, CurrenceName, Id);
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                DialogResult = true;
                Close();
            }
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
