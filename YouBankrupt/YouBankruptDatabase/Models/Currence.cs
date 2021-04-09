using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YouBankruptDatabaseImplements.Models
{
    public class Currence
    {
        public int? Id { get; set; }

        [Required]
        public string CurrenceName { get; set; }

        [Required]
        public string Rate { get; set; }

        [ForeignKey("CurrenceId")]
        public virtual List<CreditProgramCurrence> CreditProgramCurrences { get; set; }

        [ForeignKey("CurrenceId")]
        public virtual List<PurchasesCurrenceCurrence> PurchasesCurrenceCurrences { get; set; }
    }
}
