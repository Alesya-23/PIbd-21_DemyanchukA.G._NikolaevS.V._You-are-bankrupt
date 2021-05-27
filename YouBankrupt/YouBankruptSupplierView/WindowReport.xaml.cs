using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using Unity;
using YouBankruptBusinessLogic.BusinessLogics;

namespace YouBankruptSupplierView
{
    /// <summary>
    /// Логика взаимодействия для WindowReport.xaml
    /// </summary>
    public partial class WindowReport : Window
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        public int SupplierId { set { supplierId = value; } }

        private int? supplierId;

        private readonly ReportLogicSupplier logic;

        private readonly SupplierLogic logicSupplier;

        public WindowReport(ReportLogicSupplier logic, SupplierLogic supplierLogic)
        {
            InitializeComponent();
            this.logic = logic;
            logicSupplier = supplierLogic;
        }

        private void ReportViewer_Load(object sender, EventArgs e)
        {
            reportViewer.LocalReport.ReportPath = "../../ReportProcedures.rdlc";
        }

        private void buttonMake_Click(object sender, RoutedEventArgs e)
        {
            if (datePickerFrom.SelectedDate >= datePickerTo.SelectedDate)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                ReportParameter parameterPeriod = new ReportParameter("ReportParameterPeriod",
                "c " + datePickerFrom.SelectedDate.Value.ToShortDateString() +
                " по " + datePickerTo.SelectedDate.Value.ToShortDateString());
                reportViewer.LocalReport.SetParameters(parameterPeriod);

                var supplier = logicSupplier.Read(new SupplierBindingModel
                {
                    Id = (int)supplierId
                });
                ReportParameter parameterSupplier = new ReportParameter("ReportParameterSupplier",
                supplier[0].SupplierSurame + " " + supplier[0].SupplierName);
                reportViewer.LocalReport.SetParameters(parameterSupplier);

                var dataSource = logic.GetProcedures(new ReportBindingModelSupplier
                {
                    DateFrom = datePickerFrom.SelectedDate,
                    DateTo = datePickerTo.SelectedDate,
                    SupplierId = supplierId
                });
                ReportDataSource source = new ReportDataSource("DataSetProcedures", dataSource);
                reportViewer.LocalReport.DataSources.Add(source);
                reportViewer.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void buttonToPdf_Click(object sender, RoutedEventArgs e)
        {
            if (datePickerFrom.SelectedDate >= datePickerTo.SelectedDate)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrEmpty(TextBoxEmail.Text))
            {
                MessageBox.Show("Заполните адрес электронной почты", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MailMessage msg = new MailMessage();
            SmtpSupplier supplier = new SmtpSupplier();
            try
            {
                msg.Subject = "Отчет по косметике";
                msg.Body = "Отчет по косметике за период c " + datePickerFrom.SelectedDate.Value.ToShortDateString() +
                " по " + datePickerTo.SelectedDate.Value.ToShortDateString();
                msg.From = new MailAddress("ksenia.pochta30052001@gmail.com");
                msg.To.Add(TextBoxEmail.Text);
                msg.IsBodyHtml = true;
                logic.SaveProceduresToPdfFile(new ReportBindingModelSupplier
                {
                    FileName = "D:\\Otchet.pdf",
                    DateFrom = datePickerFrom.SelectedDate,
                    DateTo = datePickerTo.SelectedDate
                });
                string file = "D:\\Otchet.pdf";
                Attachment attach = new Attachment(file, MediaTypeNames.Application.Octet);
                ContentDisposition disposition = attach.ContentDisposition;
                disposition.CreationDate = System.IO.File.GetCreationTime(file);
                disposition.ModificationDate = System.IO.File.GetLastWriteTime(file);
                disposition.ReadDate = System.IO.File.GetLastAccessTime(file);
                msg.Attachments.Add(attach);
                supplier.Host = "smtp.gmail.com";
                NetworkCredential basicauthenticationinfo = new NetworkCredential("pochta30052001@gmail.com", "пароль");
                supplier.Port = int.Parse("587");
                supplier.EnableSsl = true;
                supplier.UseDefaultCredentials = false;
                supplier.Credentials = basicauthenticationinfo;
                supplier.DeliveryMethod = SmtpDeliveryMethod.Network;
                supplier.Send(msg);
                MessageBox.Show("Сообщение отправлено", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TextBoxEmail_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            textBoxEmail.Clear();
        }
    }
}