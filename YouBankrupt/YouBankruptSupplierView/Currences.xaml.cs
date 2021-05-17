﻿using System;
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

namespace YouBankruptSupplierView
{
    /// <summary>
    /// Логика взаимодействия для CurrenceListForm.xaml
    /// </summary>
    public partial class Currences : Window
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public Currences()
        {
            InitializeComponent();
        }

        private void ButtonAddCurrence_Click(object sender, RoutedEventArgs e)
        {
            Currence form = Container.Resolve<Currence>();
            form.Show();
        }
    }
}
