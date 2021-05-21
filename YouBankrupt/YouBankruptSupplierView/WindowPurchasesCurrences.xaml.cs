using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
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
    /// Логика взаимодействия для PurchasesCurrencesCurrences.xaml
    /// </summary>
    public partial class WindowPurchasesCurrences : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        private readonly PurchasesCurrenceLogic logic;

        public int Id { set { id = value; } }

        private int? id;

        public WindowPurchasesCurrences(PurchasesCurrenceLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<WindowPurchasesCurrence>();
            window.SupplierId = (int)id;
            if (window.ShowDialog().Value)
            {
                LoadData();
            }
        }

        private void buttonUpd_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridPurchasesCurrences.SelectedCells.Count != 0)
            {
                var window = Container.Resolve<WindowPurchasesCurrence>();
                var cellInfo = dataGridPurchasesCurrences.SelectedCells[0];
                PurchasesCurrenceViewModel content = (PurchasesCurrenceViewModel)(cellInfo.Item);
                window.Id = content.Id;
                window.SupplierId = (int)id;
                if (window.ShowDialog().Value)
                {
                    LoadData();
                }

            }
        }

        private void buttonDel_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridPurchasesCurrences.SelectedCells.Count != 0)
            {
                var result = MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButton.YesNo,
               MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    var cellInfo = dataGridPurchasesCurrences.SelectedCells[0];
                    PurchasesCurrenceViewModel content = (PurchasesCurrenceViewModel)(cellInfo.Item);
                    int id = content.Id;
                    try
                    {
                        logic.Delete(new PurchasesCurrenceBindingModel { Id = id });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK,
                       MessageBoxImage.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonRef_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void WindowPurchasesCurrences_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {

            var list = logic.Read(new PurchasesCurrenceBindingModel
            {
                SupplierId = id
            });
            if (list != null)
            {
                dataGridPurchasesCurrences.ItemsSource = list;
                dataGridPurchasesCurrences.Columns[0].Visibility = Visibility.Hidden;
                dataGridPurchasesCurrences.Columns[1].Visibility = Visibility.Hidden;
                dataGridPurchasesCurrences.Columns[5].Visibility = Visibility.Hidden;
                dataGridPurchasesCurrences.Columns[6].Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Данные для привязки DisplayName к названиям столбцов
        /// </summary>
        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string displayName = GetPropertyDisplayName(e.PropertyDescriptor);
            if (!string.IsNullOrEmpty(displayName))
            {
                e.Column.Header = displayName;
            }
            new DataGridLength(1, DataGridLengthUnitType.Star); // честно я хз, но вроде это растягивает последний столбец до полной ширины

        }
        /// <summary>
        /// метод привязки DisplayName к названию столбца
        /// </summary>
        public static string GetPropertyDisplayName(object descriptor)
        {

            PropertyDescriptor pd = descriptor as PropertyDescriptor;
            if (pd != null)
            {
                // Check for DisplayName attribute and set the column header accordingly
                DisplayNameAttribute displayName = pd.Attributes[typeof(DisplayNameAttribute)] as DisplayNameAttribute;
                if (displayName != null && displayName != DisplayNameAttribute.Default)
                {
                    return displayName.DisplayName;
                }

            }
            else
            {
                PropertyInfo pi = descriptor as PropertyInfo;
                if (pi != null)
                {
                    // Check for DisplayName attribute and set the column header accordingly
                    Object[] attributes = pi.GetCustomAttributes(typeof(DisplayNameAttribute), true);
                    for (int i = 0; i < attributes.Length; ++i)
                    {
                        DisplayNameAttribute displayName = attributes[i] as DisplayNameAttribute;
                        if (displayName != null && displayName != DisplayNameAttribute.Default)
                        {
                            return displayName.DisplayName;
                        }
                    }
                }
            }
            return null;
        }

    }
}
