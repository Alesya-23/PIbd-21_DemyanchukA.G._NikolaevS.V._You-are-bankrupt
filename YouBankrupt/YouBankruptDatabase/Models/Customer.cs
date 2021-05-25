using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YouBankruptDatabaseImplements.Models
{
    public class Customer
    {
        public int? Id { get; set; }

        [Required]
        public string CustomerFullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [ForeignKey("CustomerId")]
        public List<Transaction> TransactionWithCustomers { get; set; }
    }
}
