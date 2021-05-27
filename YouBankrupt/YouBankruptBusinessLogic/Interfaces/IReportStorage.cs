using System;
using System.Collections.Generic;
using System.Text;
using YouBankruptBusinessLogic.BindingModels;
using YouBankruptBusinessLogic.ViewModels;

namespace YouBankruptBusinessLogic.Interfaces
{
    public interface IReportStorage
    {
        List<ReportPurharenceViewModel> GetPurchares(ReportBindingModelSupplier model);

        List<ReportCurrencePaymentViewModel> GetPaymentList(ReportCurrencePaymentBindingModel model);

    }
}
