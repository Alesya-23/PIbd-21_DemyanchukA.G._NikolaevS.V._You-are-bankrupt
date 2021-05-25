using System;
using System.Collections.Generic;
using System.Text;

namespace YouBankruptDatabaseImplements.Models
{
    public class ReportPerchasesCrediting
    {
        public int Id { get; set; }

        public int PurcharseId { get; set; }

        public int CreditingId { get; set; }

        public virtual PurchasesCurrence Purchases { get; set; }

        public virtual Crediting Crediting { get; set; }
    }
}
