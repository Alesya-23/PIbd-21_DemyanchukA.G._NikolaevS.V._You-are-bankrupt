using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace YouBankruptBusinessLogic.ViewModels
{
    public class CreditProgramDataGridViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название валюты")]
        public string CurrenceName { get; set; }
    }
}
