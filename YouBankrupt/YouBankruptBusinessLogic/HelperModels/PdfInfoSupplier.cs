using YouBankruptBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace YouBankruptBusinessLogic.HelperModels
{
    public class PdfInfoSupplier
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public List<ReportPurhacesCurrenseByTransactionViewModel> PurchasesCurreces { get; set; }

        //public List<ReportProcurementByTransactionViewModel> Payments { get; set; }
    }
}
