using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace YouBankruptBusinessLogic.ViewModels
{
    public class TransactionViewModel
    {
        [DisplayName("Номер сделки")]
        public int? Id { get; set; }

        [DisplayName("Начало сделки")]
        public DateTime DateFrom { get; set; }

        [DisplayName("Окончание сделки")]
        public DateTime DateTo { get; set; }

        [DisplayName("Имя заказчика")]
        public string CustomerName { get; set; }

        public string CreditProgramName { get; set; }

        public int? CreditingId { get; set; }
    }
}