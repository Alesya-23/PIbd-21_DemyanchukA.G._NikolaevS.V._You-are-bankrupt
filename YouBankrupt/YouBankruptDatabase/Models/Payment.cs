using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YouBankruptDatabaseImplements.Models
{
    public class Payment
    {
        public int Id { get; set; }

        [Required]
        public int Sum { get; set; }

        [Required]
        public DateTime? DatePayment { get; set; }

        [ForeignKey("TransactionWithClientId")]
        public int? TransactionWithCustomerId { get; set; }
    }
}