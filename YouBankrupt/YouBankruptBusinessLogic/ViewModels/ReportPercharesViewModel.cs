using System;
using System.Collections.Generic;
using System.Text;

namespace YouBankruptBusinessLogic.ViewModels
{
    public class ReportPercharesViewModel
    {

        public DateTime Date { get; set; }

        public string CurrenceName { get; set; }

        public double Count { get; set; }

        public string Number { get; set; }
    }
}
