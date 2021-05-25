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
    /// Логика взаимодействия для CreateCurrenceForm.xaml
    /// </summary>
    public partial class WindowCurrence : Window
    {
        CurrenceLogic _logic;
        public int Id { set { id = value; } }
        private int? id;
        public IUnityContainer Container { get; set; }
        public int SupplierId { set { supplierId = value; } }
        private int? supplierId;

        public WindowCurrence(CurrenceLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }

        private void FormCurrence_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var view = _logic.Read(new CurrenceBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        NameCurrence.Text = view.CurrenceName;
                        Rate.Text = view.Rate;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK,
                   MessageBoxImage.Error);
                }
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NameCurrence.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButton.OK,
               MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(Rate.Text))
            {
                MessageBox.Show("Заполните курс валюты", "Ошибка", MessageBoxButton.OK,
               MessageBoxImage.Error);
                return;
            }
            try
            {
                _logic.CreateOrUpdate(new CurrenceBindingModel
                {
                    Id = id,
                    CurrenceName = NameCurrence.Text.ToString(),
                    Rate = Rate.Text.ToString(),
                    SupplierId = supplierId
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButton.OK, MessageBoxImage.Information);
                this.DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK,
               MessageBoxImage.Error);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            Close();
        }
    }
}

