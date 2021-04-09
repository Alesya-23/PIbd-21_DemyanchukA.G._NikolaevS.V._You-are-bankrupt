using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace YouBankruptBusinessLogic.ViewModels
{
    [DataContract]
    public class CreditingViewModel
    {
        public int? Id { get; set; }

        public int? CustomerId { get; set; }

        [DisplayName("Сумма")]
        public int Sum { get; set; }

        [DisplayName("№ Сделки")]
        public int? TransactionWithCustomerId { get; set; }
    }
}
