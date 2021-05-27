using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace YouBankruptBusinessLogic.ViewModels
{
    [DataContract]
    public class PaymentViewModel
    {
        public int? Id { get; set; }

        public int? CustomerId { get; set; }
        public int? CreditId { get; set; }

        [DisplayName("Сумма")]
        public int Sum { get; set; }

        [DisplayName("Дата плтежа")]
        public DateTime? DatePayment { get; set; }

        [DisplayName("Валюта")]
        public string CurrenceName{ get; set; }
    }
}
