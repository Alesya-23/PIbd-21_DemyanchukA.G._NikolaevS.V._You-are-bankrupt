using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
    /// Логика взаимодействия для PurchasesCurrence.xaml
    /// </summary>
    public partial class WindowPurchasesCurrence : Window
    {

        [Dependency]
        public IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        public int SupplierId { set { supplierId = value; } }
        private readonly PurchasesCurrenceLogic logic;
        private int? id;
        private int? supplierId;
        private Dictionary<int, (string, int)> purchasesCurrences;
        private DateTime oldDate = DateTime.MinValue;

        public WindowPurchasesCurrence(PurchasesCurrenceLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void WindowPurchasesCurrence_Loaded(object sender, RoutedEventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    PurchasesCurrenceViewModel view = logic.Read(new PurchasesCurrenceBindingModel
                    {
                        Id = id.Value
                    })?[0];
                    if (view != null)
                    {
                        CalendarPurcharense.DisplayDate = view.DateBuy;
                        CalendarPurcharense.SelectedDate = view.DateBuy;
                        oldDate = view.DateBuy;
                        Name = view.PurchasesName.ToString() ;
                        purchasesCurrences = view.Currenses;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK,
                   MessageBoxImage.Error);
                }
            }
            else
            {
                purchasesCurrences = new Dictionary<int, (string, int)>();
                CalendarPurcharense.SelectedDate = DateTime.Now;
            }
            var list = logic.GetPickDate(new PurchasesCurrenceBindingModel
            {
                DateBuy = CalendarPurcharense.SelectedDate.Value
            });
            
            if (oldDate != DateTime.MinValue)
            {
                list.Add(oldDate);
            }
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                if (purchasesCurrences != null)
                {

                    DataGridCurrence.ItemsSource = purchasesCurrences.ToList();
                    DataGridCurrence.Columns[0].Header = "Id";
                    DataGridCurrence.Columns[0].Width = 0;
                    DataGridCurrence.Columns[0].Visibility = Visibility.Hidden;
                    DataGridCurrence.Columns[1].Header = "Название процедуры:";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK,
               MessageBoxImage.Error);
            }
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            var window = Container.Resolve<WindowAddPurcharence>();
            window.SupplierId = (int)supplierId;
            if (window.ShowDialog().Value)
            {
                if (!purchasesCurrences.ContainsKey(window.Id))
                {
                    purchasesCurrences.Add(window.Id, (window.CurrenceName, Convert.ToInt32(window.Count)));
                }
                LoadData();
            }
        }

        private void buttonUpd_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridCurrence.SelectedCells.Count != 0)
            {
                var window = Container.Resolve<WindowAddPurcharence>();
                var conv = ((DataGridCurrence.SelectedItem as KeyValuePair<int, string>?));
                int id = 0;
                foreach (var p in purchasesCurrences)
                {
                    if (p.Equals(conv))
                    {
                        id = p.Key;
                        break;
                    }
                }
                purchasesCurrences.Remove(id);
                window.Id = id;
                window.SupplierId = (int)supplierId;
                if (window.ShowDialog().Value)
                {
                    if (!purchasesCurrences.ContainsValue((window.CurrenceName, Convert.ToInt32(window.Count))))
                    {
                        purchasesCurrences[window.Id] = (window.CurrenceName, Convert.ToInt32(window.Count));
                    }
                    LoadData();
                }
            }
        }

        private void buttonDel_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridCurrence.SelectedCells.Count != 0)
            {
                var result = MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButton.YesNo,
              MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        var conv = (DataGridCurrence.SelectedItem as KeyValuePair<int, string>?);
                        foreach (var p in purchasesCurrences)
                        {
                            if (p.Equals(conv))
                            {
                                purchasesCurrences.Remove(p.Key);
                                break;
                            }
                        }
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

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            if (CalendarPurcharense.SelectedDate == null)
            {
                MessageBox.Show("Заполните дату", "Ошибка", MessageBoxButton.OK,
               MessageBoxImage.Error);
                return;
            }
            if (purchasesCurrences == null || purchasesCurrences.Count == 0)
            {
                MessageBox.Show("Заполните валюты", "Ошибка", MessageBoxButton.OK,
               MessageBoxImage.Error);
                return;
            }
            try
            {
                logic.CreateOrUpdate(new PurchasesCurrenceBindingModel
                {
                    Id = id,
                    DateBuy = ((DateTime)CalendarPurcharense.SelectedDate),
                    PurchasesName = textBoxName.Text.ToString(),
                    Currenses = purchasesCurrences,
                    SupplierId = supplierId
                }) ;
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK,
               MessageBoxImage.Error);
            }
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            Close();
        }

        /// <summary>
        /// Логика обработки смены даты в календаре
        /// </summary>
        private void CalendarPurcharense_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!CalendarPurcharense.SelectedDate.HasValue)
            {
                return;
            }
            if (CalendarPurcharense.SelectedDate.Value < DateTime.Today)
            {
                MessageBox.Show("Выберете корректную дату", "Ошибка", MessageBoxButton.OK,
               MessageBoxImage.Error);
                CalendarPurcharense.SelectedDate = DateTime.Now;
                return;
            }

            CalendarPurcharense.DisplayDate = CalendarPurcharense.SelectedDate.Value;
            var list = logic.GetPickDate(new PurchasesCurrenceBindingModel
            {
                DateBuy = CalendarPurcharense.SelectedDate.Value
            });
            if (oldDate != DateTime.MinValue && oldDate.Day == CalendarPurcharense.SelectedDate.Value.Day)
            {
                list.Add(oldDate);
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