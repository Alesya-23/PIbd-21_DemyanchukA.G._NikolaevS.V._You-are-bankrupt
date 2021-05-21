using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YouBankruptDatabaseImplements.Models
{
    public class PurchasesCurrence
    {
        public int? Id { get; set; }

        public int? SupplierId { get; set; }

        [Required]
        public string PurchasesName { get; set; }

        [Required]
        public DateTime DateBuy { get; set; }

        [Required]
        public double Summ { get; set; }

        public virtual Supplier Supplier { get; set; }

        [ForeignKey("PurchasesCurrenseId")]
        public virtual List<PurchasesCurrenceCurrence> PurchasesCurrenceCurrences { get; set; }
    }
}
