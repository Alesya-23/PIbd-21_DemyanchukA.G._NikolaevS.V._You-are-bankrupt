using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using YouBankruptDatabaseImplement.Models;

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

        [ForeignKey("Payments")]
        public List<Payment> Payments { get; set; }

        [ForeignKey("Creditings")]
        public List<Crediting> Creditings { get; set; }

        [ForeignKey("TransactionWithClients")]
        public List<TransactionWithCustomer> TransactionWithClients { get; set; }
    }
}
