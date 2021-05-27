using System;
using System.ComponentModel.DataAnnotations;

namespace YouBankruptDatabaseImplements.Models
{
    public class Payment
    {
        public int Id { get; set; }

        [Required]
        public int? CustomerId { get; set; }

        [Required]
        public int? CreditId { get; set; }

        [Required]
        public int? CurrenceId { get; set; }

        [Required]
        public int? PurchasesCurrenceId { get; set; }

        [Required]
        public int Sum { get; set; }

        public DateTime? DatePayment { get; set; }
    }
}