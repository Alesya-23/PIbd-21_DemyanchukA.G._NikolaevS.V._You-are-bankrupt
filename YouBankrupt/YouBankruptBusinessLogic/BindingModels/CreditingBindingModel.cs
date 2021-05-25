using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace YouBankruptBusinessLogic.BindingModels
{
    public class CreditingBindingModel
    {
        public int? Id { get; set; }

        public int? CustomerId { get; set; }

        public int? CurrenceId { get; set; }

        public DateTime DateCredit { get; set; }

        public int Sum { get; set; }

        public Dictionary<int, int> CreditPayments { get; set; }
    }
}