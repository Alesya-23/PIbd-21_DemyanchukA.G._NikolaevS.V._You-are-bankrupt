using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace YouBankruptBusinessLogic.BindingModels
{
    public class TransactionBindingModel
    {
        public int? Id { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }

        public int? CustomerId { get; set; }

        public int CreditProgramId { get; set; }

        public int CreditingId { get; set; }
    }
}
