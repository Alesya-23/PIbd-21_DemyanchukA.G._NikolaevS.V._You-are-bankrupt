using System;
using System.Collections.Generic;
using System.Text;

namespace YouBankruptDatabaseImplements.Models
{
    public class CreditingCurrence
    {
        public int Id { get; set; }
        public int CreditingId { get; set; }
        public int CurrenceId { get; set; }
        public virtual Crediting Crediting { get; set; }
        public virtual Currence Currence { get; set; }
    }
}
