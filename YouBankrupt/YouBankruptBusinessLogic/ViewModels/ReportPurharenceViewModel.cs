using System;
using System.Collections.Generic;
using System.Text;

namespace YouBankruptBusinessLogic.ViewModels
{
    public class ReportPurharenceViewModel
    {
        //для отчеть и почты
        public DateTime Date { get; set; }

        public string CurrenceName { get; set; }

        public double Count { get; set; }

        public int CreditingId { get; set; }
    }
}
