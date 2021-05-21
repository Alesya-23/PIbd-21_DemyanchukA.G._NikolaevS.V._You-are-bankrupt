using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YouBankruptDatabaseImplements.Models
{
    public class CreditProgram
    {
        public int? Id { get; set; }
        public int? SupplierId { get; set; }

        [Required]
        public string CreditProgramName { get; set; }

        [Required]
        public double Persent { get; set; }

        [Required]
        public int PaymentTerm { get; set; }

        [ForeignKey("CreditProgramId")]
        public virtual List<CreditProgramCurrence> CreditProgramCurrences { get; set; }

        public virtual Supplier Supplier { get; set; }

    }
}
