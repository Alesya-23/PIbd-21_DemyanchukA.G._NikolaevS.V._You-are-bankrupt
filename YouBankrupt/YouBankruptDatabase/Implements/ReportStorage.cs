using System;
using System.Collections.Generic;
using System.Text;
using YouBankruptBusinessLogic.BindingModels;
using YouBankruptBusinessLogic.Interfaces;
using YouBankruptBusinessLogic.ViewModels;

namespace YouBankruptDatabaseImplements.Implements
{
    public class ReportStorage : IReportStorage
    {
        public List<ReportCurrencePaymentViewModel> GetPaymentList(ReportCurrencePaymentBindingModel model)
        {
            throw new NotImplementedException();
        }

        public List<ReportPurharenceViewModel> GetPurchares(ReportBindingModelSupplier model)
        {
            throw new NotImplementedException();
        }
    }
}
