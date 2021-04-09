using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace YouBankruptBusinessLogic.ViewModels
{
    [DataContract]
    public class TransactionWithCustomerViewModel
    {
        public int? Id { get; set; }

        public int? CustomerId { get; set; }

        [DisplayName("Клиент")]
        public string CustomerFullName { get; set; }

        public int? CreditProgramId { get; set; }

        [DisplayName("Программа кредитования")]
        public string CreditProgramName { get; set; }

        public List<int> Payments { get; set; }
    }
}