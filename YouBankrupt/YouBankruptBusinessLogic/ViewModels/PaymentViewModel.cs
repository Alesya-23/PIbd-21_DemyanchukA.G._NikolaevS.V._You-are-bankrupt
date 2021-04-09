using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace YouBankruptDatabaseImplement
{
    [DataContract]
    public class PaymentViewModel
    {
        public int? Id { get; set; }

        public int? CustomerId { get; set; }

        [DisplayName("Сумма")]
        public int Sum { get; set; }

        [DisplayName("№ Сделки")]
        public int? TransactionWithCustomerId { get; set; }

        [DisplayName("Дата плтежа")]
        public DateTime? DatePayment { get; set; }
    }
}
