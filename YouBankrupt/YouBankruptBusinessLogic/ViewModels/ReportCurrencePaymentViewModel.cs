using System;
using System.Collections.Generic;
using System.Text;

namespace YouBankruptBusinessLogic.ViewModels
{
    public class ReportCurrencePaymentViewModel
    {
        //для списка в доке и кселе
        public string CurrenceName { get; set; }

        public DateTime Date { get; set; }

        public decimal Cost { get; set; }

        public int CreditingId { get; set; }
    }
}
