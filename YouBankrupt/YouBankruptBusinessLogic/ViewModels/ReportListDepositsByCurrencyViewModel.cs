using System;
using System.Collections.Generic;
using System.Text;

namespace YouBankruptBusinessLogic.ViewModels
{
    public class ReportListDepositsByCurrencyViewModel
    {
        public string CurrenceName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> Crediting { get; set; }
    }
}
