using YouBankruptBusinessLogic.BindingModels;
using YouBankruptBusinessLogic.Interfaces;
using YouBankruptBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouBankruptBusinessLogic.HelperModels;

namespace YouBankruptBusinessLogic.BusinessLogics
{
    public class ReportPurhaesCurrenceLogic
    {
        private readonly ICurrenceStorage _currentStorage;
        private readonly ICreditingStorage _creditingStorage;
        private readonly IPaymentStorage _paymentStorage;

        public ReportPurhaesCurrenceLogic(ICurrenceStorage currentntStorage, ICreditingStorage creditingStorage,
     IPaymentStorage paymentStorage)
        {
            _currentStorage = currentntStorage;
            _creditingStorage = creditingStorage;
            _paymentStorage = paymentStorage;
        }

        public List<ReportPurhacesCurrenseByTransactionViewModel> GetPurhacesPayment(ReportPurhacesCurrenseByTransactionBindingModel model)
        {
            throw new NotImplementedException();
        }

        public void SaveToPdfFile(ReportPurhacesCurrenseByTransactionBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfoSupplier
            {
                FileName = model.FileName,
                Title = "Отчет по закупкам валюты",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                PurchasesCurreces = GetPurhacesPayment(model)
            });
        }
    }
}