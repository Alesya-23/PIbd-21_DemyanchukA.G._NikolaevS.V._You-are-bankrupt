using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YouBankruptDatabaseImplement.Models
{
    public class TransactionWithCustomer
    {
        public int Id { get; set; }

        [ForeignKey("CustomerId")]
        public int? CustomerId { get; set; }
    }
}
