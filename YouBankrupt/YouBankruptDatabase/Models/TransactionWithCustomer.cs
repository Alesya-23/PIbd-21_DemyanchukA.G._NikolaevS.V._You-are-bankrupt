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

        [ForeignKey("ClientId")]
        public int? CustomerId { get; set; }

        [Required]
        public string CustomerFullName { get; set; }

        [ForeignKey("CreditProgramId")]
        public int? CreditProgramId { get; set; }

        [Required]
        public string CreditProgramName { get; set; }

        [ForeignKey("Payments")]
        public List<Payment> Payments { get; set; }
    }
}
