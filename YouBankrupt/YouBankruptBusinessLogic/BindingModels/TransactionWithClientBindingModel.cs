using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace YouBankruptBusinessLogic.BindingModels
{
    public class TransactionWithSupplierBindingModel
    {
        [DataMember]
        public int? Id { get; set; }

        [DataMember]
        public int? SupplierId { get; set; }
    }
}
