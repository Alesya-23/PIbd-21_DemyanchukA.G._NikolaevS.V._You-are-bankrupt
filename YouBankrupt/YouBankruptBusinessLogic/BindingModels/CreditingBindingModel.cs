using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace YouBankruptBusinessLogic.BindingModels
{
    public class CreditingBindingModel
    {
        [DataMember]
        public int? Id { get; set; }

        [DataMember]
        public int Sum { get; set; }

        [DataMember]
        public int? CustomerId { get; set; }

        [DataMember]
        public int? TransactionWithCustomerId { get; set; }
    }
}