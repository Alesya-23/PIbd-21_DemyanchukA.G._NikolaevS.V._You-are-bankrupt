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
    /// Логика взаимодействия для CreditProgram.xaml
    /// </summary>
    public partial class CreditProgram : Window
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly CreditProgramLogic logic;
        private int? id;
        private Dictionary<int, (string, int)> currences;
        public CreditProgram(CreditProgramLogic service)
        {
            InitializeComponent();
            this.logic = service;
        }
        private void FormCreditProgram_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    CreditProgramViewModel view = logic.Read(new CreditProgramBindingModel { Id = id.Value })?[0];
                    if (view != null)
                    {
                        cpNameTextBox.Text = view.CreditProgramName;
                        cpPersentTextBox.Text = view.Persent.ToString();
                        cpPaymentTermTextBox.Text = view.PaymentTerm.ToString();
                        currences = view.Currenses;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                currences = new Dictionary<int, (string, int)>();
            }
        }
        private void LoadData()
        {
            try
            {
                if (currences != null)
                {
                    DataGridCurrences.Columns.Clear();
                    foreach (var pc in currences)
                    {
                        //DataGridCurrences.RowStyleSelector.Add(new object[] { pc.Value.Item1, pc.Value.Item2 });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<CurrenceCreditProgram>();
            if (form.Activate())
            {
                if (currences.ContainsKey(form.Id))
                {
                    currences[form.Id] = (((string, int))form.NameCurrenceComboBox.SelectedItem);
                }
                else
                {
                    currences.Add(form.Id, (((string, int))form.NameCurrenceComboBox.SelectedItem));
                }
                LoadData();
            }
        }
        //private void ButtonUpd_Click(object sender, EventArgs e)
        //{
        //    if (DataGridCurrences.SelectedRows.Count == 1)
        //    {
        //        var form = Container.Resolve<CurrenceCreditProgram>();
        //        int id = Convert.ToInt32(DataGridCurrences.Items[0].[0].Value);
        //        form.Id = id;
        //        if (form.Activate())
        //        {
        //            currences[form.Id] = form.NameCurrenceComboBox.Text.ToString();
        //            LoadData();
        //        }
        //    }
        //}
        //private void ButtonDel_Click(object sender, EventArgs e)
        //{
        //    if (DataGridCurrences.SelectedRows.Count == 1)
        //    {
        //        if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButton.YesNo,
        //       MessageBoxImage.Question) == DialogResult.Value)
        //        {
        //            try
        //            {
        //                currences.Remove(Convert.ToInt32(DataGridCurrences.SelectedRows[0].Cells[0].Value));
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK,
        //               MessageBoxImage.Error);
        //            }
        //            LoadData();
        //        }
        //    }
        //}
        private void ButtonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cpNameTextBox.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButton.OK,
               MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(cpPersentTextBox.Text))
            {
                MessageBox.Show("Заполните процент", "Ошибка", MessageBoxButton.OK,
               MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(cpPaymentTermTextBox.Text))
            {
                MessageBox.Show("Заполните срок", "Ошибка", MessageBoxButton.OK,
               MessageBoxImage.Error);
                return;
            }
            if (currences == null || currences.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButton.OK,
               MessageBoxImage.Error);
                return;
            }
            try
            {
                logic.CreateOrUpdate(new CreditProgramBindingModel
                {
                    Id = id,
                    CreditProgramName = cpNameTextBox.Text,
                    Persent = Convert.ToDouble(cpPersentTextBox.Text),
                    PaymentTerm = Convert.ToInt32(cpPaymentTermTextBox.Text),
                    Currenses = currences
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK,
               MessageBoxImage.Error);
            }
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}