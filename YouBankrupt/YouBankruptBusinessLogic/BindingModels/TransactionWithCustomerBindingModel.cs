using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace YouBankruptBusinessLogic.BindingModels
{
    public class TransactionWithCustomerBindingModel
    {
        [DataMember]
        public int? Id { get; set; }

        [DataMember]
        public int? CustomerId { get; set; }

        [DataMember]
        public string CustomerFullName { get; set; }

        [DataMember]
        public int? CreditProgramId { get; set; }

        [DataMember]
        public string CreditProgramName { get; set; }

        [DataMember]
        public List<int> Payments { get; set; }
    }
}
