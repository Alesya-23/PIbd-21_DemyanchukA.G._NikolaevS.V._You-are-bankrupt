using System;
using System.Collections.Generic;
using System.Text;
using YouBankruptDatabaseImplement.Models;

namespace YouBankruptDatabaseImplements.Models
{
    class TransactionWithCustomerCrediting
    {
        public int Id { get; set; }

        public int TransactionWithClientId { get; set; }

        public int CreditingId { get; set; }

        public virtual TransactionWithCustomer TransactionWithClient { get; set; }

        public virtual Crediting Crediting { get; set; }
    }
}
