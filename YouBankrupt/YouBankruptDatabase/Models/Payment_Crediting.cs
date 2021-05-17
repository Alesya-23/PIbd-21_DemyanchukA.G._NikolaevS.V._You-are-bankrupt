using System;
using System.Collections.Generic;
using System.Text;

namespace YouBankruptDatabaseImplements.Models
{
    class Payment_Crediting
    {
        public int? Id { get; set; }

        public int? PaymentId { get; set; }

        public int? CreditingId { get; set; }
    }
}
