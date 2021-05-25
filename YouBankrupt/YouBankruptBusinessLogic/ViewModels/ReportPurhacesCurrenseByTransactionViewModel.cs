using YouBankruptBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace YouBankruptBusinessLogic.ViewModels
{
    public class ReportPurhacesCurrenseByTransactionViewModel
    {
        public DateTime DateCreate { get; set; }
        public string CurrenceName { get; set; }
        public int Count { get; set; }
        public string NumberTranzaction { get; set; }
    }
}
