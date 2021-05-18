using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YouBankruptDatabaseImplements.Models
{
    public class TransactionWithCustomer
    {
        public int Id { get; set; }

        [ForeignKey("TransactionWithCustomerId")]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        [ForeignKey("TransactionWithCustomerId")]
        public int CreditingProgramId { get; set; }

        public virtual CreditProgram CreditProgram { get; set; }
    }
}
