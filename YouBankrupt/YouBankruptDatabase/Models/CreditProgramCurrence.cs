using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YouBankruptDatabaseImplements.Models
{
    public class CreditProgramCurrence
    {
        public int Id { get; set; }
        public int CreditProgramId { get; set; }
        public int CurrenceId { get; set; }
        
        [Required]
        public int Count { get; set; }
        public virtual CreditProgram CreditProgram { get; set; }
        public virtual Currence Currence { get; set; }
    }
}
