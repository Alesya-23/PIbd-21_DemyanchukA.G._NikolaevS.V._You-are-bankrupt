using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace YouBankruptBusinessLogic.BindingModels
{
    public class PaymentBindingModel
    {
        public int? Id { get; set; }

        public int? CustomerId { get; set; }

        public int Sum { get; set; }

        public DateTime? DatePayment { get; set; }
    }
}
