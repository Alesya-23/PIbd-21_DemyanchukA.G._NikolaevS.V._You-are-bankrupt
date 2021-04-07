using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace YouBankruptBusinessLogic.BindingModels
{
    public class TransactionWithClientBindingModel
    {
        [DataMember]
        public int? Id { get; set; }

        [DataMember]
        public int? ClientId { get; set; }
    }
}
