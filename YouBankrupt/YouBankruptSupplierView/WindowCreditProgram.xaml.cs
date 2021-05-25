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
    /// Логика взаимодействия для CreditProgram.xaml
    /// </summary>
    public partial class WindowCreditProgram : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        public int SupplierId { set { supplierId = value; } }
        private readonly CreditProgramLogic logic;
        private int? id;
        private int? supplierId;
        private Dictionary<int, string> currence;

        public WindowCreditProgram(CreditProgramLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void WindowCreditProgram_Loaded(object sender, RoutedEventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    CreditProgramViewModel view = logic.Read(new CreditProgramBindingModel
                    {
                        Id = id.Value
                    })?[0];
                    if (view != null)
                    {
                        currence = view.Currenses;
                        textBoxName.Text = view.CreditProgramName.ToString();
                        textBoxPersent.Text = view.Persent.ToString();
                        textBoxTerm.Text = view.PaymentTerm.ToString();

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
                currence = new Dictionary<int, string>();
            }
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                if (currence != null)
                {
                    List<CreditProgramDataGridViewModel> list = new List<CreditProgramDataGridViewModel>();
                    foreach (var item in currence)
                    {
                        list.Add(new CreditProgramDataGridViewModel()
                        {
                            Id = item.Key,
                            CurrenceName = item.Value.ToString()
                        }) ;
                    }
                    DataGridCurrences.ItemsSource = list;

                    DataGridCurrences.Columns[0].Header = "Id";
                    DataGridCurrences.Columns[0].Width = 0;
                    DataGridCurrences.Columns[0].Visibility = Visibility.Hidden;
                    DataGridCurrences.Columns[1].Header = "Название валюты";
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
            var window = Container.Resolve<WindowAddCurrence>();
            window.SupplierId = (int)supplierId;
            if (window.ShowDialog().Value)
            {
                if (!currence.ContainsKey(window.Id))
                {
                    currence.Add(window.Id, window.CurrenceName);
                }
                LoadData();
            }
        }

        private void buttonUpd_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridCurrences.SelectedCells.Count != 0)
            {
                var window = Container.Resolve<WindowAddCurrence>();
                var cellInfo = DataGridCurrences.SelectedCells[0];
                CreditProgramDataGridViewModel content = (CreditProgramDataGridViewModel)(cellInfo.Item);

                currence.Remove(content.Id);
                window.Id = content.Id;
                window.SupplierId = (int)supplierId;
                if (window.ShowDialog().Value)
                {
                    if (!currence.ContainsValue((window.CurrenceName)))
                    {
                        currence[window.Id] = (window.CurrenceName);
                    }
                    LoadData();
                }
            }
        }

        private void buttonDel_Click(object sender, RoutedEventArgs e)
        {
            if (DataGridCurrences.SelectedCells.Count != 0)
            {
                var result = MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButton.YesNo,
              MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        var cellInfo = DataGridCurrences.SelectedCells[0];
                        CreditProgramDataGridViewModel content = (CreditProgramDataGridViewModel)(cellInfo.Item);
                        int id = content.Id;
                        currence.Remove(id);
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
            if (currence == null || currence.Count == 0)
            {
                MessageBox.Show("Заполните валюты", "Ошибка", MessageBoxButton.OK,
               MessageBoxImage.Error);
                return;
            }
            try
            {
                logic.CreateOrUpdate(new CreditProgramBindingModel
                {
                    Id = id,
                    CreditProgramName = textBoxName.Text,
                    Persent = Convert.ToDouble(textBoxPersent.Text),
                    PaymentTerm = Convert.ToInt32(textBoxTerm.Text),
                    SupplierId = supplierId,
                    Currenses = currence
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = false;
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