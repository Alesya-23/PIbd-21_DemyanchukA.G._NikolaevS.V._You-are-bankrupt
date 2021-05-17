using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace YouBankruptBusinessLogic.ViewModels
{
    public class CreditProgramViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название кредитной программы")]
        public string CreditProgramName { get; set; }

        [DisplayName("Процент")]
        public double Persent { get; set; }

        [DisplayName("Срок оплаты")]
        public int PaymentTerm { get; set; }

        public Dictionary<int, (string, int)> Currenses { get; set; }
    }
}
