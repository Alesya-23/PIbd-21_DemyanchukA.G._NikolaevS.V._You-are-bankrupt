using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YouBankruptDatabaseImplements.Models
{
    public class PurchasesCurrenceCurrence
    {
        public int Id { get; set; }
        public int PurchasesCurrenceId { get; set; }
        public int CurrenceId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual PurchasesCurrence PurchasesCurrense { get; set; }
        public virtual Currence Currence { get; set; }
    }
}
