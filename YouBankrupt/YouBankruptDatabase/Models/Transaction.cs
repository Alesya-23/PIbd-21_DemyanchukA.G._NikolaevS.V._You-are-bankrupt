using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using YouBankruptDatabaseImplement.Models;

namespace YouBankruptDatabaseImplements.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        [Required]
        public DateTime DateFrom { get; set; }

        [Required]
        public DateTime DateTo { get; set; }

        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public int? CreditProgramId { get; set; }

        public virtual CreditProgram CreditProgram { get; set; }

        public int? CreditingId { get; set; }

        public virtual Crediting Crediting { get; set; }
    }
}
