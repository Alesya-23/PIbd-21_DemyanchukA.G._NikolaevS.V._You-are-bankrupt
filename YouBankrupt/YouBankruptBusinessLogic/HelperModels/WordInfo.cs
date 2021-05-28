using System;
using System.Collections.Generic;
using System.Text;
using YouBankruptBusinessLogic.ViewModels;

namespace YouBankruptBusinessLogic.HelperModels
{
    public class WordInfo
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public List<ReportCurrencePaymentViewModel> reportCurrencePayments { get; set; }

        //public List<ComponentViewModel> Components { get; internal set; }
    }
}
